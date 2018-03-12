using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Payment
    {
        [Required]
        [RegularExpression(@"^[0-9]{6}", ErrorMessage = "Invalid BsbNumber.")]
        [StringLength(6)]
        public string BsbNumber { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{9}", ErrorMessage = "Invalid Account Number.")]
        [StringLength(9)]

         public string AccountNumber { get; set; }

        [Required]
        public string AccountName { get; set; }

        public string Reference { get; set; }

        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage ="Amount cannot be  zero.")]
        public double Amount { get; set; }
    }
}
