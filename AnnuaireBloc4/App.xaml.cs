using AnnuaireBloc4.Commands;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.PrepAPI.Services;
using AnnuaireBloc4.State.Navigators;
using AnnuaireBloc4.State.NewWindow;
using AnnuaireBloc4.ViewModels;
using AnnuaireBloc4.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AnnuaireBloc4
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			IServiceProvider serviceProvider = CreateServiceProvider();

			Window window = serviceProvider.GetRequiredService<MainWindow>();
			window.Show();
			base.OnStartup(e);
		}

		private IServiceProvider CreateServiceProvider()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddSingleton<IDepartmentsService, DepartmentsService>();
			services.AddSingleton<IEmployeesService, EmployeesService>();
			services.AddSingleton<ISitesService, SitesService>();

			services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
			services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
			services.AddSingleton<IViewModelFactory<EmployeesViewModel>, EmployeesViewModelFactory>();
			services.AddSingleton<IViewModelFactory<DepartmentListViewModel>, DepartmentListViewModelFactory>();
			services.AddSingleton<IViewModelFactory<EmployeeListViewModel>, EmployeeListViewModelFactory>();
			services.AddSingleton<IViewModelFactory<SiteListViewModel>, SiteListViewModelFactory>();

			services.AddSingleton<IViewModelFormFactory<SiteFormViewModel>, SiteFormViewModelFactory>();

			services.AddScoped<NewWindow>();

			services.AddScoped<INavigator, Navigator>();
			services.AddScoped<MainWindowViewModel>();

			services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

			return services.BuildServiceProvider();
		}
	}
}
