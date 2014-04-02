using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCode.Requests
{
    [Serializable]
    public class UserRequest : RequestBase
    {
        public UserRequest(RequestedMethod requestedMethod, User user)
        {
            Method = requestedMethod;
            ObjectForRequest = user;
        }
    }
}
