using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMotorcycle_Creation.Context;
using MyMotorcycle_Creation.Dtos;
using MyMotorcycle_Creation.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMotorcycle_Creation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public MotorcycleController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult CreateMotorcycle(MotorcycleDTO model)
        {
            Motorcycle motorcycle = new()
            {
                Brand = model.Brand,
                Model  = model.Model, 
                ModelYar =model.ModelYar,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };//maplemek
            _context.Motorcycles.Add(motorcycle);
            if (_context.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{motorcycleId}")]
        public ActionResult DeleteMotorcycle([FromRoute] Guid motorcycleId)
        {
            Motorcycle motorcycle = _context.Motorcycles.Find(motorcycleId);
            if (motorcycle != null)
            {
                return Ok(motorcycle);
            }
            return BadRequest();
        }
        [HttpGet("{motorcycleId}")]

        public ActionResult GetAllMotorcycle()
        {
            List<Motorcycle> categories = _context.Motorcycles.ToList();
            if (categories is not null)
            {
                return Ok(categories);
            }
            return BadRequest();
        }

        [HttpPut("{motorcycleId}")]
        public ActionResult UpdateMotorcycle([FromRoute] Guid motorcycleId, MotorcycleDTO model)
        {
            Motorcycle motorcycle = _context.Motorcycles.Find(motorcycleId);
            if (motorcycle is not null)
            {
                return Ok(motorcycle);
            }
            return BadRequest();
        }

        [HttpGet("{motorcycleId}")]
        public ActionResult GetMotorcycleById([FromRoute]Guid motorcycleId) 
        {
            Motorcycle motorcycle = _context.Motorcycles.Find(motorcycleId);
            if (motorcycle is not null)
            {

                return Ok();
            }
            return NotFound();

        }

        [HttpGet]

        public ActionResult GetMotorcycleByCategoryId([FromRoute] Guid categoryId) 
        {
            List<Motorcycle> motorcycles = _context.Motorcycles.Where(x => x.CategoryId == categoryId).ToList();
            {
                if (motorcycles is not null)
                {
                    return Ok(motorcycles);
                }
                return NotFound();
            }
        }

    }
}
