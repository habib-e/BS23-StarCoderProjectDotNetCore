using BS23Assignment.DTOs;
using BS23Assignment.Models;
using BS23Assignment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BS23Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskManagementService _taskManagementService;
        public TaskController()
        {
            _taskManagementService = new TaskManagementService();
        }

        [Authorize]
        [HttpPost("Tasks")]
        public async Task<IActionResult> Create(TaskCreateModel model)
        {
            if (ModelState.IsValid)
            {
                await model.CreateTaskAsync();
                return Ok(new { message = "Data created successfully" });
            }
            return BadRequest(ModelState);
        }

        [HttpGet("AllTasks"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTask()
        {
            var model = new TaskRetrieveModel();
            var data = await model.GetAllTaskAsync();
            return Ok(data);
        }

        [HttpGet("Tasks"), Authorize]
        public async Task<IActionResult> GetUserTasks()
        {
            var userName = UserInfoProvider.GetUserName(HttpContext);

            var model = new TaskRetrieveModel();

            var data = await model.GetUserSpecificTasksAsync(userName!);
            
            return Ok(data);
        }

        [HttpPut("Tasks"), Authorize]
        public async Task<IActionResult> Update([FromQuery]Guid id, TaskCreateModel model)
        {
            var userName = UserInfoProvider.GetUserName(HttpContext);
            
            var userRole = UserInfoProvider.GetUserRole(HttpContext);

            var task = await _taskManagementService.GetTaskByIdAsync(id);

            if (task is not null)
            {
                if (task.CreatedBy == userName || userRole == "Admin")
                {
                    await model.UpdateById(id);
                    return Ok(new { Message = "Successfully Updated" });
                }
                return BadRequest(new { Message = "Permission Denied" });

            }
            return BadRequest(new { Message = "Task not found" });
        }
        
        [HttpDelete("Tasks"), Authorize]
        public async Task<IActionResult> Delete([FromQuery]Guid id)
        {
            var model = new TaskRetrieveModel();
            await model.DeleteByIdAsync(id);
            return Ok(new {Message = "Successfully Deleted"});
        }
    }
}
