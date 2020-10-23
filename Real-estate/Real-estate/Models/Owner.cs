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
        [Display(Name = "Owner Number")]
        public string OwnerNo { get; set; }

        [Display(Name = "First Number")]
        public string Fname { get; set; }

        [Display(Name = "Last Namer")]
        public string Lname { get; set; }

        public string Address { get; set; }

        [Display(Name = "Telephone Number")]
        public string TellNo { get; set; }

        public virtual List<Rent> Rent { get; set; }

    }
}