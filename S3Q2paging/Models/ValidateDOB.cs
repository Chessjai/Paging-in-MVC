using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S3Q2paging.Models
{
    public class ValidateDOB: ValidationAttribute
    {
        public ValidateDOB() : base("{0} invaid dob enter corret ")
        {

        }

        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);
            if (propValue <= DateTime.Now)
                return true;
            else
                return false;
        }
    }
}