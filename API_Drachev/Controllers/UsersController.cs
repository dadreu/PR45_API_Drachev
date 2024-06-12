﻿using API_Drachev.Context;
using API_Drachev.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_Drachev.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <returns>Данный метод преднозначен для авторизации пользователя на сайте</returns>
        /// <response code="200">Пользователь успешно авторизован</response>
        /// <response code="403">Ошибка запроса, данные не указаны</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("SingIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult SingIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null)
                return StatusCode(403);
            try
            {
                Users User = new UsersContext().Users.Where(x => x.Login == Login &&
                x.Password == Password).First;
                return Json(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Данный метод предназначен для регистрации пользователя на сайте</returns>
        /// /// <response code="200">Пользователь успешно зарегистрирован</response>
        /// /// <response code="403">Ошибка запроса, данные не указаны</response>
        /// /// <response code="500">При выполнении запроса возникла ошибка</response>
        [Route("RegIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult RegIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null) return StatusCode(403);
            try
            {
                var newUser = new UsersContext();
                Users User = new Users()
                {
                    Login = Login,
                    Password = Password
                };
                newUser.Users.Add(User);
                newUser.SaveChanges();
                return Json(newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}