using AutoMapper;
using DJLNET.Model.Entities;
using DJLNET.WebMvc.Models;

namespace DJLNET.WebMvc.AutoMapper
{
    public class BasicProfile : Profile
    {
        public BasicProfile()
        {
            this.CreateMap<User, UserViewModel>();
            this.CreateMap<Role, RoleViewModel>();
            this.CreateMap<Navigate, NavigateViewModel>();

        }
    }
}