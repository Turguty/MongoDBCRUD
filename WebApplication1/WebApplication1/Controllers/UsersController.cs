using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataLayer.Abstracts;
using WebApplication1.Model;

namespace AspCoreApiMongoDb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUsersService _usersService;
        public ProductController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet]
        [Route("api/user")]
        public Task<IEnumerable<Users>> Get()
        {
            return _usersService.GetAllUser();
        }

        [HttpGet]
        [Route("api/user/getByName")]
        public async Task<IActionResult> GetByAge(string name)
        {
            try
            {
                var product = await _usersService.GetUser(name);
                if (product == null)
                {
                    return Json("No product found!");
                }
                return Json(product);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());

            }

        }

        [HttpPost]
        [Route("api/user")]
        public async Task<IActionResult> Post(Users model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Name))
                    return BadRequest("Please enter user name");
                else if (string.IsNullOrWhiteSpace(model.Age))
                    return BadRequest("Please enter age");
                else if (string.IsNullOrWhiteSpace(model.Password))
                    return BadRequest("Please enter password");

                model.CreatedOn = DateTime.UtcNow;
                await _usersService.AddUser(model);
                return Ok("Your user has been added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("api/user/updatePassword")]
        public async Task<IActionResult> UpdatePassword(Users model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return BadRequest("Product name missing");
            model.UpdatedOn = DateTime.UtcNow;
            var result = await _usersService.UpdatePassword(model);
            if (result)
            {
                return Ok("Your product's password has been updated successfully");
            }
            return BadRequest("No product found to update");

        }

        [HttpDelete]
        [Route("api/user")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest("Product name missing");
                await _usersService.RemoveUser(name);
                return Ok("Your user has been deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/user/deleteAll")]
        public IActionResult DeleteAll()
        {
            try
            {
                _usersService.RemoveAllUser();
                return Ok("Your all products has been deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}