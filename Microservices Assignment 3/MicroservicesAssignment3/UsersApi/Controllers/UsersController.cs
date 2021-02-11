using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserEntities.Entities;

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet, Route("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id=1,
                    Name="Hotel 1",
                    Email="hotel1@gmail.com",
                    Address="Ahmedabad",
                    Contact="2336732"

                },
                new User()
                {
                    Id=2,
                    Name="Hotel 2",
                    Address="Mumbai",
                    Contact="3248923",
                    Email="Hotel2@gmail.com"

                },
            };

            return users;
        }
    }
}
