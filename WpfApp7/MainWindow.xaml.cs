using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp7
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private string userName;
        private string score1;
        private string score2;
        private string score3;
        private string score4;
        private string score5;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public string Score1
        {
            get
            {
                return score1;
            }
            set
            {
                this.score1 = value;//value转到定义，?其实就是public int age//这里暂时不知道这种机制

                if (PropertyChanged != null)//如果没有点击实现接口，就没有propertychanged这个成员
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(Score1));
                }
            }
        }
        public string Score2
        {
            get
            {
                return score2;
            }
            set
            {
                this.score2 = value;

                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(Score2));
                }
            }
        }
        public string Score3
        {
            get
            {
                return score3;
            }
            set
            {
                this.score3 = value;

                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(Score3));
                }
            }
        }
        public string Score4
        {
            get
            {
                return score4;
            }
            set
            {
                this.score4 = value;

                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(Score4));
                }
            }
        }
        public string Score5
        {
            get
            {
                return score5;
            }
            set
            {
                this.score5 = value;

                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(Score5));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
