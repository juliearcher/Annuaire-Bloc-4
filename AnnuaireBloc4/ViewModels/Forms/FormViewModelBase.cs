using AnnuaireBloc4.Commands;
using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Models;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public abstract class FormViewModelBase : ViewModelBase
	{
		protected enum EditMode
		{
			CREATE, UPDATE
		}

		protected EditMode _mode = EditMode.UPDATE;

		protected IMapper _mapper;

		private DataErrorModel _newElem;
		public DataErrorModel NewElem
		{
			get
			{
				return _newElem;
			}
			set
			{
				_newElem = value;
				OnPropertyChanged(nameof(NewElem));
			}
		}

		public ListViewModelBase ListViewModelBase { get; protected set; }

		public abstract Task<bool> SendToAPI();
		public abstract bool IsValid();
		public ICommand SaveElement => new SaveElement(this);
		public ICommand SaveElementAndClose => new SaveElement(this, closeWindow : true);
		public ICommand CloseWindowCommand => new SaveElement(this, save : false, closeWindow : true);
		
		public void CloseWindow(Window window) => window.Close();
	}
}
