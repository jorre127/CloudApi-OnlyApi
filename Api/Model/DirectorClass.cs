using System;
using System.ComponentModel.DataAnnotations;

namespace ApiTest
{
    public class DirectorClass
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Range(0, 120)]
        public int Age { get; set; }

        public int id { get; set; }
    }
}
