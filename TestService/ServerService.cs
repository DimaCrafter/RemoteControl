using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCServer {
    public partial class ServerService : ServiceBase {
        public ServerService () {
            InitializeComponent();
        }

        protected override void OnStart (string[] args) {
            System.IO.File.Create("D:\\started");
        }

        protected override void OnStop () {
            System.IO.File.Move("D:\\started", "D:\\stopped");
            base.OnStop();
            //Environment.Exit(0);
        }
    }
}
