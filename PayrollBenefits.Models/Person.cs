using System;
using System.ComponentModel.DataAnnotations;

namespace PayrollBenefits.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [Required, MaxLength(150)]
        public string LastName { get; set; }
        public int? Age { get; set; }
    }
}
