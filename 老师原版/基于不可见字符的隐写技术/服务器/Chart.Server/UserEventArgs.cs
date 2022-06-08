using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Server
{
    public class UserEventArgs : EventArgs
    {
        public object userId;

        public UserEventArgs(object userId)
        {
            this.userId = userId;
        }
    }
    public delegate void UserEventHandler(object sender, UserEventArgs e);
}
