using Marketplace.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.API.Controllers.API
{
    public abstract class BaseAPIController : IBaseAPIController
    {
        protected readonly MarketplaceDbContext _Context;

        public BaseAPIController(MarketplaceDbContext marketplaceDbContext) {
            _Context = marketplaceDbContext;
        }
    }
}
