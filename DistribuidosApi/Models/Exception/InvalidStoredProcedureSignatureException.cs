using System;

namespace DistribuidosApi.Exceptions
{
    public class InvalidStoredProcedureSignatureException : Exception
    {
        public InvalidStoredProcedureSignatureException(string message) : base(message)
        {
        }
    }
}