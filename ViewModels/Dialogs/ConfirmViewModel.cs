using ReactiveUI;
using System.Reactive;
using GAG.Models;

namespace GAG.ViewModels
{
    public class ConfirmViewModel : ViewModelBase
    {
        public ConfirmViewModel()
        {
            OkCommand = ReactiveCommand.Create(() =>
            {
                return new ConfirmResult
                {
                    Result = true,
                };
            });

            CancelCommand = ReactiveCommand.Create(() =>
            {
                return new ConfirmResult
                {
                    Result = false,
                };
            });

        }

        public ReactiveCommand<Unit, ConfirmResult> OkCommand { get; }
        public ReactiveCommand<Unit, ConfirmResult> CancelCommand { get; }
    }
}
