namespace Entity.Dtos
{
    public class CardInfoDto : BaseDto
    {
        public int UserId { get; set; }  // Link to the user who owns the card
        public string MaskedCardNumber { get; set; }  // e.g., **** **** **** 1234
        public string CardholderName { get; set; }
        public string ExpirationDate { get; set; }  // Just the month and year

        public UserDto User { get; set; }
    }
}
