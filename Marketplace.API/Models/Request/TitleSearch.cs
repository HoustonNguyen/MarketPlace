using System.ComponentModel.DataAnnotations;

namespace Marketplace.API.Models.Request
{
    public class TitleSearch
    {
        [Required]
        public string SearchTerm { get; set; }
        public bool CaseSensitive { get; set; } = false;
        public bool Contains { get; set; } = false;
    }
}
