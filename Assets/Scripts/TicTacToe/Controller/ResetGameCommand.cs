using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.command.impl;
using UnityEngine;

public class ResetGameCommand : Command
{

    [Inject]
    public IGameModel gridModel { get; set; }

    [Inject]
    public MessageSignal messageSignal { get; set; }

    [Inject]
    public ResetSignal resetSignal { get; set; }

    public override void Execute()
    {
        gridModel.Reset();
        resetSignal.Dispatch();
        messageSignal.Dispatch("New Game");
    }
}
