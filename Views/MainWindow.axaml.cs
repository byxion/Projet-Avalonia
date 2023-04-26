using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;
using GAG.Models;
using GAG.ViewModels;

namespace GAG.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        WindowState = WindowState.Maximized;

        this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<ConfirmViewModel, ConfirmResult> interaction)
    {
        var dialog = new ConfirmWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<ConfirmResult>(this);
        interaction.SetOutput(result);
    }
}