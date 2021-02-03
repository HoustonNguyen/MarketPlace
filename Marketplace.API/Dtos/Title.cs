using System;
using System.Collections.Generic;

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
    }
}
