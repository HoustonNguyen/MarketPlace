using Marketplace.API.Models.Entities;
using System.Collections.Generic;

namespace Marketplace.API.Controllers.API
{
    public interface ITitleAPIController : IBaseAPIController
    {
        IEnumerable<Title> GetTitles();
        Title GetTitle(int id);
    }
}
 