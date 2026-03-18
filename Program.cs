

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Mapping;
using RmWebApi.Repositories.EntityFramework;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services;
using RmWebApi.Services.Concretes;
using RmWebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger + JWT
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "RM Web API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Token'ı girin. Örnek: eyJhbGci..."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
{
    [new OpenApiSecuritySchemeReference("Bearer", document)] = []
});
});

// DbContext
builder.Services.AddDbContext<RmContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<RmContext>()
.AddDefaultTokenProviders();

// JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddAuthorization();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontends", policy =>
    {
        policy.WithOrigins(
            "https://mr-bauunternehmen.de",
            "https://www.mr-bauunternehmen.de",
            "https://test.mr-bauunternehmen.de",
            "https://admin.mr-bauunternehmen.de"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(GeneralMapping));

// Repositories
builder.Services.AddScoped<IBenefitRepository, EFBenefitRepository>();
builder.Services.AddScoped<IBenefitCheckItemRepository, EFBenefitCheckItemRepository>();
builder.Services.AddScoped<ICertificateRepository, EFCertificateRepository>();
builder.Services.AddScoped<IContactRepository, EFContactRepository>();
builder.Services.AddScoped<IContactFormSubmissionRepository, EFContactFormSubmissionRepository>();
builder.Services.AddScoped<IContentPageRepository, EFContentPageRepository>();
builder.Services.AddScoped<IFaqItemRepository, EFFaqItemRepository>();
builder.Services.AddScoped<IGalleryImageRepository, EFGalleryImageRepository>();
builder.Services.AddScoped<IGoogleReviewRepository, EFGoogleReviewRepository>();
builder.Services.AddScoped<IHeroSettingsRepository, EFHeroSettingsRepository>();
builder.Services.AddScoped<ILegalPageRepository, EFLegalPageRepository>();
builder.Services.AddScoped<IPageHeroRepository, EFPageHeroRepository>();
builder.Services.AddScoped<IProjectRepository, EFProjectRepository>();
builder.Services.AddScoped<IProjectCategoryRepository, EFProjectCategoryRepository>();
builder.Services.AddScoped<IServiceRepository, EFServiceRepository>();
builder.Services.AddScoped<IServiceItemRepository, EFServiceItemRepository>();
builder.Services.AddScoped<IStatFactRepository, EFStatFactRepository>();
builder.Services.AddScoped<ISubscriberRepository, EFSubscriberRepository>();
builder.Services.AddScoped<IGoogleReviewService, GoogleReviewManager>();
builder.Services.AddHttpClient(); 
builder.Services.AddHostedService<GoogleReviewSyncService>();
// Services
builder.Services.AddScoped<IBenefitService, BenefitManager>();
builder.Services.AddScoped<IBenefitCheckItemService, BenefitCheckItemManager>();
builder.Services.AddScoped<ICertificateService, CertificateManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactFormSubmissionService, ContactFormSubmissionManager>();
builder.Services.AddScoped<IContentPageService, ContentPageManager>();
builder.Services.AddScoped<IFaqItemService, FaqItemManager>();
builder.Services.AddScoped<IGalleryImageService, GalleryImageManager>();
builder.Services.AddScoped<IHeroSettingsService, HeroSettingsManager>();
builder.Services.AddScoped<ILegalPageService, LegalPageManager>();
builder.Services.AddScoped<IPageHeroService, PageHeroManager>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IProjectCategoryService, ProjectCategoryManager>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceItemService, ServiceItemManager>();
builder.Services.AddScoped<IStatFactService, StatFactManager>();
builder.Services.AddScoped<ISubscriberService, SubscriberManager>();

var app = builder.Build();

try
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<RmContext>();
    db.Database.Migrate();
}
catch (Exception ex)
{
    Console.WriteLine($"Migration error: {ex.Message}");
}


    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "RM Web API v1");
    c.RoutePrefix = "swagger";
    c.ConfigObject.AdditionalItems["requestSnippetsEnabled"] = true;
    c.DisplayRequestDuration();
    });


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseStaticFiles();

app.UseCors("AllowFrontends");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
