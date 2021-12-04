using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApi.Infrastructure;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        public static List<IUser> UserList = new List<IUser>()
        {
            new Customer
            {
                Id = 1,
                Name = "Ahmet",
                Email = "ahmet@gmail.com",
                BirthDate = new DateTime(1998,09,08)
            },
            new Customer
            {
                Id = 2,
                Name = "Ayse",
                Email = "ayse@gmail.com",
                BirthDate = new DateTime(1995,03,12)
            },
            new Customer
            {
                Id = 3,
                Name = "Mehmet",
                Email = "mehmet@gmail.com",
                BirthDate = new DateTime(1995,03,12)
            },
            new Customer
            {
                Id = 4,
                Name = "Tuğba",
                Email = "tugba@gmail.com",
                BirthDate = new DateTime(1995,03,12)
            },
            new Staff
            {
                Id = 5,
                Name = "Atakan",
                Email = "atakan@gmail.com",
                BirthDate = new DateTime(1998,03,12),
                IsAdmin = true
            }
        };

        [HttpGet]
        public List<IUser> GetUserList()
        {
            return UserList;
        }

        [HttpGet("{id}")]
        [UserIdentifier]
        public IUser GetUser(int id)
        {
            var user = UserList.SingleOrDefault(user => user.Id == id);

            return user;
        }

        [HttpPost]
        public IActionResult Register([FromBody] IUser newUser)
        {
            var user = UserList.SingleOrDefault(user => user.Id == newUser.Id);

            if (user is not null)
            {
                return BadRequest();
            }

            UserList.Add(newUser);
            return Redirect("/Users");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] IUser updatedUser)
        {
            var user = UserList.SingleOrDefault(user => user.Id == id);

            if (user is null)
            {
                return BadRequest();
            }

            user.Name = updatedUser.Name == user.Name ? user.Name : updatedUser.Name;
            user.Email = updatedUser.Email == user.Email ? user.Email : updatedUser.Email;
            user.BirthDate = updatedUser.BirthDate == user.BirthDate ? user.BirthDate : updatedUser.BirthDate;

            return Redirect("/Users");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = UserList.SingleOrDefault(user => user.Id == id);

            if (user is null)
            {
                return BadRequest();
            }

            UserList.Remove(user);
            return Redirect("/Users");
        }
    }
}