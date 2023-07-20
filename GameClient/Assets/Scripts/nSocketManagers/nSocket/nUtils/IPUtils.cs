using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewClientServerSampleWithUdp.nSocketManagers.nSocket.nUtils
{
    public static class IPUtils
    {
        public static IPEndPoint CreateIPEndPoint(string _EndPoint)
        {
            string[] __Ep = _EndPoint.Split(':');
            if (__Ep.Length < 2) throw new FormatException("Invalid endpoint format");
            IPAddress __Ip;
            if (__Ep.Length > 2)
            {
                if (!IPAddress.TryParse(string.Join(":", __Ep, 0, __Ep.Length - 1), out __Ip))
                {
                    throw new FormatException("Invalid ip-adress");
                }
            }
            else
            {
                if (!IPAddress.TryParse(__Ep[0], out __Ip))
                {
                    throw new FormatException("Invalid ip-adress");
                }
            }
            int __Port;
            if (!int.TryParse(__Ep[__Ep.Length - 1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out __Port))
            {
                throw new FormatException("Invalid port");
            }
            return new IPEndPoint(__Ip, __Port);
        }
    }
}
