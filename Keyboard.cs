using System.Linq;
using HidSharp;

namespace NumLockToggle
{
    class Keyboard
    {
        //internal static bool TestKeyboard()
        //{
        //    //FIND WHETHER A USB KEYBOARD IS PLUGGED IN
        //    var hd = new HidDeviceLoader();

        //    if (hd.GetDevices().Any(item => item.ProductName.Contains("Keyboard")))
        //        return true;

        //    //FIND WHETHER A PS/2 KEYBOARD IS PLUGGED IN.
        //    const string query = "select * from Win32_Keyboard";
        //    var oQuery = new ObjectQuery(query);
        //    var searcher = new ManagementObjectSearcher(oQuery);
        //    var recordSet = searcher.Get();
        //    return
        //        recordSet.Cast<ManagementObject>()
        //            .Any(record => record.Properties["Description"].Value.ToString().Contains("Keyboard"));
        //}

        internal static bool TestCherryKeyboard()
        {
            var hd = new HidDeviceLoader();
            return hd.GetDevices().Any(item => item.VendorID == 1130);
        }
    }
}
