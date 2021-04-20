using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportEntities.Reports
{
    public class MessagesFromObjectReport : Report, IExecute
    {
        public MessagesFromObjectReport() : base(code : 2)
        {
            SensorsPrefer = new List<Sensor>();
        }

        [Required]
        [Display(Name = "Датчики для наблюдения")]
        public ICollection<Sensor> SensorsPrefer { get; set; }

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