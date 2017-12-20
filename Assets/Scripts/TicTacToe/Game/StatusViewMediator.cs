using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;


class StatusViewMediator : Mediator
{
	[Inject]
    public StatusView view { get; set; }
    
    [Inject]
    public MessageSignal messageSignal{get; set;}

    public override void OnRegister()
    {
        base.OnRegister();
        view.Init();
        messageSignal.AddListener(OnMessageReceived);
    }

    private void OnMessageReceived(string message)
    {
        view.SetText(message);
    }
}
