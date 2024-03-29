﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Contacts")]
    public class ContactEntity
    {
        [Key]
        public int ContactId { get; set; }
        [Column("contact_name")]
        [StringLength(maximumLength:20)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birth { get; set; }
    }
}
