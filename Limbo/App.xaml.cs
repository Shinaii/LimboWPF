using System.Windows;

namespace Limbo
{
    public partial class App : Application
    {
        public static event Action AllWindowsCreated;

        protected override async void OnStartup(StartupEventArgs e)
        {
            int windowID = 0;
            base.OnStartup(e);
            
            int CorrectKeyID = new Random().Next(0, 7);

            int numberOfWindows = 8; 
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            double windowWidth = 150; 
            double windowHeight = 150; 
            double spaceBetweenWindows = 50; 

            double totalWidthOfFourWindows = 4 * windowWidth + 3 * spaceBetweenWindows; 
            double totalHeightOfTwoWindows = 2 * windowHeight + spaceBetweenWindows; 
            double centerOfScreenX = screenWidth / 2; 
            double centerOfScreenY = screenHeight / 2; 

            for (int i = 0; i < numberOfWindows; i++)
            {
                await Task.Delay(500); // Wait for 500ms before spawning the next window

                double left;
                double top;

                if (i < 4)
                {
                    // For the first four windows, position them in the center of the screen
                    left = centerOfScreenX - totalWidthOfFourWindows / 2 + i * (windowWidth + spaceBetweenWindows);
                    top = centerOfScreenY - totalHeightOfTwoWindows / 2;
                }
                else
                {
                    // For the next four windows, position them under the first four windows
                    left = centerOfScreenX - totalWidthOfFourWindows / 2 + (i - 4) * (windowWidth + spaceBetweenWindows);
                    top = centerOfScreenY - totalHeightOfTwoWindows / 2 + windowHeight + spaceBetweenWindows;
                }

                MainWindow window = new MainWindow(windowID, CorrectKeyID)
                {
                    Left = left,
                    Top = top
                };
                window.Show();
                if (windowID == CorrectKeyID)
                {
                    Console.WriteLine("Key " + windowID + " spawned!" + " This is the correct key!");
                }
                else
                {
                    Console.WriteLine("Key " + windowID + " spawned!");   
                }
                windowID++;
                
                if (windowID == numberOfWindows)
                {
                    AllWindowsCreated?.Invoke();
                }
            }
        }
    }
}