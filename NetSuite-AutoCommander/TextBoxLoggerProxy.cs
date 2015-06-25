using NetSuite_Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetSuite_AutoCommander
{
    public class TextBoxLoggerProxy: ILogger
    {
        private TextBoxBase _txtBox;

        public TextBoxLoggerProxy(TextBoxBase txtBox)
        {
            _txtBox = txtBox;
        }

        public void Log(string message)
        {
            _txtBox.Text += message + "\n";
        }
    }
}
