using Marketplace.API.Controllers.API;
using Marketplace.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TitleController : ControllerBase
    {
        private readonly ILogger<TitleController> _logger;
        private readonly ITitleAPIController _TitleAPIController;

        public TitleController(ILogger<TitleController> logger, ITitleAPIController titleAPIController)
        {
            _logger = logger;
            _TitleAPIController = titleAPIController;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _TitleAPIController.GetTitles();
            return new JsonResult(result);
        }
    }
}
