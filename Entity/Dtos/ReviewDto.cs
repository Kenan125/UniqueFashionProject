namespace Entity.Dtos
{
    public class ReviewDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int SellerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        //public virtual ProductDto Product { get; set; }
        //public virtual UserDto User { get; set; }
        //public virtual Seller Seller { get; set; }
    }
}
