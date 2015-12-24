namespace App1
{
    using Windows.UI.Xaml.Media;

    public static class ColorChanger
    {
        private static SolidColorBrush changedColor = new SolidColorBrush(Windows.UI.Colors.Black);

        public static SolidColorBrush ChangedColor
        {
            get { return changedColor; }
            set { changedColor = value; }
        }

        private static bool flag = false;

        public static bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private static string keyword;

        public static string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }

        public static void PickColor()
        {
            if (Flag == true)
            {
                // System.Diagnostics.Debug.WriteLine("keyword: " + Keyword);
                switch (Keyword)
                {
                    case "Black": changedColor = new SolidColorBrush(Windows.UI.Colors.Black); break;
                    case "Red": changedColor = new SolidColorBrush(Windows.UI.Colors.Red); break;
                    case "Orange": changedColor = new SolidColorBrush(Windows.UI.Colors.Orange); break;
                    case "Yellow": changedColor = new SolidColorBrush(Windows.UI.Colors.Yellow); break;
                    case "Green": changedColor = new SolidColorBrush(Windows.UI.Colors.Green); break;
                    case "White": changedColor = new SolidColorBrush(Windows.UI.Colors.White); break;
                    case "Gray": changedColor = new SolidColorBrush(Windows.UI.Colors.Gray); break;
                    case "Blue": changedColor = new SolidColorBrush(Windows.UI.Colors.Blue); break;
                    case "Purple": changedColor = new SolidColorBrush(Windows.UI.Colors.Purple); break;
                    case "Brown": changedColor = new SolidColorBrush(Windows.UI.Colors.Brown); break;
                    default: break;
                }
                Flag = false;
            }
        }
    }
}
