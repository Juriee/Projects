using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
      
        public DateTime BirthDate { get; set; }
        public MembershipType MembershipType { get; set; }
      
        public byte MembershipTypeId { get; set; }
    }
}