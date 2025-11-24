using Domain.Comman;

namespace Domain.Entites
{
    public class ProductImage:BaseEntity
    {
        public string Url { get; set; } = null!;
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
