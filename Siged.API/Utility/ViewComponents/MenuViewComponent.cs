using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Siged.Application.Menus.DTOs;
using Siged.Application.Menus.Interfaces;
using System.Security.Claims;

namespace Siged.API.Utility.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuViewComponent(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClaimsPrincipal principal = HttpContext.User;
            List<GetMenu> listMenus;

            if (principal.Identity.IsAuthenticated)
            {
                string userId = principal.Claims
                    .Where(c => c.Type == ClaimTypes.NameIdentifier)
                    .Select(c => c.Value).SingleOrDefault();

                listMenus = _mapper.Map<List<GetMenu>>(await _menuService.GetListAsync(int.Parse(userId)));


            }
            else
            {
                listMenus = new List<GetMenu> { };
            }

            return View(listMenus);


        }


    }
}
