using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NumLockToggle
{
    public class NumLockSet
    {
        [DllImport("user32")]
        public static extern void keybd_event(int vk, byte bScan, int dwFlags, int dwExtraInfo);

        public static bool NumlockActive()
        {
            return Control.IsKeyLocked(Keys.NumLock);
        }

        /// <summary>
        /// Funktion setzt NumLock entweder an oder aus, entspricht Tastendruck
        /// </summary>
        public static void ToggleNumLock()
        {
            const int vkNumlock = (int)Keys.NumLock;
            const byte keyeventfKeyup = 0x0002;

            // Taste pressen...
            keybd_event(vkNumlock, 1, 0, 0);
            // ...und hoch das Fingerchen
            keybd_event(vkNumlock, 0, keyeventfKeyup, 0);
        }
    }
}
