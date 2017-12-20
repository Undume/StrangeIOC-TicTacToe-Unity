using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;


public class TicTacToeBootstrap : ContextView
{

    void Awake()
    {
        context = new TicTacToeContext(this);
    }

}