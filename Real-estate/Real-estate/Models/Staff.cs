using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_estate.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Display(Name="Staff Number")]
        public string StaffNo { get; set; }

        [Display(Name="First Name")]
        public string Fname { get; set; }

        [Display(Name="Last Name")]
        public string Lname { get; set; }

        public string Position { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName ="date")]
        [Display(Name="Date Of Birth")]
        public DateTime DOB { get; set; }

        public int Salary { get; set; }

        [ForeignKey("Branch")]
        [Display(Name="Branch Number")]
        public string Branch_BranchNoRef { get; set; }
       // public Branch Branch { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual List<Rent> Rent { get; set; }

    }
}