using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CRUD.Models;
using CRUD.Service;
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
            ContextUser.Role = Roles.FirstOrDefault(r => r.Id == ContextUser.RoleId);
        }
        DataContext = this;
    }

    private void BSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var errors = ValidationLine.Validation(ContextUser);
        if(string.IsNullOrEmpty(errors))
        {
            using(var db = new CrudContext())
            {
                ContextUser.RoleId=ContextUser.Role.Id;
               
                if (ContextUser.Id == 0)
                    
                    db.Users.Add(ContextUser);
                else
                    db.Entry(ContextUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                App.mainWindow.UCMainWindow.Content = new AllUser();
            }
        }
        else
        {
           new ErrorMessage(errors).Show();
        }
    }

    private void BBack_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.mainWindow.UCMainWindow.Content = new AllUser();
    }
}