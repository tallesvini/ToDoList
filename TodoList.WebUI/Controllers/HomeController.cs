using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebUI.Models;

namespace TodoList.WebUI.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
