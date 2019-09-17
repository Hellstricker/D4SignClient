using System;
using System.Collections.Generic;
using System.Text;

namespace D4Sign.Client
{
    public enum SignatureActionType
    {
        Sign = 1,
        Approve = 2,
        Recognize = 3,
        SignAsPart = 4,
        SignAsWitness = 5,
        SignAIntervener = 6,
        AccuseReceipt = 7,
        SignAsIssuerEndorserAndGuarantor = 8
    }
}
