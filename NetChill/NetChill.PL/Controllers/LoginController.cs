using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NetChill.BLL;
using NetChill.BOL;
using NetChill.PL.Controllers.JWT_Token_Manager;

namespace NetChill.Controllers
{
    //controller for Login User
    public class LoginController : ApiController
    {
        IGetUser user = null;
        LoginController()
        {
            user = new BLL_GetUser();
        }

        public IHttpActionResult Post([FromBody]BOL_LoginUser u)
        {
            if (ModelState.IsValid)
            {
                var user = this.user.ValidateUser(u.email, u.password);
                if (user != null && user.IsRevoked == false)
                {
                    var token = JWTTokenManager.GenerateToken(user.Email);
                    return Ok(new
                    {
                        token,
                        user.IsAdmin
                    });
                }
                else if (user != null)
                    return BadRequest("User is Revoked.Please Contact Support.");

            }
            return BadRequest("Please Check Email and Password");
        }
    }
}
