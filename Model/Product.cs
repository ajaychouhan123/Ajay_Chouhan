using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ajaychouhan1.Model
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("Id")]
        [JsonIgnore]
        public Category Category { get; set; }

        [WithMany("Product")]
        public ICollection<DemoProduct> DemoProducts { get; set; }
    }
}