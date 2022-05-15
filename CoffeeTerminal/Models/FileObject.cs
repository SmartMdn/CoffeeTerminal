using Prism.Mvvm;

namespace CoffeeTerminal.Models;

internal class FileObject : BindableBase
{
    #region String Override

    public override string ToString()
    {
        //.FormatString(this string myString) is an extension.
        var returnString = string.Empty;
        if (_fileName != string.Empty)
            returnString = $"File Name: {_fileName}.";
        return returnString;
    }

    #endregion String Override

    #region Properties

    #region Location

    private string? location = string.Empty;

    public string? Location
    {
        get => location;
        set
        {
            if (value != location)
                location = value;
            RaisePropertyChanged();
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
            if (value != _fileName)
                _fileName = value;
            RaisePropertyChanged();
        }
    }

    #endregion FileName

    #endregion Properties
}