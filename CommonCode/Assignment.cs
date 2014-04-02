using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCode
{
    [Serializable]
    public class Assignment : Object
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public Guid Owner { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
