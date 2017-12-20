using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Mark { X, O, N };
public interface ICellModel
{
    bool IsClicked { get; }
    Mark Mark{ get; }
    void Reset();
    void Click(Mark isX);
}
