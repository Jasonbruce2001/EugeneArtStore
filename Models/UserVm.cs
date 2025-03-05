using Microsoft.AspNetCore.Identity;

namespace EugeneArtStore.Models;

public class UserVm
{
    public IEnumerable<AppUser> Users { get; set; }
    public IEnumerable<IdentityRole> Roles { get; set; }
}