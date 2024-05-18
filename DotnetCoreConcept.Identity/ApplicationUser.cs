using Microsoft.AspNetCore.Identity;

namespace DotnetCoreConcept.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Location { get; set; }
    }
}
