using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Util.Entities
{
    public class ErrorMessage
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public ErrorMessage(int errorCode, string Message)
        {
            ErrorCode = errorCode;
            this.Message = Message;
        }
    }
}
