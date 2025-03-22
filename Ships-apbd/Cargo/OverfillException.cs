using System;

namespace Apbd_miniProject01
{

    public class OverfillException : Exception
    {
        public OverfillException()
            : base("OverfillException")
        {
        }
    }
}