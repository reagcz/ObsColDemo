using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Obs.UWP.Models
{
    public class Number : INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged();
            }
        }

        private Guid _id;
        public Guid Id
        {
            get { if(_id.ToString() == Guid.Empty.ToString())
                {_id = Guid.NewGuid();}
                return _id; }

        }

        public void Increment()
        {
            Value += 1;
        }

        public void Decrement()
        {
            Value -= 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
