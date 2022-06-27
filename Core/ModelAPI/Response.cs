using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraphonSkills.Core.ModelAPI
{
    public class Response<T>
    {

        public T data { get; set; }

        public bool success { get; set; }
    }
}
