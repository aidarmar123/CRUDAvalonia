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
    }

    private void BRemove_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
}