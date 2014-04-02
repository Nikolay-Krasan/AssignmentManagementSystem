using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCode.Requests
{
    [Serializable]
    public class AssignmentRequest : RequestBase
    {
        public AssignmentRequest(RequestedMethod requestedMethod, Assignment assignment)
        {
            Method = requestedMethod;
            //ObjectForRequest = assignment;
        }
    }
}
