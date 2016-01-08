// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    using System;
    using System.Collections.Generic;
    using Windows.Storage;
    using Windows.Storage.Pickers;
    using Windows.Storage.Streams;
    using Windows.UI;
    using Windows.UI.Core;
    using Windows.UI.Input.Inking;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private static InkCanvas staticInkCanvas;
        private static InkDrawingAttributes inkDrawingAttributes = new InkDrawingAttributes();
        private static Color changedColor;

        private static Color black = Windows.UI.Colors.Black;
        private static Color red = Windows.UI.Colors.Red;
        private static Color orange = Windows.UI.Colors.Orange;
        private static Color yellow = Windows.UI.Colors.Yellow;
        private static Color green = Windows.UI.Colors.Green;

        private static Color white = Windows.UI.Colors.White;
        private static Color blue = Windows.UI.Colors.Blue;
        private static Color gray = Windows.UI.Colors.Gray;
        private static Color purple = Windows.UI.Colors.Purple;
        private static Color brown = Windows.UI.Colors.Brown;

        public MainPage()
        {
            this.InitializeComponent();

            staticInkCanvas = inkCanvas;
            staticInkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
            // Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Hand, 1);

        }

        public static Color ChangedColor
        {
            get { return changedColor; }
            set
            {
                changedColor = value;
                inkDrawingAttributes.Color = ChangedColor;
                staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
            }
        }

        public static void PickPen()
        {
            staticInkCanvas.InkPresenter.InputProcessingConfiguration.Mode =
               InkInputProcessingMode.Inking;
        }

        public static void PickEraser()
        {
            staticInkCanvas.InkPresenter.InputProcessingConfiguration.Mode =
              InkInputProcessingMode.Erasing;
        }

        public static void ClearCanvas()
        {
            staticInkCanvas.InkPresenter.StrokeContainer.Clear();
        }

        public async static void Save()
        {
            var savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            savePicker.FileTypeChoices.Add("*.png", new List<string> { ".png" });

            StorageFile storageFile = await savePicker.PickSaveFileAsync();

            if (storageFile != null)
            {
                using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await staticInkCanvas.InkPresenter.StrokeContainer.SaveAsync(stream);
                }
            }
        }

        public async static void Load()
        {
            var fileOpen = new FileOpenPicker();
            fileOpen.FileTypeFilter.Add(".png");

            var storageFile = await fileOpen.PickSingleFileAsync();

            if (storageFile != null)
            {
                using (IRandomAccessStreamWithContentType stream = await storageFile.OpenReadAsync())
                {
                    ClearCanvas();
                    await staticInkCanvas.InkPresenter.StrokeContainer.LoadAsync(stream);
                }
            }
        }

        private void BlackRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = black;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        public void RedRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = red;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void OrangeRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = orange;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void YellowRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = yellow;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void GreenRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = green;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }
        
        private void WhiteRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = white;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void GrayRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = gray;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void BlueRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = blue;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void PurpleRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = purple;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void BrownRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inkDrawingAttributes.Color = brown;

            staticInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
        }

        private void PenButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PickPen();
        }

        private void EraserButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PickEraser();
        }

        private void ClearCanvasButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClearCanvas();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
