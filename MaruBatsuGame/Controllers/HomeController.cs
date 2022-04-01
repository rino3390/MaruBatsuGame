using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MaruBatsuGame.Models;

namespace MaruBatsuGame.Controllers;

public class HomeController : Controller{
	public IActionResult Index(){
		return View();
	}

}