using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Example.Common;
using Example.ViewModels.Annotations;

namespace Example.ViewModels
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {

        public String Title
        {
            get
            {
                return (string)Settings.Get("Title");
            }
            set
            {
                Settings.Edit("Title", value);
                OnPropertyChanged("Title");
            }
        }
        public String Row1
        {
            get
            {
                return (string)Settings.Get("Row1");
            }
            set
            {
                Settings.Edit("Row1", value);
                OnPropertyChanged("Row1");
            }
        }
        public bool Row1Bold
        {
            get
            {
                return (bool)Settings.Get("Row1Bold");
            }
            set
            {
                Settings.Edit("Row1Bold", value);
                OnPropertyChanged("Row1Bold");
            }
        }
        public bool Row1Italic
        {
            get
            {
                return (bool)Settings.Get("Row1Italic");
            }
            set
            {
                Settings.Edit("Row1Italic", value);
                OnPropertyChanged("Row1Italic");
            }
        }
        public String Row2
        {
            get
            {
                return (string)Settings.Get("Row2");
            }
            set
            {
                Settings.Edit("Row2", value);
                OnPropertyChanged("Row2");
            }
        }
        public bool Row2Bold
        {
            get
            {
                return (bool)Settings.Get("Row2Bold");
            }
            set
            {
                Settings.Edit("Row2Bold", value);
                OnPropertyChanged("Row2Bold");
            }
        }
        public bool Row2Italic
        {
            get
            {
                return (bool)Settings.Get("Row2Italic");
            }
            set
            {
                Settings.Edit("Row2Italic", value);
                OnPropertyChanged("Row2Italic");
            }
        }


        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
