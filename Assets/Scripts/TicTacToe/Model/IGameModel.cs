using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum GameState { NotOver, XWin, OWin, Tie };

public interface IGameModel
{
    
    IList<ICellModel> Cells { get; }
    void Reset();
    void ClickCell(int nCell);
    bool IsXTurn { get; }
    GameState IsGameOver();
}
