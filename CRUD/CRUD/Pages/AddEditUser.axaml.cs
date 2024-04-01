using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CRUD.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace CRUD;

public partial class AddEditUser : UserControl
{
    public User ContextUser { get; set; }
    public List<Role> Roles { get; set; }
    public AddEditUser(User user)
    {
        InitializeComponent();
        ContextUser = user;
        using(var db = new CrudContext())
        {
            Roles=db.Roles.ToList();
            
        }
        DataContext = this;
    }

    private void BSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void BBack_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
}