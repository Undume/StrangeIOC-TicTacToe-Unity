using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class CellView : View
{
    public int idCell;

    public Signal<int> ClickedSignal = new  Signal<int> {};

    private Button button;
    private Text text;
    private Animation anim;

    public void Init()
    {
        button = gameObject.GetComponent<Button>(); 
        button.onClick.AddListener(Clicked);
        text = gameObject.GetComponentInChildren<Text>();
        anim = gameObject.GetComponent<Animation>(); 
    }

    public void Clicked()
    {
        ClickedSignal.Dispatch(idCell);
    }

    public void SetCell(string XO)
    {
        text.text = XO;
        anim.Play("GridAnim");
    }

    public void DeactivateButton()
    {
        button.interactable = false;
    }

    public void Reset()
    {
        button.interactable = true;
        text.text = "";
    }
}