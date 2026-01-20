using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pelebox.Application.ViewModels;
using System.Security.Claims;

namespace Pelebox.API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class LoggedInBaseController : ControllerBase {
        public LoggedInUser LoggedInUser {
            get {
                ClaimsIdentity claimsIdentity = (ClaimsIdentity)HttpContext.User.Identity;
                LoggedInUser loggedInUser = new();

                if (string.IsNullOrWhiteSpace(claimsIdentity.Name)) {
                    loggedInUser = null;
                } else {
                    if (claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault() != null)
                        loggedInUser.UserID = Convert.ToInt32(claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value);

                    if (claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault() != null)
                        loggedInUser.Email = Convert.ToString(claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault().Value);

                    if (claimsIdentity.Claims.Where(c => c.Type == "FirstName").FirstOrDefault() != null)
                        loggedInUser.FirstName = Convert.ToString(claimsIdentity.Claims.Where(c => c.Type == "FirstName").FirstOrDefault().Value);

                    if (claimsIdentity.Claims.Where(c => c.Type == "LastName").FirstOrDefault() != null)
                        loggedInUser.LastName = Convert.ToString(claimsIdentity.Claims.Where(c => c.Type == "LastName").FirstOrDefault().Value);
                }

                return loggedInUser;
            }
        }
    }
}