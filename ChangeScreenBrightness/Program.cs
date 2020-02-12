/*
 * Windows screen brightness control
 * Use library: ScreenBrighnessClass.NET
 * https://forums.ni.com/t5/Community-Documents/Windows-screen-brightness-control-using-a-custom-C-NET-dll/ta-p/3683800?profile.language=en
 * base on .NET Framework 4.7
 * Urls:
 * https://docs.microsoft.com/ru-ru/windows/win32/api/wingdi/nf-wingdi-setdevicegammaramp
 * http://www.pinvoke.net/default.aspx/gdi32.setdevicegammaramp
 * http://www.lattepanda.com/topic-f11t3020.html?sid=f9dc5d65cd4f2feb3c91ca41196c087e
 * https://www.codeproject.com/Articles/47355/Setting-Screen-Brightness-in-C
 * https://stackoverflow.com/questions/8194006/c-sharp-setting-screen-brightness-windows-7/8196953
 * https://docs.microsoft.com/en-us/windows/win32/wmicoreprov/wmisetbrightness-method-in-class-wmimonitorbrightnessmethods
 * 
 * Add multiple icons to a .NET application // https://einaregilsson.com/add-multiple-icons-to-a-dotnet-application/
*/
using ScreenBrighnessClassNET;
using System;

namespace ChangeScreenBrightness
{
    class Program
    {
        public static int Main(string[] args)
        {
            //value 80,90
            var _screenBrightness = new ScreenBrightness();
            try
            {
                Console.WriteLine("ChangeScreenBrightness build 1");
                // Step 1: test for null.
                if (args.Length == 0)
                {
                    Console.WriteLine("value is null");
                    ExExitApp();
                }
                else
                {
                    string strArgument = args[0];
                    int intValue = 0;
                    if (int.TryParse(strArgument, out intValue))
                    {
                        if ((0 < intValue) && (intValue <= 100))
                        {
                            //Set Brightness 
                            _screenBrightness.SetBrightness((byte)intValue);
                            Console.WriteLine("Set Brightness Value: "+ strArgument);
                            return 0;
                        }
                    }
                }
                //
                Console.WriteLine("value is not from 1 to 100");
                ExExitApp();
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                Console.WriteLine("Exit App");
                return -1;
            }
        }
        private static void ExExitApp()
        {
            Console.WriteLine("You must set the brightness level of the monitor screen");
            Console.WriteLine("Value from 1 to 100");
            Console.WriteLine("Example: Set the brightness of the screen monitor to 90%");
            Console.WriteLine("$ChangeScreenBrightness.exe 90");
            Console.WriteLine("Exit App");
            Environment.Exit(-1);
        }
    }
}
