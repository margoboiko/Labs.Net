using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lr2
{
    internal interface IRateAndCopy
    {
        string Name { get; set; }
        object DeepCopy();

    }
}
