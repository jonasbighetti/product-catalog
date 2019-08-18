using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Models;
using ProductCatalog.API.Repositories;
using System.Collections.Generic;

namespace ProductCatalog.API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/categories")]
        [HttpGet]
        [ResponseCache(Duration = 3600)]
        public IEnumerable<Category> Get()
        {
            return _repository.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _repository.GetProducts(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            _repository.Save(category);

            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category)
        {
            _repository.Update(category);

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody]Category category)
        {
            _repository.Delete(category);

            return category;
        }
    }
}