using Domain.Comman;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
