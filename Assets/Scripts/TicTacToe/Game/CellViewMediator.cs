using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;

class CellViewMediator : Mediator
{
    [Inject]
    public CellView view { get; set; }

    [Inject]
    public ClickedCellSignal clickedCellSignal { get; set; }

    [Inject]
    public ChangeTurnSignal changeTurnSignal { get; set; }
    
    [Inject]
    public EndgameSignal endgameSignal { get; set; }

    [Inject]
    public ResetSignal resetSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        view.ClickedSignal.AddListener(OnStartButtonSignalDispatched);
        changeTurnSignal.AddListener(OnTurnIsChanging);
        endgameSignal.AddListener(OnGameIsEnding);
        resetSignal.AddListener(OnResetGame);
    }

    private void OnStartButtonSignalDispatched(int idCell)
    {
        clickedCellSignal.Dispatch(idCell);
    }

    private void OnTurnIsChanging(bool isX, int idCell)
    {
        if(view.idCell == idCell){
            view.SetCell(isX?"X":"O");
        }
    }

    private void OnGameIsEnding()
    {
        view.DeactivateButton();
    }

    private void OnResetGame()
    {
        view.Reset();
    }
}