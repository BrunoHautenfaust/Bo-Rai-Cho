namespace App1
{
    using System;
    using System.Linq;
    using Windows.ApplicationModel;
    using Windows.ApplicationModel.Activation;
    using Windows.Media.SpeechRecognition;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;

        }
        
        protected override void OnActivated(IActivatedEventArgs e)
        {
            // Needed to make the app start with Cortana

            // When a Voice Command activates the app, this method is going to 
            // be called and OnLaunched is not. Because of that we need similar
            // code to the code we have in OnLaunched
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.CacheSize = 1;
                Window.Current.Content = rootFrame;
                rootFrame.Navigate(typeof(MainPage));
            }

            Window.Current.Activate();
            // End of make app start with Cortana

            // Was the app activated by a voice command?
            if (e.Kind != ActivationKind.VoiceCommand)
            {
                return;
            }

            VoiceCommandActivatedEventArgs commandArgs = e as VoiceCommandActivatedEventArgs;
            SpeechRecognitionResult speechRecognitionResult = commandArgs.Result;

            // OLD: Windows.ApplicationModel.VoiceCommands.VoiceCommand.SpeechRecognitionResult speechRecognitionResult = commandArgs.Result;

            // Get the name of the voice command and the text spoken
            string voiceCommandName = speechRecognitionResult.RulePath[0];
            string textSpoken = speechRecognitionResult.Text;
            // The commandMode is either "voice" or "text", and it indicates how the voice command was entered by the user.
            // Apps should respect "text" mode by providing feedback in a silent form.
            string commandMode = this.SemanticInterpretation("commandMode", speechRecognitionResult);

            switch (voiceCommandName)
            {
                case "pickColor":
                    // Access the value of the {color} phrase in the voice command
                    string color = speechRecognitionResult.SemanticInterpretation.Properties["color"][0];
                    System.Diagnostics.Debug.WriteLine("textSpoken: " + textSpoken);
                    string[] words = color.Split(' ');

                    MainPage.Keyword = words[words.Length - 1];

                    MainPage.PickColor();
                    // System.Diagnostics.Debug.WriteLine("last word: " + words[words.Length-1]);
                    break;

                case "clearCanvas":
                    MainPage.ClearCanvas();
                    break;

                case "open":
                    string open = speechRecognitionResult.RulePath[0];
                    break;

                default: break;
            }
           
            /*
            if (this.rootFrame == null)
            {
                // App needs to create a new Frame, not shown
            }

            if (!this.rootFrame.Navigate(navigateToPageType, navigationParameterString))
            {
                throw new Exception("Failed to create voice command page");
            }
            */
        }

        private string SemanticInterpretation(string interpretationKey, SpeechRecognitionResult speechRecognitionResult)
        {
            return speechRecognitionResult.SemanticInterpretation.Properties[interpretationKey].FirstOrDefault();
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void   OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();

            try
            {
                var storageFile =
                await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
                    new Uri("ms-appx:///WinAppCommands.xml"));
                await
                  Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager.
                    InstallCommandDefinitionsFromStorageFileAsync(storageFile);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("There was an error registering the Voice Command Definitions", ex);
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
