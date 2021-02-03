using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Marketplace.API.Models
{
    [Table("Award")]
    public partial class Award
    {
        public int TitleId { get; set; }
        public bool? AwardWon { get; set; }
        public int? AwardYear { get; set; }
        [Column("Award")]
        [StringLength(100)]
        public string Award1 { get; set; }
        [StringLength(100)]
        public string AwardCompany { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
