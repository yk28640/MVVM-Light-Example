using CustomControlDev.DB;
using System;
using System.Collections.Generic;
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

namespace CustomControlDev
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<ValveDb> ValveDbList;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValveDbList[0].opened_status = !ValveDbList[0].opened_status;


        }
        private void DoTask()
        {
            Random rd = new Random();
            Int64 InputNum = (Int64)1000;
            for (Int64 i = 0; i < InputNum; i++)
            {
                Thread.Sleep(1000);
                this.Dispatcher.BeginInvoke((Action)delegate ()
                {
                    ValveDbList[0].Degree_status= rd.Next(100);
                    
                });
            }
        }
            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ValveDbList[0].Closed_status = !ValveDbList[0].Closed_status;
            Thread taskThread = new Thread(DoTask);
            taskThread.Start();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ValveDbList[0].Alarm_status = !ValveDbList[0].Alarm_status;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //模拟数据源，模拟十个阀门
             ValveDbList = new List<ValveDb>();
            for (int i = 0; i < 10; i++)
            {
                int j = i;
                j++;
                ValveDbList.Add(new ValveDb() { Name = "Valve_" + j, opened_status = false, Closed_status = false, Alarm_status = false });
            }
            //绑定 数据源
            foreach (Control obj in this.CanvasBackground.Children) //遍历画布里的每个控件
            {
                if (obj.GetType().Name=="Valve") //如果是阀门控件 
                {
                    foreach (var ValveDbSet in ValveDbList) 
                    {
                        if (ValveDbSet.Name==obj.Name) //阀门控件的名字如果在数据库里有就绑定数据
                        {
                            //ValveDbList[0].Degree_status = 60;
                            //绑定 控件的依赖属性到外部数据源
                            obj.SetBinding(Valve.BarBindingProperty, new Binding("Degree_status") { Source = ValveDbSet, Mode = BindingMode.TwoWay });
                            obj.SetBinding(Valve.ClosedBindingProperty, new Binding("Closed_status") { Source = ValveDbSet, Mode = BindingMode.TwoWay });
                            obj.SetBinding(Valve.OpenedBindingProperty, new Binding("opened_status") { Source = ValveDbSet, Mode = BindingMode.TwoWay });
                            obj.SetBinding(Valve.AlarmBindingProperty, new Binding("Alarm_status") { Source = ValveDbSet, Mode = BindingMode.TwoWay });
                        }
                    }

                   
                }
            }

          
        }
    }
}
