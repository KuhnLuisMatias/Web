﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Productos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        [NotMapped]
        public IFormFile? Imagen_Archivo { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }
    }
}
