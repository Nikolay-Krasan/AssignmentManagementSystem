using System;
using CommonCode.Requests;

namespace CommonCode
{
    [Serializable]
    public abstract class RequestBase
    {
        public RequestedMethod Method;

        public BaseObject ObjectForRequest;
    }
}
