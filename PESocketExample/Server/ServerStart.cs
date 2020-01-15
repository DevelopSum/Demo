using PENet;
using Protocal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class ServerStart
    {
        static void Main(string[] args)
        {
            PESocket<ServerSession, NetMsg> server = new PESocket<ServerSession, NetMsg>();
            server.StartAsServer(IPCfg.srvIP, IPCfg.srvPort);

            while (true)
            {

            }
        }
    }
}
