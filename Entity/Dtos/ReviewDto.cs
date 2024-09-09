
using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class ReviewDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public virtual ProductDto Product { get; set; }
        public virtual UserDto User { get; set; }
    }
}
