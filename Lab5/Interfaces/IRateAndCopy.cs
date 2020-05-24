using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Interfaces
{
    internal interface IRateAndCopy
    {
        string Raiting { get; }
        object DeepCopy();
    }
}