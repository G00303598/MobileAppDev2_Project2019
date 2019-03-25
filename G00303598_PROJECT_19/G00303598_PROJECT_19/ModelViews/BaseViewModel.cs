using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace G00303598_PROJECT_19
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(
             [CallerMemberName] string thisProperty = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(thisProperty));
        }

        // Generic method
        // Passing by reference, rather than value -- default is value
        // For persistent change, pass by reference
        protected void SetValue<T>(ref T backingField, T value,
            [CallerMemberName] string propName = null)
        {
            //single set value method to use across all classes
            // use equalityComparer class to compare generic types
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
            backingField = value;
            OnPropertyChanged(propName);
        }
    }
}
