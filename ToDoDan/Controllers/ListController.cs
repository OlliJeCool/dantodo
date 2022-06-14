using Microsoft.AspNetCore.Mvc;
using ToDoDan.Data;
using ToDoDan.Models;

namespace ToDoDan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController : ControllerBase
    {
        private readonly ToDoDanDbContext _context;
        public ListController(ToDoDanDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateListVm model)
        {
            foreach(Guid id in model.Ids)
            {
                _context.Lists.Add(new TaskList()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    TaskId = id
                });
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] DeleteListVm model)
        {
            var group = _context.Lists.Where(l => l.Id == model.Id).ToList();
            foreach (var item in group)
            {
               _context.Lists.Remove(item);
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("getlist/{id}")]
        public IActionResult GetList([FromRoute] Guid id)
        {
            var list = _context.Lists.Where(x => x.Id == id).ToArray();
            if(list is null) return NotFound();
            return Ok(list);
        }

    }
}
