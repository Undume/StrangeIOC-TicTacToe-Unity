using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CellModel : ICellModel
{
    private bool _clicked;
    private Mark _mark;

    public CellModel()
    {
        Reset();
    }

    public bool IsClicked
    {
        get
        {
            return _clicked;
        }
    }

    public Mark Mark
    {
        get
        {
            return _mark;
        }
    }

    public void Reset()
    {
        _clicked = false;
        _mark = Mark.N;
    }

    public void Click(Mark mark)
    {
        _clicked = true;
        _mark = mark;
    }
}
