using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_estate.Models
{
    [Table("Branch_tbl")]
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        //[Display(Name="Branch Number")]
        public string BranchNo { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }

        public virtual List<Staff> Staff { get; set; }
        public virtual List<Rent>Rent { get; set; }

    }
}