using Store.MVC.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace Store.MVC.Infrastructure.Concrete
{
    public class AuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username,password);
            if (result)
            {   
                //false, тк нам не нужны постоянные куки
                FormsAuthentication.SetAuthCookie(username,false);
            }
            return result;
        }
    }
}