using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;

class TurnViewMediator : Mediator
{
	[Inject]
    public TurnView view { get; set; }

    [Inject]
    public ChangeTurnSignal changeTurnSignal { get; set; }

    [Inject]
    public ResetSignal resetSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        changeTurnSignal.AddListener(OnTurnIsChanging);
        resetSignal.AddListener(OnReset);
    }

    private void OnTurnIsChanging(bool isX, int idCell)
    {
        view.SetTurn(isX?"O":"X");
    }

    private void OnReset()
    {
        view.SetTurn("X");
    }
}
