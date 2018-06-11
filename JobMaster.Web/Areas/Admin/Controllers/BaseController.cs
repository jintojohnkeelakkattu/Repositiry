
using JobMaster.Entities.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JobMaster.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller, IExceptionMessage
    {
        private string errorMsg = string.Empty;

        public string GetErrorMessage()
        {
            return errorMsg;
        }

        public void HandleException(Exception ex)
        {
            if (ex is ActionNotCompletedException)
            {
                SetErrorMessage(ex.Message);
            }
            else
            {
                SetErrorMessage("Oops something went wrong, development team has been modified.");
                // log error.
            }
            
        }

        public void SetErrorMessage(string message)
        {
            errorMsg = message;
        }
    }
}