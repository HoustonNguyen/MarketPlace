using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Marketplace.API.Models
{
    [Table("Title")]
    public partial class Title
    {
        public Title() {}

        [Key]
        public int TitleId { get; set; }
        [StringLength(100)]
        public string TitleName { get; set; }
        [StringLength(100)]
        public string TitleNameSortable { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        [Column("ProcessedDateTimeUTC", TypeName = "datetime")]
        public DateTime? ProcessedDateTimeUtc { get; set; }

        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<OtherName> OtherNames { get; set; }
        public virtual ICollection<StoryLine> StoryLines { get; set; }
        public virtual ICollection<TitleGenre> TitleGenres { get; set; }
        public virtual ICollection<TitleParticipant> TitleParticipants { get; set; }
    }
}
