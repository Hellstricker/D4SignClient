using System;
using System.Collections.Generic;
using System.Text;

namespace D4Sign.Client
{
    public enum DocumentStatus
    {
        Processing = 1,
        WaitingSigners = 2,
        WaitingSign = 3,
        Finalized = 4,
        Filed = 5,
        Cancelled = 6
    }
}
