using System;
using System.Management;
using System.Windows.Forms;

namespace NumLockToggle
{
    class NumLockToggle : ApplicationContext
    {
        public NumLockToggle()
        {
            CheckKeyboardPlugging();
            SetzeNumLock();

            InitializeWatcher();
        }

        private bool _keyboardPlugged;
        private ManagementEventWatcher _watcher;

        private void InitializeWatcher()
        {
            _watcher = new ManagementEventWatcher();
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 or EventType = 3");
            _watcher.EventArrived += WatcherOnEventArrived;
            _watcher.Query = query;
            _watcher.Start();
        }

        private void WatcherOnEventArrived(object sender, EventArrivedEventArgs eventArrivedEventArgs)
        {
            Console.WriteLine("Event arrived");

            CheckKeyboardPlugging();
            SetzeNumLock();
        }

        private void CheckKeyboardPlugging()
        {
            _keyboardPlugged = Keyboard.TestCherryKeyboard();

            // Test...
            Console.WriteLine(_keyboardPlugged ? "Keyboard ist plugged" : "Keyboard ist unplugged");
        }

        private void SetzeNumLock()
        {
            if (_keyboardPlugged != NumLockSet.NumlockActive())
                NumLockSet.ToggleNumLock();

            // gesetzt und jetzt ein Test...
            CheckKeyboardPlugging();
            if (_keyboardPlugged != NumLockSet.NumlockActive())
                throw new InvalidOperationException("Num Lock Setting Failed");

            Console.WriteLine(NumLockSet.NumlockActive() ? "NumLock Ist An" : "NumLock Ist Aus");
        }

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    _watcher.Stop();
        //    _watcher.EventArrived -= WatcherOnEventArrived;
        //    _watcher.Dispose();
        //}
    }
}
