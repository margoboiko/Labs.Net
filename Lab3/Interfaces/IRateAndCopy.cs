using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lr3
{
    internal interface IRateAndCopy
    {
        string Raiting { set; }
        object DeepCopy();
    }
}