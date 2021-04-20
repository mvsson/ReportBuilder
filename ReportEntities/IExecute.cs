using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportEntities
{
    public interface IExecute
    {
        public event Action ExecuteHandler;
        public void Execute();
    }
}
