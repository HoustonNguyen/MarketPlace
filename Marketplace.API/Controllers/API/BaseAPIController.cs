using Marketplace.API.Models.Entities;

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
