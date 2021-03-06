using AnnuaireBloc4.Commands;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.PrepAPI.Services;
using AnnuaireBloc4.State.Navigators;
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

			#region Add ViewModel List Factories to ServiceCollecton
			services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
			services.AddSingleton<IViewModelListFactory<HomeViewModel>, HomeViewModelFactory>();
			services.AddSingleton<IViewModelListFactory<EmployeesViewModel>, EmployeesViewModelFactory>();
			services.AddSingleton<IViewModelListFactory<DepartmentListViewModel>, DepartmentListViewModelFactory>();
			services.AddSingleton<IViewModelListFactory<EmployeeListViewModel>, EmployeeListViewModelFactory>();
			services.AddSingleton<IViewModelListFactory<SiteListViewModel>, SiteListViewModelFactory>();
			#endregion

			#region Add ViewModel Form Factories to ServiceCollecton
			services.AddSingleton<IViewModelFormFactory<SiteFormViewModel>, SiteFormViewModelFactory>();
			services.AddSingleton<IViewModelFormFactory<DepartmentFormViewModel>, DepartmentFormViewModelFactory>();
			services.AddSingleton<IViewModelFormFactory<EmployeeFormViewModel>, EmployeeFormViewModelFactory>();
			#endregion

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddScoped<INavigator, Navigator>();
			services.AddScoped<MainWindowViewModel>();

			services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

			return services.BuildServiceProvider();
		}
	}
}
