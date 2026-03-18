using AutoMapper;
using RmWebApi.DTOs.AuthDTOs;
using RmWebApi.DTOs.BenefitCheckItemDTOs;
using RmWebApi.DTOs.BenefitDTOs;
using RmWebApi.DTOs.CertificateDTOs;
using RmWebApi.DTOs.ContactDTOs;
using RmWebApi.DTOs.ContactFormSubmissionDto;
using RmWebApi.DTOs.ContentPageDTOs;
using RmWebApi.DTOs.FaqItemDTOs;
using RmWebApi.DTOs.GalleryImageDTOs;
using RmWebApi.DTOs.GoogleReviewDTOs;
using RmWebApi.DTOs.HeroSettingsDTOs;

using RmWebApi.DTOs.LegalPageDTOs;
using RmWebApi.DTOs.PageHeroDTOs;
using RmWebApi.DTOs.ProjectCategoryDTOs;
using RmWebApi.DTOs.ProjectDTOs;
using RmWebApi.DTOs.ServiceDTOs;
using RmWebApi.DTOs.ServiceItemDTOs;
using RmWebApi.DTOs.StatFactDTOs;
using RmWebApi.DTOs.SubscriberDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // HeroSettings
            CreateMap<HeroSettings, ResultHeroSettingsDto>().ReverseMap();
            CreateMap<HeroSettings, CreateHeroSettingsDto>().ReverseMap();
            CreateMap<HeroSettings, GetByIdHeroSettingsDto>().ReverseMap();
            CreateMap<HeroSettings, UpdateHeroSettingsDto>().ReverseMap();

            // Service
            CreateMap<Service, ResultServiceDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items != null
                    ? src.Items.OrderBy(i => i.DisplayOrder).ToList()
                    : new List<ServiceItem>()));
            CreateMap<ResultServiceDto, Service>()
                .ForMember(dest => dest.Items, opt => opt.Ignore());
            CreateMap<Service, CreateServiceDto>().ReverseMap()
                .ForMember(dest => dest.Items, opt => opt.Ignore());
            CreateMap<Service, GetByIdServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap()
                .ForMember(dest => dest.Items, opt => opt.Ignore());

            // ServiceItem
            CreateMap<ServiceItem, ResultServiceItemDto>().ReverseMap();
            CreateMap<ServiceItem, CreateServiceItemDto>().ReverseMap();
            CreateMap<ServiceItem, GetByIdServiceItemDto>().ReverseMap();
            CreateMap<ServiceItem, UpdateServiceItemDto>().ReverseMap();

            // GoogleReview
            CreateMap<GoogleReview, ResultGoogleReviewDto>().ReverseMap();
            
            CreateMap<GoogleReview, CreateGoogleReviewDto>().ReverseMap();
            CreateMap<GoogleReview, GetByIdGoogleReviewDto>().ReverseMap();
            CreateMap<GoogleReview, UpdateGoogleReviewDto>().ReverseMap();

            // StatFact
            CreateMap<StatFact, ResultStatFactDto>().ReverseMap();
            CreateMap<StatFact, CreateStatFactDto>().ReverseMap();
            CreateMap<StatFact, GetByIdStatFactDto>().ReverseMap();
            CreateMap<StatFact, UpdateStatFactDto>().ReverseMap();

            // Benefit
            CreateMap<Benefit, ResultBenefitDto>()
                .ForMember(dest => dest.CheckItems, opt => opt.MapFrom(src => src.BenefitCheckItems != null ? src.BenefitCheckItems.Select(c => c.Text).ToList() : new List<string>()));
            CreateMap<ResultBenefitDto, Benefit>()
                .ForMember(dest => dest.BenefitCheckItems, opt => opt.Ignore());
            CreateMap<Benefit, CreateBenefitDto>().ReverseMap();
            CreateMap<Benefit, GetByIdBenefitDto>().ReverseMap();
            CreateMap<Benefit, UpdateBenefitDto>().ReverseMap();

            // BenefitCheckItem
            CreateMap<BenefitCheckItem, ResultBenefitCheckItemDto>().ReverseMap();
            CreateMap<BenefitCheckItem, CreateBenefitCheckItemDto>().ReverseMap();
            CreateMap<BenefitCheckItem, GetByIdBenefitCheckItemDto>().ReverseMap();
            CreateMap<BenefitCheckItem, UpdateBenefitCheckItemDto>().ReverseMap();

            // Subscriber
            CreateMap<Subscriber, ResultSubscriberDto>().ReverseMap();
            CreateMap<Subscriber, CreateSubscriberDto>().ReverseMap();
            CreateMap<Subscriber, GetByIdSubscriberDto>().ReverseMap();
            CreateMap<Subscriber, UpdateSubscriberDto>().ReverseMap();

            // LegalPage
            CreateMap<LegalPage, ResultLegalPageDto>().ReverseMap();
            CreateMap<LegalPage, CreateLegalPageDto>().ReverseMap();
            CreateMap<LegalPage, GetByIdLegalPageDto>().ReverseMap();
            CreateMap<LegalPage, UpdateLegalPageDto>().ReverseMap();

            // PageHero
            CreateMap<PageHero, ResultPageHeroDto>().ReverseMap();
            CreateMap<PageHero, CreatePageHeroDto>().ReverseMap();
            CreateMap<PageHero, GetByIdPageHeroDto>().ReverseMap();
            CreateMap<PageHero, UpdatePageHeroDto>().ReverseMap();

            // Project
            CreateMap<Project, ResultProjectDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.ProjectCategory != null ? src.ProjectCategory.Name : null));
            CreateMap<ResultProjectDto, Project>()
                .ForMember(dest => dest.ProjectCategory, opt => opt.Ignore());
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, GetByIdProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();

            // ProjectCategory
            CreateMap<ProjectCategory, ResultProjectCategoryDto>().ReverseMap();
            CreateMap<ProjectCategory, CreateProjectCategoryDto>().ReverseMap();
            CreateMap<ProjectCategory, GetByIdProjectCategoryDto>().ReverseMap();
            CreateMap<ProjectCategory, UpdateProjectCategoryDto>().ReverseMap();

            // Certificate
            CreateMap<Certificate, ResultCertificateDto>().ReverseMap();
            CreateMap<Certificate, CreateCertificateDto>().ReverseMap();
            CreateMap<Certificate, GetByIdCertificateDto>().ReverseMap();
            CreateMap<Certificate, UpdateCertificateDto>().ReverseMap();

            // GalleryImage
            CreateMap<GalleryImage, ResultGalleryImageDto>().ReverseMap();
            CreateMap<GalleryImage, CreateGalleryImageDto>().ReverseMap();
            CreateMap<GalleryImage, GetByIdGalleryImageDto>().ReverseMap();
            CreateMap<GalleryImage, UpdateGalleryImageDto>().ReverseMap();

            // FaqItem
            CreateMap<FaqItem, ResultFaqItemDto>().ReverseMap();
            CreateMap<FaqItem, CreateFaqItemDto>().ReverseMap();
            CreateMap<FaqItem, GetByIdFaqItemDto>().ReverseMap();
            CreateMap<FaqItem, UpdateFaqItemDto>().ReverseMap();

            // Contact
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            // ContactFormSubmission
            CreateMap<ContactFormSubmission, ResultContactFormSubmissionDto>().ReverseMap();
            CreateMap<ContactFormSubmission, CreateContactFormSubmissionDto>().ReverseMap();
            CreateMap<ContactFormSubmission, GetByIdContactFormSubmissionDto>().ReverseMap();
            CreateMap<ContactFormSubmission, UpdateContactFormSubmissionDto>().ReverseMap();

            // ContentPage
            CreateMap<ContentPage, ResultContentPageDto>().ReverseMap();
            CreateMap<ContentPage, CreateContentPageDto>().ReverseMap();
            CreateMap<ContentPage, GetByIdContentPageDto>().ReverseMap();
            CreateMap<ContentPage, UpdateContentPageDto>().ReverseMap();

            //AppUser
            CreateMap<AppUser, TokenResponseDto>().ReverseMap();
            CreateMap<AppUser, UpdatePhotoDto>().ReverseMap();
        }
    }
}