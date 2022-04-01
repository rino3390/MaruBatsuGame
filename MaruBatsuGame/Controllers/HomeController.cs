using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MaruBatsuGame.Models;

namespace MaruBatsuGame.Controllers;
public class HomeController : Controller{
	public IActionResult Index(){
		
		var	gameModel = new GameModel();
		
		return View(gameModel);
	}
	[HttpPost]
	public IActionResult Index(GameModel gameModel){
		gameModel.NextTurn();
		return View(gameModel);
	}
}