using Marketplace.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.API.Controllers.API
{
    public class TitleAPIController : BaseAPIController, ITitleAPIController
    {
        public TitleAPIController(MarketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext){}

        public Title GetTitle(int id)
        {
            //The entity is not hydrated with relational entities by default, so we explicitly tell it to include these items
            //We don't want to include the entire model with related entities when retreiving ALL titles, but it makes sense for a single title
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
 