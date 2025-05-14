using Microsoft.AspNetCore.Mvc;
using FruitApi.Data;
using FruitApi.Models;
using System.Linq;

namespace FruitApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase {
        private readonly FruitContext _context;

        public FruitController(FruitContext context) {
            _context = context;
            
            // seed initial fruit
            if (!_context.Fruits.Any()) {
                _context.Fruits.AddRange(
                    new Fruit("Apple", "Fruit", 100, 50),
                    new Fruit("Banana", "Fruit", 50, 30),
                    new Fruit("Mango", "Fruit", 120, 20)
                );
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fruit>> Get()
        {
            return Ok(_context.Fruits.ToList());
        }

        [HttpPost]
        public ActionResult<Fruit> Post([FromBody] Fruit fruit) {
            _context.Fruits.Add(fruit);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = fruit.Id }, fruit);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Fruit updatedFruit) {
            var existingFruit = _context.Fruits.FirstOrDefault(f => f.Id == id);
            if (existingFruit == null)
                return NotFound();
            
            existingFruit.Name = updatedFruit.Name;
            existingFruit.Type = updatedFruit.Type;
            existingFruit.Price = updatedFruit.Price;
            existingFruit.Stock = updatedFruit.Stock;

            _context.SaveChanges();
            return Ok(existingFruit);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var fruit = _context.Fruits.FirstOrDefault(f => f.Id = id);
            if (fruit == null)
                return NotFound();

            _context.Fruits.Remove(fruit);
            _context.SaveChanges();
            return Ok(fruit);
        }
    }
}