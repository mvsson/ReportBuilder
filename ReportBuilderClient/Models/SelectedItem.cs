using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBuilderClient.Models
{
    public class SelectedItem<T>
    {
        public SelectedItem()
        {
        }
        public SelectedItem(T itemName)
        {
            ItemName = itemName;
        }
        public bool IsSelected { get; set; }
        public T ItemName { get; set; }
    }
}
