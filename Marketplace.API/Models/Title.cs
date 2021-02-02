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
        public Title()
        {
            Awards = new HashSet<Award>();
            OtherNames = new HashSet<OtherName>();
            StoryLines = new HashSet<StoryLine>();
            TitleGenres = new HashSet<TitleGenre>();
            TitleParticipants = new HashSet<TitleParticipant>();
        }

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

        [InverseProperty(nameof(Award.Title))]
        public virtual ICollection<Award> Awards { get; set; }
        [InverseProperty(nameof(OtherName.Title))]
        public virtual ICollection<OtherName> OtherNames { get; set; }
        [InverseProperty(nameof(StoryLine.Title))]
        public virtual ICollection<StoryLine> StoryLines { get; set; }
        [InverseProperty(nameof(TitleGenre.Title))]
        public virtual ICollection<TitleGenre> TitleGenres { get; set; }
        [InverseProperty(nameof(TitleParticipant.Title))]
        public virtual ICollection<TitleParticipant> TitleParticipants { get; set; }
    }
}
