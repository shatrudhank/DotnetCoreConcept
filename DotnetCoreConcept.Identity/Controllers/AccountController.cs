using DotnetCoreConcept.Identity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreConcept.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> Async(RegisterDTO registerDTO)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Email = registerDTO.Email,
                    PhoneNumber = registerDTO.Phone,
                    UserName = registerDTO.Email
                };

                var identityResult= await _userManager.CreateAsync(applicationUser,registerDTO.Password);
                if(identityResult.Succeeded)
                {
                    return Ok("Account Created Successfully");
                }
                else
                {
                    foreach (IdentityError error in identityResult.Errors)
                    {
                        ModelState.AddModelError("Register", error.Description);
                    }
                    return Conflict()   
                }
            }


            return BadRequest(ModelState);
        }
    }
}
