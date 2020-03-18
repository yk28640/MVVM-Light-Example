using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace mvvm_Light.ViewModel
{
    public class PageTwoViewModel : ViewModelBase
    {

        string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    RaisePropertyChanged("Text");

                    TitleTextChangedMessenger messenger = new TitleTextChangedMessenger { NewText = _text };
                    // 发布
                    Messenger.Default.Send<TitleTextChangedMessenger>(messenger);

                    // 这里是为了验证发布&订阅方法的同步，由此可以知道信使可以返回结果，相当于函数调用的返回值
                    string result = messenger.Result;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private string _P2Title;
        

        public string P2Title

        {
            get { return _P2Title; }
            set { Set(ref _P2Title, value); }
        }
        public ICommand ChangeTitleCommand { get; set; }
       // public ICommand Page2JumpCommand { get; set; }

        public PageTwoViewModel()
        {
            P2Title = "P2";
            Text = "send to mainwindow";
            ChangeTitleCommand = new RelayCommand(ChangeTitle);
            
           
        }
        int i = 0;
        private void ChangeTitle()
        {

            P2Title = "Hello MvvmLight Page2" +i++;
            Text= "send to mainwindow" + i++;
        }
    }
}
