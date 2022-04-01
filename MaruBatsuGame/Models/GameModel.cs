namespace MaruBatsuGame.Models;

public class GameModel{
	public GameModel(){
		for (var _i = 0; _i < maruBatsu.Length; _i++){
			maruBatsu[_i] = -1;
		}
		stat = GameStat.Gaming;
	}

	public int[] maruBatsu = new int[9];
	public string[] maruBatsuText = new string[9];

	public int turn = 0;
	public GameStat stat;
	public int place;
	public bool IsGameOver(){
		return maruBatsu.All(x => x != -1);
	}

	public bool IsWin(){
		return winRole.Any(_i => _i.All(x => x is 1 or 0));
	}

	public void NextTurn(){
		maruBatsu[place] = turn;
		maruBatsuText[place] = turn == 0 ? "O" : "X";
		if (IsWin()){
			stat = turn == 0 ? GameStat.Maru : GameStat.Batsu;
		}

		if (IsGameOver()){
			stat = GameStat.Draw;
		}
		turn = 1 - turn;
	}

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

	public enum GameStat{
		Gaming= 0,
		Maru = 1,
		Batsu=2,
		Draw=3
	}
}