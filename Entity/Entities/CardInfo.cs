using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class CardInfo : BaseEntity
    {
        public int UserId { get; set; }  // Link to the user who owns the card
        public string? MaskedCardNumber { get; set; }  // e.g., **** **** **** 1234
        public string? CardholderName { get; set; }
        public string? ExpirationDate { get; set; }  // Just the month and year

        public AppUser User { get; set; }

    }
}
