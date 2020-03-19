using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace CustomControlDev
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControlDev"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControlDev;assembly=CustomControlDev"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:Valve/>
    ///
    /// </summary>
    public class Valve : Control
    {
        #region Dpendency Property claim
        private static readonly DependencyProperty FillBindingProperty = DependencyProperty.Register(
          "FillBinding", typeof(Brush), typeof(Valve));

        public static readonly DependencyProperty BarBindingProperty = DependencyProperty.Register(
          "BarBinding", typeof(int), typeof(Valve));


        //这三个状态如果任何其中一个变化，则调用函数刷新阀门颜色
        public static readonly DependencyProperty OpenedBindingProperty = DependencyProperty.Register(
         "Status_Opened", typeof(bool), typeof(Valve), new PropertyMetadata(false, (obj, e) => { CalculateStatus(obj); }));
        public static readonly DependencyProperty ClosedBindingProperty = DependencyProperty.Register(
        "Status_Closed", typeof(bool), typeof(Valve), new PropertyMetadata(false, (obj,e)=> { CalculateStatus(obj); }));     
        public static readonly DependencyProperty AlarmBindingProperty = DependencyProperty.Register(
       "Status_Alarm", typeof(bool), typeof(Valve), new PropertyMetadata(false, (obj, e) => { CalculateStatus(obj); }));

        #endregion

        //private static bool status_opened, status_closed, status_alarm;

        static bool AlarmingFlag = false;
        static DispatcherTimer timer = new DispatcherTimer();

        public bool Status_Closed
        {
            get
            {
                return (bool)GetValue(ClosedBindingProperty);
            }

            set
            {
                SetValue(ClosedBindingProperty, value);



            }
        }
        public bool Status_Opened
        {
            get
            {
                return (bool)GetValue(OpenedBindingProperty);
            }

            set
            {
                SetValue(OpenedBindingProperty, value);


            }
        }
        public bool Status_Alarm
        {
            get
            {
                return (bool)GetValue(AlarmBindingProperty);
            }

            set
            {

                SetValue(AlarmBindingProperty, value);


            }
        }

        
        private static void CalculateStatus(DependencyObject obj)
        {
            if ((bool)obj.GetValue(AlarmBindingProperty) && !AlarmingFlag)
            {
                AlarmingFlag = true;
                bool Flag = false; 
                
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Tick += new EventHandler(timer_Tick);
                
                void timer_Tick(object sender, EventArgs args)
                {
                    if (!Flag)
                    {
                        obj.SetValue(FillBindingProperty, Brushes.Red);

                    }
                    else
                    {
                        obj.SetValue(FillBindingProperty, Brushes.White);
                    }
                    Flag = !Flag;
                }
                
                timer.Start();
            }
            else
            {
                if (!(bool)obj.GetValue(AlarmBindingProperty))
                {
                    AlarmingFlag = false;
                    timer.Stop();



                    bool Status_Closed = (bool)obj.GetValue(ClosedBindingProperty);
                    bool Status_Opened = (bool)obj.GetValue(OpenedBindingProperty);

                    if (Status_Closed && !Status_Opened)
                    {
                        obj.SetValue(FillBindingProperty, Brushes.Black);
                    }
                    else if (!Status_Closed && Status_Opened)
                    {
                        obj.SetValue(FillBindingProperty, Brushes.Green);
                    }
                    else if (Status_Closed && Status_Opened)
                    {
                        obj.SetValue(FillBindingProperty, Brushes.Yellow);
                    }
                    else
                    {
                        obj.SetValue(FillBindingProperty, Brushes.Yellow);
                    }
                }
            }
        }

        protected Brush FillBinding
        {
            get
            {
                return (Brush)GetValue(FillBindingProperty);
            }
            set
            {
                SetValue(FillBindingProperty, value);
            }
        }
        public int BarBinding
        {
            get
            {
                return (int)GetValue(BarBindingProperty);
            }
            set
            {
                SetValue(BarBindingProperty, value);
            }
        }

        #region 点击事件 
        public static RoutedEvent ClickEvent =
       EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Valve));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        protected virtual void OnClick()
        {
            RoutedEventArgs args = new RoutedEventArgs(ClickEvent, this);
            RaiseEvent(args);
            PopWindow popWindow = new PopWindow();
            
            popWindow.opened = Status_Opened;
            popWindow.ShowDialog();
        }

        protected override void OnMouseLeftButtonUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            OnClick();
        }

        #endregion

        static Valve()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Valve), new FrameworkPropertyMetadata(typeof(Valve)));
        }
    }


    
}
