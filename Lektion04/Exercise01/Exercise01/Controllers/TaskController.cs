using Exercise01.Models.DTOs;
using Exercise01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercise01.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class TaskController : ControllerBase
        {
                private readonly ITaskService _taskService = new TaskService();

                [HttpGet("/")]
                public IActionResult Index()
                {
                        return Ok();
                }
                [HttpGet("api/tasks")]
                public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
                {
                        return Ok(_taskService.GetAllAsync());
                }
                [HttpGet("api/tasks/{id}")]
                public async Task<ActionResult<TaskDto>> GetTask(string id)
                {
                        var task = await _taskService.GetByIdAsync(id);
                        if (task == null) return NotFound();
                        return Ok(task);
                }
                [HttpPost("tasks")]
                public async Task<ActionResult<TaskDto>> PostTask([FromBody] CreateTaskDto dto)
                {
                        var newDto = await _taskService.CreateTaskAsync(dto);

                        return CreatedAtAction(nameof(GetTask), new {id = newDto.Id }, newDto);
                }
                [HttpPut("api/tasks/{id}")]
                public async Task<IActionResult> UpdateTask(string id, [FromBody] UpdateTaskDto dto)
                {
                        var updated = await _taskService.UpdateTaskAsync(id, dto);
                        if (updated == null) return NotFound();
                        return NoContent();
                }
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteTask(string id)
                {
                        bool deleted = await _taskService.DeleteTaskAsync(id);
                        if(deleted) return NoContent();
                        else return NotFound();
                }

        }
}