using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidado.Util.Entities
{
    public class StatusResponse
    {
        public bool Valid { get; set; }

        public List<ErrorMessage> Error { get; set; }

        public StatusResponse()
        {
            Valid = true;
            Error = new List<ErrorMessage>();
        }

        public StatusResponse(bool valid, List<ErrorMessage> error)
        {
            Valid = valid;
            Error = error;
        }
    }
}
