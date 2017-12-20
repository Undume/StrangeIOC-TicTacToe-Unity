using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.command.impl;
using UnityEngine;

public class SelectCellCommand : Command
{

    [Inject]
    public IGameModel gameModel { get; set; }

    [Inject]
    public int idCell { get; set; }

    [Inject]
    public ChangeTurnSignal changeTurnSignal{get; set;}
    [Inject]
    public MessageSignal messageSignal{get; set;}
    [Inject]
    public EndgameSignal endgameSignal{get; set;}

    public override void Execute()
    {
    	if(!gameModel.Cells.ElementAt(idCell).IsClicked)
    	{
    		changeTurnSignal.Dispatch(gameModel.IsXTurn,idCell);
    		gameModel.ClickCell(idCell);
    	}
    	else
    	{
    		messageSignal.Dispatch("Try Again");
    		return;
    	}

    	switch(gameModel.IsGameOver())
    	{
    		case GameState.NotOver:
    			messageSignal.Dispatch((gameModel.IsXTurn?"X":"O")+" plays");
    		break;
    		case GameState.XWin:
    			messageSignal.Dispatch("X Wins!");
    			endgameSignal.Dispatch();
    		break;
    		case GameState.OWin:
    			messageSignal.Dispatch("O Wins!");
    			endgameSignal.Dispatch();
    		break;
    		case GameState.Tie:
    			messageSignal.Dispatch("Both losers");
    			endgameSignal.Dispatch();
    		break;
    	}

    }
}
