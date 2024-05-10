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
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskPost(ToDoListDTO toDo)
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
		public async Task<IActionResult> StatusTask()
		{
			var toDoListDTO = await _toDoListService.GetAllToDoListAsync();
			return View(toDoListDTO);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateTask(Guid Id)
		{
			ToDoListDTO? toDoList = await _toDoListService.GetToDoListByIdAsync(Id);
			return View(toDoList);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateTaskPost(ToDoListDTO toDoList)
		{
			await _toDoListService.UpdateToDoListAsync(toDoList);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteTask(Guid id)
        {
			return View(id);
        }

        [HttpPost]
		public async Task<IActionResult> DeleteTaskPost(Guid id)
		{
			await _toDoListService.DeleteToDoListAsync(id);
			return RedirectToAction("Index", "Home");
		}


		[HttpGet]
		public async Task<IActionResult> DeleteAllTask()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteAllTaskPost()
		{
			await _toDoListService.DeleteAllToDoListAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
