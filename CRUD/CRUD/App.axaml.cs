using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System.Runtime.CompilerServices;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CRUD.Models;
using CRUD.Models.MetaData;

namespace CRUD
{
    public partial class App : Application
    {
        public static MainWindow mainWindow;
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public App()
        {
            RegestrDescriptor();
        }


        private void RegestrDescriptor()
        {
            AddDescriptor<User, MetaUser>();
        }

        private void AddDescriptor<T,A>()
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T),typeof(A));
            TypeDescriptor.AddProviderTransparent(provider, typeof(T));
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}