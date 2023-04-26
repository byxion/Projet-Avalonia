using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using GAG.ViewModels;

namespace GAG.Views
{
    public partial class ConfirmWindow : ReactiveWindow<ConfirmViewModel>
    {
        public ConfirmWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.OkCommand.Subscribe(Close)));
            this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(Close)));
        }
    }
}
