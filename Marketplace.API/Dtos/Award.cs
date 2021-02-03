namespace Marketplace.API.Dtos
{
    public class Award
    {
        //TODO Put possible enumarations of this field in a constants file
        public string AwardWon { get; set; } = "Nominated";
        public int? AwardYear { get; set; }
        public string AwardName { get; set; }
        public string AwardCompany { get; set; }
        public int Id { get; set; }
    }
}
