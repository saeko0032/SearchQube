using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchQube.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// プロパティ変更イベント
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Events

        #region Methods

        /// <summary>
        /// PropertyChanged()呼び出し
        /// </summary>
        /// <param name="propertyName">イベントを発生させたいプロパティ名</param>
        protected void CallPropertyChanged(string propertyName)
        {
            // イベント発生
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Methods
    }
}
