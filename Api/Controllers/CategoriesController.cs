using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoriesController(IGenericRepository<Category> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {
            var categories = await _repository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
