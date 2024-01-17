using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ajay_chouhan.Model
{
    public class DemoProduct
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("Id")]
        [JsonIgnore]
        public Product Product { get; set; }
    }
}