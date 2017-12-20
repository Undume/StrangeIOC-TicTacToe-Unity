using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;


class PlayAgainView : View
{
    public Signal ClickedSignal = new Signal { };

    public void OnClicked()
    {
        ClickedSignal.Dispatch();
    }
}
