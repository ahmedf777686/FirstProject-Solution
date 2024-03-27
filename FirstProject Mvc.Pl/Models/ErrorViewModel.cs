using FirstProject_Mvc.DAL.Data;
using System;

namespace FirstProject_Mvc.Pl.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

    
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
