using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CRUD;

public partial class AllUser : UserControl
{
    public List<User> Users { get; set; }
    public AllUser()
    {
        InitializeComponent();
        using (CrudContext db = new CrudContext())
        {
            Users = db.Users.Include(x=>x.Role).ToList();
            DataContext=this;
        }
    }
    private void BAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
        App.mainWindow.UCMainWindow.Content = new AddEditUser(new User());
    }

    private void BEdit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if(DGUsers.SelectedItem is User user)
        {
            using(var db = new CrudContext())
            {
                user.Role = db.Roles.FirstOrDefault(r => r.Id == user.RoleId);
            }
             
            App.mainWindow.UCMainWindow.Content = new AddEditUser(user);
        }
    }

    private void BRemove_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DGUsers.SelectedItem is User user)
        {
            using(var db = new CrudContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                App.mainWindow.UCMainWindow.Content = new AllUser();
            }
        }
    }
}