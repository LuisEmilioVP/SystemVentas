using System;

namespace SystemVentas.Infrastructure.Exceptions
{
    public class DataExceptions : Exception
    {
        public DataExceptions(string message) : base(message) 
        {
        }
    }

    public class DataNotFoundException : Exception 
    {
        public DataNotFoundException(string message) : base(message) 
        {
        }
    }

    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) : base(message) 
        {
        }
    }
}
