using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Input;
using System.Windows.Navigation;

namespace mvvm_Light.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private string title;
        public static NavigationWindow window { get; private set; }
       
        public string Title

        {
            get { return title; }
            set { Set(ref title, value); }
        }
        public ICommand ChangeTitleCommand { get; set; }
        public ICommand Page2JumpCommand { get; set; }

        public MainViewModel()
        {
            Title = "Hello World";
            ChangeTitleCommand = new RelayCommand(ChangeTitle);
            Page2JumpCommand = new RelayCommand(Page2Jump);

            // ¶©ÔÄ
            Messenger.Default.Register<TitleTextChangedMessenger>(this, (messenger) =>
            {
                Title = messenger.NewText;
                messenger.Result = "Success";
            });
        }
        private void ChangeTitle()
        {
            Title = "Hello MvvmLight";
        }
        private void Page2Jump()
        {
            if (window ==null)
            {
                window = new NavigationWindow();
                window.Closed += Window_Closed; 

                window.Source = new Uri("Page2.xaml", UriKind.Relative);


                window.Show();

            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            window = null;
        }
    }
}