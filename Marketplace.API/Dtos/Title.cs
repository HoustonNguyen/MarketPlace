using Marketplace.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.API.Dtos
{
    public class Title
    {
        public Title() {}

        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUtc { get; set; }

        public virtual IList<Award> Awards { get; set; }
        public virtual IList<OtherName> OtherNames { get; set; }
        public virtual IList<StoryLine> StoryLines { get; set; }
        public virtual IList<Genre> Genres { get; set; }
        public virtual IList<Credit> Credits { get; set; }

        public static implicit operator Title(Models.Entities.Title entity)
        {
            Dtos.Title result = new Title()
            {
                TitleId = entity.TitleId,
                TitleName = entity.TitleName,
                TitleTypeId = entity.TitleTypeId,
                ReleaseYear = entity.ReleaseYear,
                ProcessedDateTimeUtc = entity.ProcessedDateTimeUtc,
                Awards = entity.Awards.Select(a => new Dtos.Award()
                {
                    Id = a.Id,
                    AwardName = a.Award1,
                    AwardCompany = a.AwardCompany,
                    AwardWon = (a.AwardWon ?? false) ? "Won" : "Nominated",
                    AwardYear = a.AwardYear
                }).ToList(),
                Credits = entity.TitleParticipants.Select(tp => new Dtos.Credit()
                {
                    Id = tp.Id,
                    Name = tp.Participant?.Name ?? "Missing Name",
                    IsKey = tp.IsKey.ToYesOrNo(),
                    IsOnScreen = tp.IsOnScreen.ToYesOrNo(),
                    RoleType = tp.RoleType
                }).ToList(),
                Genres = entity.TitleGenres.Select(tg => new Dtos.Genre()
                {
                    Id = tg.Id,
                    Name = tg.Genre?.Name ?? "Missing Genre"
                }).ToList(),
                OtherNames = entity.OtherNames.Select(o => new Dtos.OtherName()
                {
                    Id = o.Id,
                    TitleName = $"{o.TitleName} ({o.TitleNameLanguage ?? "Unknown"})",
                    TitleNameLanguage = o.TitleNameLanguage,
                    TitleNameType = o.TitleNameType
                }).ToList(),
                StoryLines = entity.StoryLines.Select(s => new Dtos.StoryLine()
                {
                    Id = s.Id,
                    Description = s.Description,
                    Language = s.Language,
                    Type = s.Type
                }).ToList()
            };

            return result;
        }
    }
}
