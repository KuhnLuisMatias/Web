﻿using API.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly ProductosServices _services;
        public ProductosController()
        {
            _services = new ProductosServices();
        }
        
        [HttpGet]
        [Route("BuscarProductos")]
        public async Task<List<Productos>> BuscarProductos()
        {
            return await _services.BuscarLista();
        }

        [HttpPost]
        [Route("GuardarProducto")]
        public async Task<List<Productos>> GuardarProducto(Productos producto)
        {
            return await _services.Guardar(producto);
        }
    }
}