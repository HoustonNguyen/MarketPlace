using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Marketplace.API.Models.Entities
{
    [Table("StoryLine")]
    public partial class StoryLine
    {
        public int TitleId { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        [StringLength(100)]
        public string Language { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
