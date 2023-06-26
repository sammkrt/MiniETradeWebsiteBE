using EticaretAPI.Application.Abstractions;
using EticaretAPI.Application.Repositories.CustomerRepositories;
using EticaretAPI.Application.Repositories.OrderRepositories;
using EticaretAPI.Application.Repositories.ProductRepositories;
using EticaretAPI.Domain.Entities;
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
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;
        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }


        //[HttpGet]
        //public async Task GetAsync()
        //{
        //    var customerId = Guid.NewGuid();
        //    await _customerWriteRepository.AddAsync(new() { Name = "Ali" , Id = customerId});
        //    await _orderWriteRepository.AddAsync(new() { Description = "bla bla", Address = "Ankara", CustomerId = customerId   });
        //    await _orderWriteRepository.AddAsync(new() { Description = "bla bla", Address = "Istabul", CustomerId = customerId   });
        //    await _orderWriteRepository.SaveAsync();

        //}

        [HttpGet]
        public async Task GetOrder()
        {
            var order = await _orderReadRepository.GetByIdAsync("02fdb59d-8ad5-4dfa-7211-08db7651df98");
            order.Address = "Mersin";
            _orderWriteRepository.SaveAsync();

        }

      


    }
}
