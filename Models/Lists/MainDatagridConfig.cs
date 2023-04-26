using System.Collections.Generic;

namespace GAG.Models.Lists
{
    public class MainDataGridConfig
    {
        public bool HasDeleteBtn { get; set; } = true;
        public List<DataGridColumnConfig> ColumnConfigs { get; set; } = new List<DataGridColumnConfig>();
    }
}
