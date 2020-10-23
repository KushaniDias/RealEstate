using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_estate.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Display(Name = "Property Number")]
        public string PropertyNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        [Display(Name = "Property Type")]
        public string Ptype { get; set; }
        public int Rooms { get; set; }

        [Display(Name = "Owner Number")]
        [ForeignKey("Owner")]
        public string RefOwnerNoRef { get; set; }
        public virtual Owner Owner { get; set; }

        [Display(Name = "Staff Number")]
        [ForeignKey("Staff")]
        public string RefStaffNoRef { get; set; }
        public virtual Staff Staff { get; set; }

        [Display(Name = "Branch Number")]
        [ForeignKey("Branch")]
        public string REfBranchNoRef { get; set; }
        public virtual Branch Branch { get; set; }

        [Display(Name = "Rent")]
        public int rent1 { get; set; }



    }
}