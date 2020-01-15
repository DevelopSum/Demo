using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// 服务器初始化
    /// </summary>
    public class ServerRoot
    {
        private static ServerRoot instance = null;
        public static ServerRoot Instance {
            get {
                if (instance == null)
                {
                    instance = new ServerRoot();
                }
                return instance;
            }
        }

        public void Init() {
        //数据层TODO

        //服务处
        NetSvc.Instance.Init();

        //业务系统层 
        LoginSys.Instance.Init();

        }
    }
