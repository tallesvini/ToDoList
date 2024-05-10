using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebUI.Controllers
{
	[Route("Error")]
	public class ErrorStatusCodeController : Controller
	{

		[Route("/Error/404")]
		public IActionResult Error404()
		{
			return View("NotFound");
		}

		[Route("/Error/500")]
		public IActionResult Error500()
		{
			return View("InternalError");
		}
	}
}
