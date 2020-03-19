using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControlDev.DB
{
    public class ValveDb :  INotifyPropertyChanged
    {
        private int barValue;
        private bool _OpenedStatus,_ClosedStatus,_AlarmStatus;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool opened_status
        {
            set
            {
                _OpenedStatus = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("opened_status"));
                }
            }
            get
            {
                return _OpenedStatus;
            }
        }
        public bool Closed_status
        {
            set
            {
                _ClosedStatus = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Closed_status"));
                }
            }
            get
            {
                return _ClosedStatus;
            }
        }
        public bool Alarm_status
        {
            set
            {
                _AlarmStatus = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Alarm_status"));
                }
            }
            get
            {
                return _AlarmStatus;
            }
        }
        public int Degree_status {
            set
            {
                barValue = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Degree_status"));
                }
            }

            get { return barValue; }
        }

        public bool open_command { set; get; }
        public bool Close_command { set; get; }
        public bool Mode_command{ set; get; }
        public int Degree_command{ set; get; }

        public string Name { set; get; }
    }
}
