namespace GAG.Models.Lists
{
    public enum ColumnListType
    {
        Text,
        Checkbox
    }
    public class DataGridColumnConfig
    {
        public string Header { get; set; } = "";
        public string BindingPath { get; set; } = "";
        public bool IsFilterable { get; set; } = false;
        public ColumnListType ListType { get; set; } = ColumnListType.Text;

    }
}
