using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCode.Requests
{
    public class RequestFactory
    {
        public RequestBase CreateRequest(RequestedMethod method, Object objectForRequest)
        {
            var assignment = objectForRequest as Assignment;
            if (assignment != null)
            {
                return new AssignmentRequest(method, assignment);
            }

            var user = objectForRequest as User;
            if (user != null)
            {
                return new UserRequest(method, user);
            }

            throw new NotImplementedException();
        }
    }
}
