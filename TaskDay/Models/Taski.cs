using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Models
{
    internal class Taski: INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _isDone;
        private string _text;

        

        public bool isDone
        {
            get { return _isDone; }
            set 
            { 
                if(_isDone == value)
                {
                    return;
                }
                _isDone = value;
                OnPropertyChanged("isDone");
            }
        }
        public string Text
        {
            get { return  _text; }
            set
            {
                if (_text == value)
                {
                    return;
                }
                _text = value;
                OnPropertyChanged("Text");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string properyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }
    }
}
