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
        public String BranchNo { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }

    }
}