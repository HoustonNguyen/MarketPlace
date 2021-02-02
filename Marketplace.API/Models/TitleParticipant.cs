using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Marketplace.API.Models
{
    [Table("TitleParticipant")]
    public partial class TitleParticipant
    {
        [Key]
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int ParticipantId { get; set; }
        public bool IsKey { get; set; }
        [StringLength(100)]
        public string RoleType { get; set; }
        public bool IsOnScreen { get; set; }

        [ForeignKey(nameof(ParticipantId))]
        [InverseProperty("TitleParticipants")]
        public virtual Participant Participant { get; set; }
        [ForeignKey(nameof(TitleId))]
        [InverseProperty("TitleParticipants")]
        public virtual Title Title { get; set; }
    }
}
