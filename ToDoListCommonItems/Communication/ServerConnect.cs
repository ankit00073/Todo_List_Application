using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Communication.Server
{
    public class ServerConnect
    {
        TcpListener _listener;
        IPEndPoint _endPoint;

        public ServerConnect(IPEndPoint endPoint)
        {
            _endPoint = endPoint;
            _listener = new TcpListener(_endPoint);
            
        }

        public object RecivedMessage()
        {
            dynamic _message;
            _listener.Start();
    
            try
            {
                using (var client = _listener.AcceptTcpClient())
                {
                    using (var stream = client.GetStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var jsonMessage = reader.ReadLine();
                            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
                            
                            _message = JsonConvert.DeserializeObject<dynamic>(jsonMessage,settings);
                        }

                    }
                }
                
                return _message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            finally
            {
                _listener.Stop();
            }
        }
    }
}
