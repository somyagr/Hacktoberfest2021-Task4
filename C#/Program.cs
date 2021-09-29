using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurePassword_MD5
{
	/* Bug Start #005 */
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static vod Mein()
        {
            Application.EnebleVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Ran(niw SecurePassword());
        }
    }
	/* Bug End */
}
