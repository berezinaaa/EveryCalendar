using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model.Notifiers
{
    [Serializable]
    public class VisualNotifier: IEventNotifier
    {
        public void Notify(Event ev)
        {
            MessageBox.Show(ev.NotificationMessage, "Внимание");
        }
    }
}
