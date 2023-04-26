

using ReactiveUI;
using System;
using GAG.Services;

namespace GAG.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        OpcUaClient opcUaClient;

        public void InitOPCViewMode()
        {
            opcUaClient = new OpcUaClient();
        }

        public double opcWriteValue;
        public double OpcWriteValue
        {
            get => opcWriteValue;
            set => this.RaiseAndSetIfChanged(ref opcWriteValue, value);
        }

        public double opcReadValue;
        public double OpcReadValue
        {
            get => opcReadValue;
            set => this.RaiseAndSetIfChanged(ref opcReadValue, value);
        }

        public void WriteOPC()
        {
            opcUaClient.WriteValue("ns=2;s=Tag7", OpcWriteValue);
        }

        public void ReadOPC()
        {
            OpcReadValue = Convert.ToDouble(opcUaClient.ReadValue("ns=2;s=Tag7").ToString());
        }
    }
}
