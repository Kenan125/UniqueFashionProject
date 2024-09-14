namespace Entity.Dtos
{
    public class CartDto : BaseDto
    {
        public int UserId { get; set; }  // Foreign key to the user       
        public UserDto User { get; set; }  // Navigation property
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
