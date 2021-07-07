using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Thinktecture.Webinars.Porter.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private static readonly Product[] Products = new Product[]
        {
            new Product { Id = Guid.Parse("e5195b9c-de85-43be-9abf-e549831249e9"), Name = "Milk", Price = .79 },
            new Product { Id = Guid.Parse("b261da7e-a801-4799-ab5d-e40b3662be4f"), Name = "Beer", Price = 2.99 },
            new Product { Id = Guid.Parse("ea0e4efc-fc4f-4f1e-a90c-0f7af3064aca"), Name = "Soda", Price = 1.39 },
            new Product { Id = Guid.Parse("db214215-e11f-4b7d-a00e-f0d13ea1d5b4"), Name = "Water", Price = .99 },
            new Product { Id = Guid.Parse("10fd4ef6-a314-4f08-9cee-74b33f2dec97"), Name = "Gin", Price = 4.59 },
            new Product { Id = Guid.Parse("2a5e3177-02ed-41a0-b988-ca41c154d153"), Name = "Rum", Price = 5.79 },
            new Product { Id = Guid.Parse("51bdc32c-596e-4c22-b3c4-e1b2509a8c9e"), Name = "Whiskey", Price = 9.99 },
            new Product { Id = Guid.Parse("7d3c8d8e-dd44-4057-a473-277d2b5c6b9c"), Name = "Wine", Price = 8.29 }
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products.OrderBy(p=>p.Name);
        }

        [HttpGet("{id:guid}")]
        public Product GetById([FromRoute]Guid id)
        {
            return Products.FirstOrDefault(p=>p.Id==id);
        }
    }
}
