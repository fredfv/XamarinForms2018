using Plugin.Connectivity;

namespace Pedidos.SqlServer.Service
{
    class VerificarConexao
    {
        public static bool TemInternet()
        {
            return CrossConnectivity.Current.IsConnected ? true : false;
        }
    }
}
