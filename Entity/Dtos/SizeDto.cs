using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class SizeDto : BaseDto
    {
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
