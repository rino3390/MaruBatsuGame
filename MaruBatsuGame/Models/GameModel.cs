﻿namespace MaruBatsuGame.Models;

public class GameModel{
#region Enums
	public enum GameStat{
		Gaming = 0,
		Maru = 1,
		Batsu = 2,
		Draw = 3
	}
#endregion

#region Variables
	public static GameModel Instance = new();

	public int[] maruBatsu = new int[9];
	public string[] maruBatsuText;

	public int turn;
	public GameStat stat;
	public bool playWithCom = true;
	public bool playerFirst = true;

	private readonly int[][] winRole = {
		new int[] {0, 1, 2},
		new int[] {3, 4, 5},
		new int[] {6, 7, 8},
		new int[] {0, 3, 6},
		new int[] {1, 4, 7},
		new int[] {2, 5, 8},
		new int[] {0, 4, 8},
		new int[] {2, 4, 6}
	};
#endregion

#region Constructor
	public GameModel(){
		NewGame();
	}
#endregion

#region Methods
	public void ComTurn(){
		foreach (var _role in winRole){
			if (!_role.Any(x => maruBatsu[x] is 0 or 1)) continue;

			if (maruBatsu[_role[0]] == maruBatsu[_role[1]] && maruBatsu[_role[2]] == -1){
				NextTurn(_role[2]);
				return;
			}

			if (maruBatsu[_role[1]] == maruBatsu[_role[2]] && maruBatsu[_role[0]] == -1){
				NextTurn(_role[0]);
				return;
			}

			if (maruBatsu[_role[0]] != maruBatsu[_role[2]] || maruBatsu[_role[1]] != -1) continue;

			NextTurn(_role[1]);
			return;
		}

		var _place = Enumerable.Range(0, maruBatsu.Count()).Where(x => maruBatsu[x] == -1).ToList();
		var _random = new Random();
		NextTurn(_place[_random.Next(_place.Count)]);
	}

	public bool IsGameOver(){
		return maruBatsu.All(x => x != -1) || IsWin();
	}

	public bool IsWin(){
		return winRole.Any(_i => _i.All(x => maruBatsu[x] is 1) || _i.All(x => maruBatsu[x] is 0));
	}

	public void NewGame(){
		for (var _i = 0; _i < maruBatsu.Length; _i++){
			maruBatsu[_i] = -1;
		}

		stat = GameStat.Gaming;
		maruBatsuText = new string[9];
		turn = 0;
	}

	public void NextTurn(int step){
		if (IsGameOver()|| maruBatsu[step]!=-1) return;

		maruBatsu[step] = turn;
		maruBatsuText[step] = turn == 0 ? "O" : "X";

		if (IsWin()){
			stat = turn == 0 ? GameStat.Maru : GameStat.Batsu;
		}

		else if (IsGameOver()){
			stat = GameStat.Draw;
		}

		turn = 1 - turn;

		if (turn == 1 && playerFirst && playWithCom && !IsGameOver()){
			ComTurn();
		}
	}
#endregion
}