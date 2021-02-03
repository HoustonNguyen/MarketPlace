using Marketplace.API.Controllers.API;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Marketplace.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TitleController : ControllerBase
    {
        private readonly ITitleAPIController _TitleAPIController;

        public TitleController(ITitleAPIController titleAPIController)
        {
            _TitleAPIController = titleAPIController;
        }

        [HttpGet]
        [Route(nameof(GetTitles))]
        public ActionResult GetTitles()
        {
            IEnumerable<Models.Entities.Title> data = null;
            try
            {
                data = _TitleAPIController.GetTitles();
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult(new
                {
                    Message = "There was a problem retreiving the record data",
                    Details = ex
                });
            }
            
            return new JsonResult(data);
        }

        [HttpGet]
        [Route(nameof(GetTitle))]
        public ActionResult GetTitle(int id)
        {
            Models.Entities.Title data = null;
            try
            {
                data = _TitleAPIController.GetTitle(id);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult(new { 
                    Message = "There was a problem retreiving the record data",
                    Details = ex
                });
            }

            try
            {
                Dtos.Title result = data;
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult(new
                {
                    Message = "There was a problem parsing the data from the server",
                    Details = ex
                });
            }
        }

        [HttpGet]
        [Route(nameof(Search))]
        public ActionResult Search([FromQuery] Models.Request.TitleSearch request)
        {
            var result = _TitleAPIController.GetTitles();
            //TODO Should this logic be on the business side or not?
            if (string.IsNullOrWhiteSpace(request.SearchTerm) == false)
            {
                //TODO I want a better and more maintainable way of adding parameters later on
                StringComparison comparator = request.CaseSensitive ? StringComparison.CurrentCulture : StringComparison.InvariantCultureIgnoreCase;
                if (request.Contains)
                {
                    result = result.Where(r => r.TitleName.Contains(request.SearchTerm, comparator));
                }
                else
                {
                    result = result.Where(r => r.TitleName.StartsWith(request.SearchTerm, comparator));
                }
            }
            return new JsonResult(result);
        }
    }
}
