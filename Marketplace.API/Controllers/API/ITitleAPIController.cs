using Marketplace.API.Models;
using System.Collections.Generic;

namespace Marketplace.API.Controllers.API
{
    public interface ITitleAPIController : IBaseAPIController
    {
        IEnumerable<Title> GetTitles();
    }
}
 