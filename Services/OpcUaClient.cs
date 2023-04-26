using Opc.UaFx.Client;

namespace GAG.Services
{
    public class OpcUaClient
    {
        private OpcClient Client { get; set; }
        public OpcUaClient()
        {
            Client = new OpcClient("opc.tcp://r7185065:62640/IntegrationObjects/ServerSimulator");
        }

        public void WriteValue(string tagName, object value)
        {
            Client.Connect();

            Client.WriteNode(tagName, value);

            Client.Disconnect();

        }

        public object ReadValue(string tagName)
        {
            Client.Connect();

            object value = Client.ReadNode(tagName);

            Client.Disconnect();

            return value;
        }

    }
}
