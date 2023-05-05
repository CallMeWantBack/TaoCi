using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFramework.Example
{
    class OperaApp : Architecture<OperaApp>
    {
        protected override void Init()
        {
            this.RegisterModel(new OperaModle());
        }

      
    }
}
