using System;
using System.Windows.Forms;

namespace NumLockToggle
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new NumLockToggle());
        }
    }
}
