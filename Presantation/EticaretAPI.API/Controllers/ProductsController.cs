﻿using EticaretAPI.Application.Abstractions;
using EticaretAPI.Application.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EticaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;

        private readonly IProductWriteRepository _productWriteRepository;
        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }


        [HttpGet]
        public async Task GetAsync()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 1", CreatedDate = DateTime.Now, Stock = 10 },
                new() {Id = Guid.NewGuid(), Name = "Product 2", CreatedDate = DateTime.Now, Stock = 20 },
                new() {Id = Guid.NewGuid(), Name = "Product 3", CreatedDate = DateTime.Now, Stock = 30 },
            });
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }



    }
}
