using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab21
{
    public class DuplicateIsbnException : Exception
    {
        public DuplicateIsbnException(string message) : base(message) { }
    }

    public class InvalidVolumeException : Exception
    {
        public InvalidVolumeException(string message) : base(message) { }
    }

    public class InvalidPublishYearException : Exception
    {
        public InvalidPublishYearException(string message) : base(message) { }
    }
}
