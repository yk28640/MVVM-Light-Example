using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Runtime.CompilerServices;


namespace WpfApp6
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    
        public partial class MainWindow : INotifyPropertyChanged
        {
            public MainWindow()
            {
                DataContext = this;
                InitializeComponent();
            }


            private void Reset_Click(object sender, RoutedEventArgs e)
            {
                BoundNumber = 0;
            }


            private int _boundNumber;
            public int BoundNumber
            {
                get { return _boundNumber; }
                set
                {
                    if (_boundNumber != value)
                    {
                        _boundNumber = value;
                        OnPropertyChanged();
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }



        }
    }

