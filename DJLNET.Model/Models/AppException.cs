using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Models
{
    public class AppException : GenericEntity<int>
    {
        public AppExceptionType AppLogType { get; set; } = AppExceptionType.None;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
    }

    public enum AppExceptionType
    {
        None,
        Server,
        Service,
        Data
    }
}
