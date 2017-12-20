using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;


class PlayAgainViewMediator : Mediator
{
    [Inject]
    public PlayAgainView view { get; set; }

    [Inject]
    public ResetCommandSignal resetSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        view.ClickedSignal.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        resetSignal.Dispatch();
    }
}
