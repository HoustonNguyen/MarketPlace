using Marketplace.API.Constants;

namespace Marketplace.API.Dtos
{
    public class Award
    {
        public string AwardWon { get; set; } = AwardStatuses.NOMINATED;
        public int? AwardYear { get; set; }
        public string AwardName { get; set; }
        public string AwardCompany { get; set; }
        public int Id { get; set; }
    }
}
