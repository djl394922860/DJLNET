using AutoMapper;
using DJLNET.Model.Models;
using DJLNET.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.AutoMapper
{
    public class BasicProfile : Profile
    {
        public BasicProfile()
        {
            this.CreateMap<Platform, PlatformViewModel>();
        }
    }
}