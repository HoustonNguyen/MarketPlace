using Marketplace.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.API.Controllers.API
{
    public class TitleAPIController : BaseAPIController, ITitleAPIController
    {
        public TitleAPIController(MarketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext){}

        public Title GetTitle(int id)
        {
            var result = _Context.Titles.AsNoTracking()
                .Include(t => t.Awards)
                .Include(t => t.OtherNames)
                .Include(t => t.StoryLines)
                .Include(t => t.TitleGenres).ThenInclude(t => t.Genre)
                .Include(t => t.TitleParticipants).ThenInclude(t => t.Participant)
                .FirstOrDefault(t => t.TitleId == id);
            return result;
        }

        public IEnumerable<Title> GetTitles()
        {
            return _Context.Titles;
        }
    }
}
 