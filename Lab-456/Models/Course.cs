using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_456.Models
{
    public class Course
    {
        
            public int ID { get; set; }
            public ApplicationUser Lucturer { get; set; }
            [Required]
            public string LucturerID { get; set; }
            [Required]
            [StringLength(255)]
            public string Place { get; set; }
            public DateTime DateTime { get; set; }
            public Category category { get; set; }
            [Required]
            public byte CategoryID { get; set; }
        
    }
    public class Category
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}