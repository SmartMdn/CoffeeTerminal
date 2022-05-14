using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace CoffeeTerminal.Models
{
    internal class FileObject : BindableBase
    {
        #region Properties
        #region Location
        private string? location = string.Empty;
        public string? Location
        {
            get => location;
            set
            {
                if (value != this.location)
                    location = value;
                this.RaisePropertyChanged("Location");
            }
        }
        #endregion Location

        #region FileName
        private string _fileName = string.Empty;
        public string FileName
        {
            get => _fileName;
            set
            {
                if (value != this._fileName)
                    _fileName = value;
                this.RaisePropertyChanged("FileName");
            }
        }
        #endregion FileName
        #endregion Properties

        #region String Override
        public override string ToString()
        {
            //.FormatString(this string myString) is an extension.
            string returnString = string.Empty;
            if (this._fileName != string.Empty)
                returnString = $"File Name: {this._fileName}.";
            return returnString;
        }
        #endregion String Override
    }
}

