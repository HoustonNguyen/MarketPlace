using Marketplace.API.Controllers.API;
using Marketplace.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TitleController> _logger;
        private readonly ITitleAPIController _TitleAPIController;

        public TitleController(ILogger<TitleController> logger, ITitleAPIController titleAPIController)
        {
            _logger = logger;
            _TitleAPIController = titleAPIController;
        }

        [HttpGet]
        [Route(nameof(GetTitles))]
        public ActionResult GetTitles()
        {
            IEnumerable<Models.Title> data = null;
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
            Models.Title data = null;
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

            Dtos.Title result = null;
            try
            {
                result = new Dtos.Title()
                {
                    TitleId = data.TitleId,
                    TitleName = data.TitleName,
                    TitleTypeId = data.TitleTypeId,
                    ReleaseYear = data.ReleaseYear,
                    ProcessedDateTimeUtc = data.ProcessedDateTimeUtc,
                    Awards = data.Awards.Select(a => new Dtos.Award()
                    {
                        Id = a.Id,
                        AwardName = a.Award1,
                        AwardCompany = a.AwardCompany,
                        AwardWon = (a.AwardWon ?? false) ? "Won" : "Nominated",
                        AwardYear = a.AwardYear
                    }).ToList(),
                    Credits = data.TitleParticipants.Select(tp => new Dtos.Credit()
                    {
                        Id = tp.Id,
                        Name = tp.Participant?.Name ?? "Missing Name",
                        IsKey = tp.IsKey.ToYesOrNo(),
                        IsOnScreen = tp.IsOnScreen.ToYesOrNo(),
                        RoleType = tp.RoleType
                    }).ToList(),
                    Genres = data.TitleGenres.Select(tg => new Dtos.Genre()
                    {
                        Id = tg.Id,
                        Name = tg.Genre?.Name ?? "Missing Genre"
                    }).ToList(),
                    OtherNames = data.OtherNames.Select(o => new Dtos.OtherName()
                    {
                        Id = o.Id,
                        TitleName = $"{o.TitleName} ({o.TitleNameLanguage ?? "Unknown"})",
                        TitleNameLanguage = o.TitleNameLanguage,
                        TitleNameType = o.TitleNameType
                    }).ToList(),
                    StoryLines = data.StoryLines.Select(s => new Dtos.StoryLine()
                    {
                        Id = s.Id,
                        Description = s.Description,
                        Language = s.Language,
                        Type = s.Type
                    }).ToList()
                };
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

            return new JsonResult(result);
        }

        [HttpGet]
        [Route(nameof(Search))]
        public ActionResult Search(string searchTerm, bool caseSensitive = false, bool contains = false)
        {
            var result = _TitleAPIController.GetTitles();
            //TODO Should this logic be on the business side or not?
            if (string.IsNullOrWhiteSpace(searchTerm) == false)
            {
                //TODO I want a better and more maintainable way of adding parameters later on
                StringComparison comparator = caseSensitive ? StringComparison.CurrentCulture : StringComparison.InvariantCultureIgnoreCase;
                if (contains)
                {
                    result = result.Where(r => r.TitleName.Contains(searchTerm, comparator));
                }
                else
                {
                    result = result.Where(r => r.TitleName.StartsWith(searchTerm, comparator));
                }
            }
            return new JsonResult(result);
        }
    }
}
