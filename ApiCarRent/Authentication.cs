using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BOLCarRent.Users;
using System.Threading;
using System.Security.Principal;

namespace ApiCarRent
{
    public class Authentication : AuthorizationFilterAttribute
    {
        
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            IEnumerable<string> authHeaders;
            if (!actionContext.Request.Headers.TryGetValues("Authorization", out authHeaders))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = authHeaders.ToList()[0];
                try
                {
                    //decoding token
                    string decodetAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                    string[] tokenData = decodetAuthenticationToken.Split('#');
                    string email = tokenData[0];
                    string role = tokenData[1];
                    string date = tokenData[2];
                    var curentTime = DateTime.UtcNow;
                    DateTime dt = Convert.ToDateTime(date);

                    //check token date overdue
                    if (dt < curentTime)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                       //set role to user
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(email), new string[] {role});
                 
                }
                catch
                {
                    //catch  exeption if Unauthorized
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}