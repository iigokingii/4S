using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для TextBl.xaml
    /// </summary>
   
    public partial class TextBl : UserControl
    {
        public static DependencyProperty TitleProperty;
        public static DependencyProperty MaxLengthProperty;
        public TextBl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        static TextBl()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TextBl));
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(TextBl), metadata, new ValidateValueCallback(ValidateValue));
        }
        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int CurrentValue = (int)baseValue;
            if (CurrentValue < 0)
            {
                return 1;
            }
            if (CurrentValue > 1000)
            {
                return 1000;
            }
            return CurrentValue;
        }
        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            return true;
            /*if (currentValue >= 0)
                return true;
            return false;*/
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

    }
}
