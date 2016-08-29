using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    /// <summary>
    /// This decribes whether an operation passed or failed
    /// </summary>
    public class Execute
    {
        public bool Status { set; get; }
    }

    /// <summary>
    /// This is the Base Entity that classes can inherit from.
    /// </summary>
    public class BaseEntity
    {
        public Execute Execution { set; get; }

        public BaseEntity()
        {
            if (Execution == null)
                Execution = new Execute();
        }
    }
}
