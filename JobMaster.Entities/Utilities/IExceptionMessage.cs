
using System;

namespace JobMaster.Entities.Utilities
{
    public interface IExceptionMessage
    {
        void SetErrorMessage(string message);
        string GetErrorMessage();
        void HandleException(Exception ex);
        
    }
}
