using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

class StatusView : View
{
	private Text text;
    public void Init()
    {
        text = gameObject.GetComponentInChildren<Text>(); 
    }

    public void SetText(string message)
   	{
   		text.text = message;
   	}
}
