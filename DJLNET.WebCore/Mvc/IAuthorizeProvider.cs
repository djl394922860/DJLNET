﻿using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.Mvc
{
    public interface IAuthorizeProvider
    {
        bool Authorize(string permissionName);
        bool Authorize(string permissionName,User user);
    }
}
