using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyMotorcycle_Creation.Context;
using MyMotorcycle_Creation.Dtos;
using MyMotorcycle_Creation.Entities;

namespace MyMotorcycle_Creation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryDTO model)
        {
            Category category = new()
            {
                CategoryName = model.CategoryName,
                CategoryDescription = model.CategoryDescription,

            };//maplemek
            _context.Categories.Add(category);
            if (_context.SaveChanges() > 0)
            {
                return Ok();
            }  
            return BadRequest();
        }

        [HttpDelete("{catgoryId}")]
        public ActionResult DeleteCategory([FromRoute]Guid categoryId)
        {
            Category category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpGet("{categoryId}")]

        public ActionResult GetAllCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            if (categories is not null)
            {
                return Ok(categories);
            }
            return BadRequest();
        }

        [HttpPut("{categoryId}")]
        public ActionResult UpdateCategory([FromRoute] Guid categoryId, CategoryDTO model)
        {
            Category category = _context.Categories.Find(categoryId);
            if (category is not null)
            {
                return Ok(category);
            }
            return BadRequest();

            
        }

    }
}
