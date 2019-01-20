using SpecialInsulator.Common.Entity;
using log4net;
using Special_Insulator.WEB.DependencyResolution;
using Specila_Insultor.BLL;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using SpecialInsulator.Common.Loger;

namespace Special_Insulator.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(object sender,EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if(cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                User user = serializer.Deserialize<User>(ticket.UserData);

                AuthenticationPrincipal principal = new AuthenticationPrincipal(user.Id,user.Roles,user.Login,user.Email);

                HttpContext.Current.User = principal;
            }
        }
    }
}
