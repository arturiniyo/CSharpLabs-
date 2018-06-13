using System;

namespace Lab2_cs
{
    class MyIndexOutOfRangeException : Exception
    {
        public MyIndexOutOfRangeException()
            : base() { }
        public MyIndexOutOfRangeException(string message)
            : base(message) { }
    }

    class MyInvalidCastException : InvalidCastException
    {
        public MyInvalidCastException()
            : base() { }

        public MyInvalidCastException(string message)
            : base(message) { }

        public MyInvalidCastException(string message, Exception innerException)
            : base(message, innerException) { }

        public MyInvalidCastException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public MyInvalidCastException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }

    class MyOutOfMemoryException : OutOfMemoryException
    {
        public MyOutOfMemoryException()
            : base() { }

        public MyOutOfMemoryException(string message)
            : base(message) { }

        public MyOutOfMemoryException(string message, Exception innerException)
            : base(message, innerException) { }

        public MyOutOfMemoryException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public MyOutOfMemoryException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }

    class MyArrayTypeMismatchException : ArrayTypeMismatchException
    {
        public MyArrayTypeMismatchException()
            : base() { }

        public MyArrayTypeMismatchException(string message)
            : base(message) { }
        
        public MyArrayTypeMismatchException(string message, Exception innerException)
            : base(message, innerException) { }

        public MyArrayTypeMismatchException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public MyArrayTypeMismatchException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }


    class MyDivideByZeroException : DivideByZeroException
    {
        public MyDivideByZeroException()
            : base() { }

        public MyDivideByZeroException(string message)
            : base(message) { }

        public MyDivideByZeroException(string message, Exception innerException)
            : base(message, innerException) { }

        public MyDivideByZeroException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public MyDivideByZeroException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
