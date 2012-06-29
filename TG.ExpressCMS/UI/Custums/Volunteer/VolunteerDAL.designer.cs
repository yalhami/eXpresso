﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TG.ExpressCMS.UI.Custums.Volunteer
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CMS_EXPRESS")]
	public partial class VolunteerDALDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertVolunteer(Volunteer instance);
    partial void UpdateVolunteer(Volunteer instance);
    partial void DeleteVolunteer(Volunteer instance);
    #endregion
		
		public VolunteerDALDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["CMS_EXPRESSConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public VolunteerDALDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VolunteerDALDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VolunteerDALDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VolunteerDALDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Volunteer> Volunteers
		{
			get
			{
				return this.GetTable<Volunteer>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertVolunteer")]
		public int InsertVolunteer([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] ref System.Nullable<int> iD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NAME", DbType="NVarChar(50)")] string nAME, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EMAIL", DbType="NVarChar(50)")] string eMAIL, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MESSAGE", DbType="NText")] string mESSAGE, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CV", DbType="NVarChar(500)")] string cV)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, nAME, eMAIL, mESSAGE, cV);
			iD = ((System.Nullable<int>)(result.GetParameterValue(0)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SelectallVolunteer")]
		public ISingleResult<SelectallVolunteerResult> SelectallVolunteer()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<SelectallVolunteerResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SelectVolunteerByID")]
		public ISingleResult<SelectVolunteerByIDResult> SelectVolunteerByID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD);
			return ((ISingleResult<SelectVolunteerByIDResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.UpdateVolunteer")]
		public int UpdateVolunteer([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NAME", DbType="NVarChar(50)")] string nAME, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EMAIL", DbType="NVarChar(50)")] string eMAIL, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MESSAGE", DbType="NText")] string mESSAGE, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CV", DbType="NVarChar(500)")] string cV)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, nAME, eMAIL, mESSAGE, cV);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.DeleteVolunteer")]
		public int DeleteVolunteer([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Volunteer")]
	public partial class Volunteer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _NAME;
		
		private string _EMAIL;
		
		private string _MESSAGE;
		
		private string _CV;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNAMEChanging(string value);
    partial void OnNAMEChanged();
    partial void OnEMAILChanging(string value);
    partial void OnEMAILChanged();
    partial void OnMESSAGEChanging(string value);
    partial void OnMESSAGEChanged();
    partial void OnCVChanging(string value);
    partial void OnCVChanged();
    #endregion
		
		public Volunteer()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAME", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string NAME
		{
			get
			{
				return this._NAME;
			}
			set
			{
				if ((this._NAME != value))
				{
					this.OnNAMEChanging(value);
					this.SendPropertyChanging();
					this._NAME = value;
					this.SendPropertyChanged("NAME");
					this.OnNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMAIL", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string EMAIL
		{
			get
			{
				return this._EMAIL;
			}
			set
			{
				if ((this._EMAIL != value))
				{
					this.OnEMAILChanging(value);
					this.SendPropertyChanging();
					this._EMAIL = value;
					this.SendPropertyChanged("EMAIL");
					this.OnEMAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MESSAGE", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string MESSAGE
		{
			get
			{
				return this._MESSAGE;
			}
			set
			{
				if ((this._MESSAGE != value))
				{
					this.OnMESSAGEChanging(value);
					this.SendPropertyChanging();
					this._MESSAGE = value;
					this.SendPropertyChanged("MESSAGE");
					this.OnMESSAGEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CV", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string CV
		{
			get
			{
				return this._CV;
			}
			set
			{
				if ((this._CV != value))
				{
					this.OnCVChanging(value);
					this.SendPropertyChanging();
					this._CV = value;
					this.SendPropertyChanged("CV");
					this.OnCVChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class SelectallVolunteerResult
	{
		
		private int _ID;
		
		private string _NAME;
		
		private string _EMAIL;
		
		private string _MESSAGE;
		
		private string _CV;
		
		public SelectallVolunteerResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAME", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string NAME
		{
			get
			{
				return this._NAME;
			}
			set
			{
				if ((this._NAME != value))
				{
					this._NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMAIL", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string EMAIL
		{
			get
			{
				return this._EMAIL;
			}
			set
			{
				if ((this._EMAIL != value))
				{
					this._EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MESSAGE", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string MESSAGE
		{
			get
			{
				return this._MESSAGE;
			}
			set
			{
				if ((this._MESSAGE != value))
				{
					this._MESSAGE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CV", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string CV
		{
			get
			{
				return this._CV;
			}
			set
			{
				if ((this._CV != value))
				{
					this._CV = value;
				}
			}
		}
	}
	
	public partial class SelectVolunteerByIDResult
	{
		
		private int _ID;
		
		private string _NAME;
		
		private string _EMAIL;
		
		private string _MESSAGE;
		
		private string _CV;
		
		public SelectVolunteerByIDResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAME", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string NAME
		{
			get
			{
				return this._NAME;
			}
			set
			{
				if ((this._NAME != value))
				{
					this._NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMAIL", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string EMAIL
		{
			get
			{
				return this._EMAIL;
			}
			set
			{
				if ((this._EMAIL != value))
				{
					this._EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MESSAGE", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string MESSAGE
		{
			get
			{
				return this._MESSAGE;
			}
			set
			{
				if ((this._MESSAGE != value))
				{
					this._MESSAGE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CV", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string CV
		{
			get
			{
				return this._CV;
			}
			set
			{
				if ((this._CV != value))
				{
					this._CV = value;
				}
			}
		}
	}
}
#pragma warning restore 1591