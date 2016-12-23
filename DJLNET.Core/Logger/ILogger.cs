using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Logger
{
    public interface ILogger
    {
        void Error(string message);
        void Error(string message, Exception innerException);

        void Info(string message);
        void Info(string message, Exception innerException);

        void Warning(string message);
        void Warning(string message, Exception innerException);

        void Fatal(string message);
        void Fatal(string message, Exception innerException);
    }
}
