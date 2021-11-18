using Annuaire_Bloc_4.PrepAPI.Services;
using Annuaire_Bloc_4.PrepAPI.Services;
using Annuaire_Bloc_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Annuaire_Bloc_4
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			Window window = new MainWindow();
			window.DataContext = new MainWindowViewModel();
			window.Show();
			base.OnStartup(e);
		}
	}
}
