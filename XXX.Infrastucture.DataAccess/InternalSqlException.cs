using System;
using System.Diagnostics.CodeAnalysis;

namespace XXX.Infrastructure.DataAccess
{
    [ExcludeFromCodeCoverage]
    public class InternalSqlException : Exception
    {
        public InternalSqlException(string message) : base(message)
        {
        }
    }
}