using System;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Http;
using comestic_csharp.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace comestic_csharp.Security
{
    public class SecurityManager {
        
        public async void SignIn(HttpContext httpContext, User user){
            ClaimsIdentity claimsIdentify = new ClaimsIdentity(getUserClaims(user), 
            CookieAuthenticationDefaults.AuthenticationScheme);
        
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentify);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        
        }

        public async void SignOut(HttpContext httpContext){
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> getUserClaims(User user){
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            user.Role.ToList().ForEach(u => {
                claims.Add(new Claim(ClaimTypes.Role, user.Role));
            });
            return claims;
        }


    }
}