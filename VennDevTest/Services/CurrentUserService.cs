using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor )
        {
             
             UserId = "someone";
        }
        
            public string UserId { get;}
    }
}
