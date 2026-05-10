using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab8i9Lib
{
    public class NotEnoughGoldException : Exception
    {
        public NotEnoughGoldException(string message) : base(message) { }
    }

    public class RequirementNotMetException : Exception
    {
        public RequirementNotMetException(string message) : base(message) { }
    }
}
