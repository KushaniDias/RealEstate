using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_estate.Models
{
    [Table("Owner_tbl")]
    public class Owner
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String OwnerNo { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Address { get; set; }

        public string TellNo { get; set; }

    }
}