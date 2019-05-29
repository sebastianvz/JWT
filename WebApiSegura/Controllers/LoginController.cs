﻿using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using WebApiSegura.Models;
using WebApiSegura.Security;
using WebApiSegura.Services;

namespace WebApiSegura.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            ServiceUser service = new ServiceUser();
            User user = service.get_UserByLogin(login.Username, login.Password);
            bool isCredentialValid;
            if (user != null)
            {
                isCredentialValid = true;
                if (isCredentialValid)
                {
                    var token = TokenGenerator.GenerateTokenJwt(user);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }


    }
}

