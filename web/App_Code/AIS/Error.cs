using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

/// <summary>
/// Description résumée de Error
/// </summary>
public class Error
{
    public string Source { get; set; }
    public string InnerException { get; set; }
    public string StackTrace { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }
    public Error(string source, string innerException, string stackTrace, string message, string exception)
    {
        Source = source;
        InnerException = innerException;
        StackTrace = stackTrace;
        Message = message;
        Exception = exception;    
    }
}