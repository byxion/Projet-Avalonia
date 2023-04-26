using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
namespace GAG.Views;

public partial class SortDataGrid : Window
{
    public SortDataGrid()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}