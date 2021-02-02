using Marketplace.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.API.Controllers.API
{
    public class TitleAPIController : BaseAPIController, ITitleAPIController
    {
        public TitleAPIController(MarketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext){}

        public IEnumerable<Title> GetTitles()
        {
            return _Context.Titles;
        }
    }
}
 