using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GameModel : IGameModel
{
    private IList<ICellModel> _cells;
    private Mark _markTurn;

    private int _movementsCounter;

    readonly private int[][] _possibleCombos = new int[][] {
        new int[] { 0, 1, 2 },
        new int[] { 3, 4, 5 },
        new int[] { 6, 7, 8 },
        new int[] { 0, 3, 6 },
        new int[] { 1, 4, 7 },
        new int[] { 2, 5, 8 },
        new int[] { 0, 4, 8 },
        new int[] { 6, 4, 2 },
    };

    public GameModel()
    {
        _cells = new List<ICellModel>()
        {
            new CellModel(),
            new CellModel(),
            new CellModel(),
            new CellModel(),
            new CellModel(),
            new CellModel(),
            new CellModel(),
            new CellModel(),
            new CellModel()
        };
    }

    public IList<ICellModel> Cells
    {
        get
        {
            return _cells;
        }
    }

    public bool IsXTurn
    {
        get
        {
            return _markTurn == Mark.X;
        }
    }

    public void ClickCell(int nCell)
    {
        _cells.ElementAt(nCell).Click(_markTurn);
        _markTurn = _markTurn == Mark.X ? Mark.O : Mark.X;
        _movementsCounter++;
    }

    public void Reset()
    {
        _markTurn = Mark.X;
        _movementsCounter = 0;
        foreach (ICellModel cell in _cells)
        {
            cell.Reset();
        }
    }

    public GameState IsGameOver()
    {

        foreach (int[] combo in _possibleCombos)
        {
            if (_cells[combo[0]].Mark != Mark.N && ( _cells[combo[1]].Mark != Mark.N) && (_cells[combo[2]].Mark != Mark.N))
            {
                if (_cells[combo[0]].Mark == _cells[combo[1]].Mark && (_cells[combo[0]].Mark == _cells[combo[2]].Mark))
                {
                    if (_cells[combo[0]].Mark == Mark.X)
                        return GameState.XWin;
                    else
                        return GameState.OWin;
                }
            }
        }

        if (_movementsCounter >= 9)
            return GameState.Tie;

        return GameState.NotOver;
    }
}
