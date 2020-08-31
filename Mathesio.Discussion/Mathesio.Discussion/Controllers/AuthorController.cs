using System;
using Mathesio.Discussion.BL.EntityManagers;
using Microsoft.AspNetCore.Mvc;

namespace Mathesio.Discussion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager authorManager;

        public AuthorController(IAuthorManager manager)
        {
            authorManager = manager;
        }

        [HttpPost("create")]
        public ActionResult Create(string name, string password)
        {
            authorManager.CreateAuthor(name, password);
            return Ok();
        }

        [HttpGet("guid/{id}")]
        public IActionResult GetByID(Guid id)
        {
            return new JsonResult(authorManager.GetAuthor(id));
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            return new JsonResult(authorManager.GetAuthor(name));
        }

        [HttpPatch("{id}/changepassword")]
        public IActionResult ChangePassword(Guid id, string currentPassword, string newPassword)
        {
            if (authorManager.GetAuthor(id) == null)
            {
                return NotFound();
            }
            if (authorManager.UpdateAuthorPassword(id, currentPassword, newPassword))
            {
                return Ok();
            }

            return Unauthorized();
        }

        [HttpPatch("{id}/changename")]
        public IActionResult ChangeName(Guid id, string password, string newName)
        {
            if (authorManager.GetAuthor(id) == null)
            {
                return NotFound();
            }
            if (authorManager.UpdateAuthorName(id, password, newName))
            {
                return Ok();
            }

            return Unauthorized();
        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(Guid id, string password)
        {
            var author = authorManager.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            if (!authorManager.VerifyAuthor(author.Name, password))
            {
                return Unauthorized();
            }

            authorManager.DeleteAuthor(author);
            return Ok();
        }
    }
}