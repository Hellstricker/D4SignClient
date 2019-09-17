using System;
using System.Collections.Generic;

namespace D4Sign.Client
{
    public class D4SignException : Exception
    {
        private string message;
        private int statusCode;
        

        public D4SignException(string message, int statusCode)
        {
            this.message = message;
            this.statusCode = statusCode;
        
        }
    }
}