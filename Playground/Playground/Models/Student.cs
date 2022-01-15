using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Models
{
    public class Student
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(15, 70)]
        public int Age { get; set; }

        [Required]
        [MinLength(5)]
        public string Country { get; set; }
    }
}
