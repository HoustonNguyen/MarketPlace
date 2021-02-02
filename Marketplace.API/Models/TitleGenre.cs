using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Marketplace.API.Models
{
    [Table("TitleGenre")]
    public partial class TitleGenre
    {
        [Key]
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        [InverseProperty("TitleGenres")]
        public virtual Genre Genre { get; set; }
        [ForeignKey(nameof(TitleId))]
        [InverseProperty("TitleGenres")]
        public virtual Title Title { get; set; }
    }
}
