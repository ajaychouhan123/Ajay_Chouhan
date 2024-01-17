using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ajaychouhan1.Model
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [WithMany("Category")]
        public ICollection<Product> Products { get; set; }
    }
}