using ReactiveUI;
using GAG.Models;
using GAG.Views;

namespace GAG.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            InitGrafcetViewMode();
            InitOPCViewMode();

            ShowDialog = new Interaction<ConfirmViewModel, ConfirmResult>();
        }

        public void ShowIcons()
        {
            var window = new IconsWindow
            {
                DataContext = new IconsWindowViewModel()
            };

            window.Show();
        }

        public Interaction<ConfirmViewModel, ConfirmResult> ShowDialog { get; set; }
    }
}