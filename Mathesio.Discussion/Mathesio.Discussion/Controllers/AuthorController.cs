using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathesio.Discussion.BL.EntityManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mathesio.Discussion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorManager authorManager;

        public AuthorController(AuthorManager manager)
        {
            authorManager = manager;
        }
    }
}