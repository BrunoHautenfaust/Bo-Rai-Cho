namespace App1
{
    using Windows.UI.Xaml.Media;

    public static class ColorChanger
    {
        private static bool flag = false;
        private static string keyword;
        private static SolidColorBrush changedColor = new SolidColorBrush(Windows.UI.Colors.Black);
        private static SolidColorBrush black = new SolidColorBrush(Windows.UI.Colors.Black);
        private static SolidColorBrush red = new SolidColorBrush(Windows.UI.Colors.Red);
        private static SolidColorBrush orange = new SolidColorBrush(Windows.UI.Colors.Orange);
        private static SolidColorBrush yellow = new SolidColorBrush(Windows.UI.Colors.Yellow);
        private static SolidColorBrush green = new SolidColorBrush(Windows.UI.Colors.Green);
             
        private static SolidColorBrush white = new SolidColorBrush(Windows.UI.Colors.White);
        private static SolidColorBrush gray = new SolidColorBrush(Windows.UI.Colors.Gray);
        private static SolidColorBrush blue = new SolidColorBrush(Windows.UI.Colors.Blue);
        private static SolidColorBrush purple = new SolidColorBrush(Windows.UI.Colors.Purple);
        private static SolidColorBrush brown = new SolidColorBrush(Windows.UI.Colors.Brown);

        public static SolidColorBrush Black
        {
            get { return black; }
        }

        public static SolidColorBrush Red
        {
            get { return red; }
        }

        public static SolidColorBrush Orange
        {
            get { return orange; }
        }

        public static SolidColorBrush Yellow
        {
            get { return yellow; }
        }

        public static SolidColorBrush Green
        {
            get { return green; }
        }

        public static SolidColorBrush White
        {
            get { return white; }
        }

        public static SolidColorBrush Gray
        {
            get { return gray; }
        }

        public static SolidColorBrush Blue
        {
            get { return blue; }
        }

        public static SolidColorBrush Purple
        {
            get { return purple; }
        }

        public static SolidColorBrush Brown
        {
            get { return brown; }
        }

        public static SolidColorBrush ChangedColor
        {
            get { return changedColor; }
            set { changedColor = value; }
        }

        public static bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

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
                    case "Black": changedColor = Black; break;
                    case "Red": changedColor = Red; break;
                    case "Orange": changedColor = Orange; break;
                    case "Yellow": changedColor = Yellow; break;
                    case "Green": changedColor = Green; break;
                    case "White": changedColor = White; break;
                    case "Gray": changedColor = Gray; break;
                    case "Blue": changedColor = Blue; break;
                    case "Purple": changedColor = Purple; break;
                    case "Brown": changedColor = Brown; break;
                    default: break;
                }
                Flag = false;
            }
        }
    }
}
