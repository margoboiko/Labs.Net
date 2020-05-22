using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    internal interface IRateAndCopy
    {
        string Raiting { set; }
        object DeepCopy();
    }
}