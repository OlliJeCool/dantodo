using Microsoft.AspNetCore.Mvc;
using ToDoDan.Data;
using ToDoDan.Models;

namespace ToDoDan.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ToDoDanDbContext _context;
    public TaskController(ToDoDanDbContext context)
    {
        _context = context;
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] CreateTaskVm model)
    {
        _context.Items.Add(new Item
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description,
            CreatedDate = DateTime.UtcNow,
            Complete = false
        });
        _context.SaveChanges();
        return Ok();
    }

    [HttpPost("delete")]
    public IActionResult Delete([FromBody] DeleteTaskVm model)
    {
        var item = _context.Items.SingleOrDefault(x => x.Id == model.Id);
        if (item == null)
            return BadRequest();
        _context.Items.Remove(item);
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet("GetTasks")]
    public IActionResult GetTasks()
    {
        return Ok(_context.Items.ToArray());
    }

    [HttpPost("complete")]
    public IActionResult Complete([FromBody] CompleteTaskVm model)
    {
        var item = _context.Items.SingleOrDefault(x => x.Id == model.Id);
        if (item == null)
            return BadRequest();
        item.Complete = true;
        _context.Update(item);
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet("GetTask/Id/{id}")]
    public IActionResult GetTaskById([FromRoute] Guid id)
    {
        return Ok(_context.Items.SingleOrDefault(item => item.Id == id));
    }

    [HttpGet("GetTask/{name}")]
    public IActionResult GetTaskByName([FromRoute] string name)
    {
        return Ok(_context.Items.SingleOrDefault(item => item.Name == name));
    }
}