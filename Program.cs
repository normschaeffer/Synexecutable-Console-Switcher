using System;
using Enkadia.Synexsis.Components.Switchers.Extron;
using Microsoft.Extensions.DependencyInjection;
using Enkadia.Synexsis.ComponentFramework.Extensions;

namespace console_switcher
{
    class Program

    {
        //Get the Synexsis tools and module ready to use
        private static IServiceCollection serviceCollection;
        private static IServiceProvider serviceProvider;
        private static DXPSwitcher swt;


        private static int Input;
        private static string SingleSpace = "\r";

        static void Main(string[] args)
        {
            GetDevices(); // start the Synexsis module

            Console.WriteLine("Select an action and press Enter");
            Console.WriteLine("................................");
            Console.WriteLine();
            Console.WriteLine("     (1) - Send PC to Monitors in Break Room and Lobby" + SingleSpace);
            Console.WriteLine("     (2) - Send TV to Monitors in Break Room and Lobby" + SingleSpace);
            Console.WriteLine("     (3) - Mute Video Displays" + SingleSpace);
            Console.WriteLine("     (4) - Unmute Video Displays" + SingleSpace);
            Console.WriteLine("     (5) - Check Crosspoints" + SingleSpace);
            Console.WriteLine("     (6) - Shutdown App" + SingleSpace);
            Console.WriteLine("     Press Esc twice to end the program");
            Console.WriteLine();

            do
            {
                var selected = Console.ReadKey().Key;
                var intSelected = Convert.ToInt16(selected);

                switch (intSelected) // D1-D5 indicate number keys on the keyboard;
                {
                    case (short)ConsoleKey.D1:
                        Input = 1;
                        SendToSwitcher(Input);
                        break;
                    case (short)ConsoleKey.NumPad1:
                        Input = 1;
                        SendToSwitcher(Input);
                        break;
                    case (short)ConsoleKey.D2:
                        Input = 4;
                        SendToSwitcher(Input);
                        break;
                    case (short)ConsoleKey.NumPad2:
                        Input = 4;
                        SendToSwitcher(Input);
                        break;
                    case (short)ConsoleKey.D3:
                        MuteDisplays();
                        break;
                    case (short)ConsoleKey.NumPad3:
                        MuteDisplays();
                        break;
                    case (short)ConsoleKey.D4:
                        UnmuteDisplays();
                        break;
                    case (short)ConsoleKey.NumPad4:
                        UnmuteDisplays();
                        break;
                    case (short)ConsoleKey.D5:
                        CheckCrosspoints();
                        break;
                    case (short)ConsoleKey.NumPad5:
                        CheckCrosspoints();
                        break;
                    case (short)ConsoleKey.D6:
                        SystemShutdown();
                        break;
                    case (short)ConsoleKey.NumPad6:
                        SystemShutdown();
                        break;

                    default:
                        Console.WriteLine("Incorrect key pressed");
                        break;
                }


            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        //Start the Synexsis module - get login and license information
        private static void GetDevices()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddSynexsis();
            serviceCollection.AddTransient<DXPSwitcher>();
            serviceProvider = serviceCollection.BuildServiceProvider();
            swt = serviceProvider.ResolveWith<DXPSwitcher>("Swt");
        }

        private static async void SendToSwitcher(int input)
        {
            await swt.AVXPoints(Input, new[] {1, 2});
        }

        private static async void MuteDisplays()
        {
            await swt.AVMuteAll();
        }

        private static async void CheckCrosspoints()
        {
            string answer;
            var response = await swt.GetRGBXPoints();
            answer = response.RawResponse;
        }

        private static async void UnmuteDisplays()
        {
            string answer;
            var response = await swt.AVUnmuteAll();
            answer = response.RawResponse;
        }

        private static void SystemShutdown()
        {
            Console.WriteLine();
            Console.WriteLine("Press Y to close the application");
            var shutdownSelected = Console.ReadKey().Key;
            var shutdownKey = ConsoleKey.Y;
            if (Equals(shutdownSelected, shutdownKey))
            {
                Environment.Exit(0);
            }
        }
    }
}
