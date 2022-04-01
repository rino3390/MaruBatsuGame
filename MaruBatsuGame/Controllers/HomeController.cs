using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MaruBatsuGame.Models;

namespace MaruBatsuGame.Controllers;
public class HomeController : Controller{
	public IActionResult Index(GameModel? gameModel = null){
		if (gameModel==null){
			gameModel = new GameModel();
		}
		else{
			gameModel.NextTurn();
		}
		return View(gameModel);
	}
}