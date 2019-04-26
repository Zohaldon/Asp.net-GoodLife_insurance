using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodLife_Asp.Models
{
    public class GoodLife
    {
        [Key]
        public int CustomerId { get; set; }

        [DisplayName("First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }

        [DisplayName("Membership Cost")]
        public decimal MembershipCost { get; set; }

        [DisplayName("Membership Date")]
        [DataType(DataType.Date)]
        public DateTime MembershipDate { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
    }
}
