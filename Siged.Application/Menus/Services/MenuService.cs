using AutoMapper;
using Siged.Application.Menus.DTOs;
using Siged.Application.Menus.Interfaces;
using Siged.Domain;
using Siged.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Menus.Services
{
    public class MenuService : IMenuService
    {

        private readonly IGenericRepository<Menu> _menuRepository;
        private readonly IGenericRepository<RolMenu> _rolMenuRepository;
        private readonly IGenericRepository<UserInfo> _userRepository;
        private readonly IMapper _mapper;

        public MenuService(
            IGenericRepository<Menu> menuRepository, 
            IGenericRepository<RolMenu> rolMenuRepository, 
            IGenericRepository<UserInfo> userRepository,
            IMapper mapper)
        {
            _menuRepository = menuRepository;
            _rolMenuRepository = rolMenuRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

    public async Task<List<GetMenu>> GetListAsync(int userId)
        {
            IQueryable<UserInfo> tbUser = await _userRepository.VerifyDataExistenceAsync(u => u.UserId == userId);
            IQueryable<RolMenu> tbRolMenu = await _rolMenuRepository.VerifyDataExistenceAsync();
            IQueryable<Menu> tbMenu = await _menuRepository.VerifyDataExistenceAsync();

            IQueryable<Menu> ParentMenu = (from u in tbUser
                             join rm in tbRolMenu on u.RolId equals rm.RolId
                             join m in tbMenu on rm.MenuId equals m.MenuId
                             join parentM in tbMenu on m.ParentMenuId equals parentM.MenuId
                             select parentM).Distinct().AsQueryable();

            IQueryable<Menu> SonMenu = (from u in tbUser
                             join rm in tbRolMenu on u.RolId equals rm.RolId
                             join m in tbMenu on rm.MenuId equals m.MenuId
                             where m.MenuId != m.ParentMenuId
                             select m).Distinct().AsQueryable();

            List<Menu> listMenu = (from parentMenu in ParentMenu
                       select new Menu() {

                           DescriptionMenu = parentMenu.DescriptionMenu,
                           IconMenu = parentMenu.IconMenu,
                           Controller = parentMenu.Controller,
                           ActionPage = parentMenu.ActionPage,
                           InverseParentMenu = (from sonMenu in SonMenu
                                         where sonMenu.ParentMenuId == parentMenu.MenuId
                                         select sonMenu).ToList()
                       }).ToList();

            return _mapper.Map<List<GetMenu>>(listMenu);
        }
    }
}
