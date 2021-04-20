using System;
using System.ComponentModel.DataAnnotations;
using ReportEntities.Enums;

namespace ReportEntities.Reports
{
    public class MoveAndStopReport : Report, IExecute
    {
        public MoveAndStopReport() : base(code : 1)
        { }

        [Required]
        [Display(Name = "Период отчёта")]

        public ReportRange Range { get; set; }
        private Action _executeHandler;
        public event Action ExecuteHandler
        {
            add => _executeHandler += value;
            remove
            {
                if (_executeHandler != null) 
                    _executeHandler -= value;
            }
        }
        public void Execute()
        {
            _executeHandler?.Invoke();
        }
    }
}