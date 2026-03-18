using Microsoft.AspNetCore.Identity;

namespace RmWebApi.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public string ProfilePhotoUrl { get; set; }
}
