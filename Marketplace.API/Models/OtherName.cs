using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Marketplace.API.Models
{
    [Table("OtherName")]
    public partial class OtherName
    {
        public int? TitleId { get; set; }
        [StringLength(100)]
        public string TitleNameLanguage { get; set; }
        [StringLength(100)]
        public string TitleNameType { get; set; }
        [StringLength(100)]
        public string TitleNameSortable { get; set; }
        [StringLength(100)]
        public string TitleName { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(TitleId))]
        [InverseProperty("OtherNames")]
        public virtual Title Title { get; set; }
    }
}
