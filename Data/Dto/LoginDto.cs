using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class LoginDto
    {
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public int? Codigo { get; set; }
        public string? Mail { get; set; }
    }
}
