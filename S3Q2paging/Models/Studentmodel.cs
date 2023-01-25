using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace S3Q2paging.Models
{
    [Table("paginationQ2")]
    public class Studentmodel
    {
        [Key]
        public int id { get; set; }

        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Invalid Format")]
        [Required(ErrorMessage = "You Cannot leave this feild empty")]
        [MaxLength(50)]
        public string name { get; set; }

        public int age { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = " {0:dd/MM/yyyy }", ApplyFormatInEditMode = true)]
        [ValidateDOB]
        [Required]
        public DateTime dob { get; set; }

        public Nullable<System.DateTime> created_on { get; set; }

        public Nullable<System.DateTime> update_on { get; set; }

        public long create_by { get; set; }

        public long updated_by { get; set; }
    }
}