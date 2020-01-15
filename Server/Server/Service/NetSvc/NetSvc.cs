using PENet;
using PEProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class NetSvc
    {
        private static NetSvc instance = null;
        public static NetSvc Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NetSvc();
                }
                return instance;
            }
        }

        public void Init()
        {
        PESocket<ServerSession, GameMsg> server = new PESocket<ServerSession, GameMsg>();
        server.StartAsServer(SrvCfg.srvIP, SrvCfg.srvPort);

        PETool.LogMsg("NetSvc Init Done");
        }
    }
