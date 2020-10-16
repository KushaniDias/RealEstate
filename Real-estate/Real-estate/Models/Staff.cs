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
        public String StaffNo { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Position { get; set; }

        public DateTime DOB { get; set; }

        public int Salary { get; set; }

        [ForeignKey("Branch")]
        public String Branch_BranchNoRef { get; set; }
        public Branch Branch { get; set; }
    }
}