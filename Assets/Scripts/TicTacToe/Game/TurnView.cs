using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

class TurnView : View
{
	private Text text;
    public void Init()
    {
        text = gameObject.GetComponentInChildren<Text>(); 
    }

    public void SetTurn(string XO)
    {
        text.text = XO;
    }
}
