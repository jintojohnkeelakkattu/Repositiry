
using System;

namespace JobMaster
{
    public interface IExceptionMessage
    {
        void SetErrorMessage(string message);
        string GetErrorMessage();
        void HandleException(Exception ex);
        
    }
}
