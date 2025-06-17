using Microsoft.AspNetCore.Mvc;
using TaskMasterAPI.Interfaces.Services;
using TaskMasterAPI.Models.Entities;

namespace TaskMasterAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // Simulação de userId fixo (substituir por auth futuramente)
    private int GetUserId() => 1;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _taskService.GetAllUserTasksAsync(GetUserId());
        if (!result.Success) return BadRequest(result.ErrorMessage);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _taskService.GetTaskAsync(id, GetUserId());
        if (!result.Success) return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        var result = await _taskService.CreateTaskAsync(task, GetUserId());
        if (!result.Success) return BadRequest(result.ErrorMessage);
        return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result.Data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TaskItem task)
    {
        var result = await _taskService.UpdateTaskAsync(id, task, GetUserId());
        if (!result.Success) return BadRequest(result.ErrorMessage);
        return Ok(result.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _taskService.DeleteTaskAsync(id, GetUserId());
        if (!result.Success) return BadRequest(result.ErrorMessage);
        return NoContent();
    }
}

