using System.Collections.Generic;
using CommonCode.Requests;

namespace CommonCode
{
    public abstract class OrganizerBase
    {
        public List<BaseObject> AllItems { get; private set; }

        public void Change(BaseObject item)
        {
            var assignmentToChange = AllItems.Find(a => item.Id == item.Id);
            AllItems.Remove(assignmentToChange);
            AllItems.Add(item);
        }

        public void HandleRequest(RequestBase request)
        {
            switch (request.Method)
            {
                case RequestedMethod.Add:
                    AllItems.Add(request.ObjectForRequest);
                    break;

                case RequestedMethod.Edit:
                    Change(request.ObjectForRequest);
                    break;

                case RequestedMethod.Remove:
                    AllItems.Remove(request.ObjectForRequest);
                    break;
            }
        }
    }
}
