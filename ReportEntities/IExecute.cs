using System;

namespace ReportEntities
{
    public interface IExecute
    {
        public event Action ExecuteHandler;
        public void Execute();
    }
}
