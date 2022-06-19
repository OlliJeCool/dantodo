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
            _context.Lists.Add(new TaskList()
            {
                Id = Guid.NewGuid(),
                Name = model.Name
            });
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] DeleteListVm model)
        {
            var lists = _context.Lists.SingleOrDefault(x => x.Id == model.Id);
            if (lists == null) return BadRequest();
            var items = _context.Items.Where(x => x.ListId == model.Id).ToList();
            foreach (var item in items)
            {
                item.ListId = _context.Lists.SingleOrDefault(x => x.Name == "MainList").Id;
                _context.Update(item);
            }
            _context.Lists.Remove(lists);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("getlist/{id}")]
        public IActionResult GetList([FromRoute] Guid id)
        {
            return Ok(_context.Items.Where(x => x.ListId == id));
        }

        [HttpGet("getAll")]
        public IActionResult GetAllLists()
        {
            return Ok(_context.Lists.ToList());
        }

        [HttpPost("add")]
        public IActionResult AddToList([FromBody] AddTaskToListVm model)
        {
            foreach (Guid id in model.Ids)
            {
                var item = _context.Items.SingleOrDefault(x => x.Id == id);
                item.ListId = model.ListId;
                _context.Update(item);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
