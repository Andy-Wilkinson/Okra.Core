﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Core
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        // *** Events ***

        public event PropertyChangedEventHandler PropertyChanged;

        // *** Protected Methods ***

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected bool SetProperty<T>(ref T storage, T value, Expression<Func<T>> propertyExpression)
        {
            throw new NotImplementedException();
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            throw new NotImplementedException();
        }

        // *** Static Methods ***

        protected static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression)
        {
            throw new NotImplementedException();
        }
    }
}
