using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace RCServer {
    [RunInstaller(true)]
    public partial class ServerInstaller : Installer {
        public ServerInstaller () {
            InitializeComponent();
            Installers.Add(new ServiceProcessInstaller {
                Account = ServiceAccount.LocalService
            });

            Installers.Add(new ServiceInstaller {
                StartType = ServiceStartMode.Automatic,
                ServiceName = Program.name
            });
        }
    }
}
