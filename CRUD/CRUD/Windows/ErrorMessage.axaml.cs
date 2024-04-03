using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CRUD;

public partial class ErrorMessage : Window
{
    public string ErrorMsg {  get; set; }

    public ErrorMessage(string message)
    {
        InitializeComponent();
        ErrorMsg = message;
        DataContext=this;
    }
}