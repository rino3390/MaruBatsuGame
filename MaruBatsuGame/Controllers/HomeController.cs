using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MaruBatsuGame.Models;

namespace MaruBatsuGame.Controllers;

public class HomeController : Controller{
	public IActionResult Index(){
		return View();
	}

	public IActionResult NextStep(int step){
		GameModel.Instance.NextTurn(step);
		return RedirectToAction("Index");
	}

	public IActionResult NewGame(){
		GameModel.Instance.NewGame();
		return RedirectToAction("Index");
	}

	public IActionResult PlayerTime(){
		GameModel.Instance.NewGame();
		GameModel.Instance.playWithCom = false;
		return RedirectToAction("Index");
	}

	public IActionResult ComTime(){
		GameModel.Instance.NewGame();
		GameModel.Instance.playWithCom = true;
		return RedirectToAction("Index");
	}
}