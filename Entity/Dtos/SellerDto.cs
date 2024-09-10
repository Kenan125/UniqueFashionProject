using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class SellerDto : BaseDto
    {
        public string Name { get; set; }
        public Guid? UserId { get; set; }

        public UserDto User { get; set; }
        public ICollection<ProductDto> Products { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}
