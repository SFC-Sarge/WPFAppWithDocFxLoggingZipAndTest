using Microsoft.Extensions.Logging; //Add to test project.
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using WPFAppWithDocFxLoggingAndZip1;

using $safeprojectname$.Properties;

namespace $safeprojectname$
{
    public partial class WpftestPropertiesValues : INotifyPropertyChanged
    {
        public Random FileRandom = new();
        public char Quote = (char)34;
        public StringBuilder CurrentStringBuilder = new();
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e) => PropertyChanged?.Invoke(sender, e);

        XNamespace ns = Resources.urnSchemasMicrosoftComUnattend; //Add Resources Value = "urn:schemas-microsoft-com:unattend"
        public XNamespace Ns
        {
        get => ns;
        set
            {
                if (ns == value)
                {
                    return;
                }

                ns = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(Ns)));
            }
        }
        XNamespace ns1 = Resources.httpSchemasMicrosoftComWMIConfig2002State; //Add Recources Value = "http://schemas.microsoft.com/WMIConfig/2002/State"
        public XNamespace Ns1
        {
        get => ns1;
        set
            {
                if (ns1 == value)
                {
                    return;
                }

                ns1 = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(Ns1)));
            }
        }

    }
}

