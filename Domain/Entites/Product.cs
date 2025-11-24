using Domain.Comman;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entites
{
    public class Product:BaseAuditableEntity
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; } = null!;
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rating { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(maximumLength: 100)]
        public string Desc { get; set; } = null!;
        public bool InStock { get; set; }
        public int Weight { get; set; }
        //[NotMapped]
        //public List<IFormFile> Images { get; set; } productCreatedto ya vereerm

        public List<ProductImage> ProductImages { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
