/*
MIT License

Copyright (c) 2017 Stéphane Lepin <stephane.lepin@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Net;
using System.Net.Sockets;

namespace UECP
{
    public interface UDPEndpoint
    {
        void SendData(byte[] data);
    }

    public class UDPSimplexEndpoint : UDPEndpoint
    {
        private UdpClient _udpClient;

        public UDPSimplexEndpoint(string encoderAddress, int encoderPort)
        {
            _udpClient = new UdpClient();
            _udpClient.Connect(IPAddress.Parse(encoderAddress), encoderPort);
        }

        public void SendData(byte[] data)
        {
            _udpClient.Send(data, data.Length);
        }
    }
    public interface TCPEndpoint
    {
        void SendData(byte[] data);
    }
    public class TCPSimplexEndpoint : TCPEndpoint
    {
        private TcpClient _tcpClient;
        private NetworkStream TCPStream;
        public TCPSimplexEndpoint(string encoderAddress, int encoderPort)
        {
            _tcpClient = new TcpClient(IPAddress.Parse(encoderAddress).ToString(), encoderPort);
            //_tcpClient.Connect(IPAddress.Parse(encoderAddress), encoderPort);
        }
        public void SendData(byte[] data)
        {
            TCPStream = _tcpClient.GetStream();
            TCPStream.Write(data, 0, data.Length);
        }
    }
}
