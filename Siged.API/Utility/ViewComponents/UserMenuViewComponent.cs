using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Siged.API.Utility.ViewComponents
{
    public class UserMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClaimsPrincipal principal = HttpContext.User;

            string nameUser = "";

            if (principal.Identity.IsAuthenticated)
            {
                nameUser = principal.Claims
                    .Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = nameUser;

            return View();

        }
    }
}
