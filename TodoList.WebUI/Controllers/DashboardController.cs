using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTOs;
using TodoList.Application.Interfaces;

namespace TodoList.WebUI.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IToDoListService _toDoListService;

        public DashboardController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{
            var toDoListDTO = await _toDoListService.GetAllToDoListAsync();
            return View(toDoListDTO);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(ToDoListDTO toDo)
        {
            try
            {
                await _toDoListService.CreateToDoListAsync(toDo);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

		[HttpGet]
		public async Task<IActionResult> Status()
		{
			var toDoListDTO = await _toDoListService.GetAllToDoListAsync();
			return View(toDoListDTO);
		}
	}
}
