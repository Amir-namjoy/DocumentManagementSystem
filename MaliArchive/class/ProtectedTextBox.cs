using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MaliArchive
{
    class ProtectedTextBox : TextBox
    {
        // the malicious message, that needs to be handled
        private const int WM_GETTEXT = 0x000D;

        // 'true' if the messages are sent from our program (from Text property)
        // 'false' if they're sent by anything else 
        bool allowAccess { get; set; }

        public override string Text   // overriding Text property
        {
            get
            {
                allowAccess = true;    // allow WM_GETTEXT (because it's an internal call)
                return base.Text;  //this sends the message above in order to retrieve the TextBox's value
            }
            set
            {
                base.Text = value;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_GETTEXT)  // if the message is WM_GETTEXT 
            {
                if (allowAccess)  // and it comes from the Text property
                {
                    allowAccess = false;   //we temporarily remove the access
                    base.WndProc(ref m);  //and finally, process the message
                }
            }
            else
                base.WndProc(ref m);
        }
    }
}
