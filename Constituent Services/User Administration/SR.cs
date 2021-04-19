using System;
using System.Resources;
using System.Globalization;

namespace User_Administration
{
	internal class SR
	{
		// Nested Types
		internal class Keys
		{
			// Fields
			public const string DatabaseConnectionError = "DatabaseConnectionError";
			public const string DeleteRoleConfirmation = "DeleteRoleConfirmation";
			public const string DeleteUserConfirmation = "DeleteUserConfirmation";
			public const string DeleteUserConfirmationCaption = "DeleteUserConfirmationCaption";
			public const string MustCreateRole = "MustCreateRole";
			public const string MustSelectRoleToDelete = "MustSelectRoleToDelete";
			public const string MustSelectUserToAdd = "MustSelectUserToAdd";
			public const string MustSelectUserToDelete = "MustSelectUserToDelete";
			public const string MustSelectUserToRemove = "MustSelectUserToRemove";
			public const string NewPasswordLabel = "NewPasswordLabel";
			public const string NoDatabaseExceptionMessage = "NoDatabaseExceptionMessage";
			public const string PasswordsMustMatch = "PasswordsMustMatch";
			//private static ResourceManager resourceManager;
			public const string RoleAlreadyExists = "RoleAlreadyExists";
			public const string UnhandledException = "UnhandledException";
			public const string UserAlreadyExists = "UserAlreadyExists";
			public const string UsersInRole = "UsersInRole";
			
			public static string GetString(string key)
			{
				//return SR.Keys.resourceManager.GetString(key, CultureInfo.CurrentUICulture);
				return key;
			}
 
			public static string GetString(string key, params object[] args)
			{
				//string text1 = SR.Keys.resourceManager.GetString(key, CultureInfo.CurrentUICulture);
				//return string.Format(text1, args);
				return key;
			}
		}
		public static string DatabaseConnectionError
		{
			get
			{
				return SR.Keys.GetString("Database Connection Error");
			}
		}
		public static string DeleteRoleConfirmation
		{
			get
			{
				return SR.Keys.GetString("Delete Role Confirmation");
			}
		}
 
		public static string DeleteUserConfirmation
		{
			get
			{
				return SR.Keys.GetString("Are you sure you want to delete this user");
			}
		}
 
		public static string DeleteUserConfirmationCaption
		{
			get
			{
				return SR.Keys.GetString("Delete User Confirmation Caption");
			}
		}
 
		public static string MustCreateRole
		{
			get
			{
				return SR.Keys.GetString("Must Create Role");
			}
		}
 
		public static string MustSelectRoleToDelete
		{
			get
			{
				return SR.Keys.GetString("Must Select Role To Delete");
			}
		}
 
		public static string MustSelectUserToAdd
		{
			get
			{
				return SR.Keys.GetString("Must Select User T oAdd");
			}
		}
 
		public static string MustSelectUserToDelete
		{
			get
			{
				return SR.Keys.GetString("Must Select User To Delete");
			}
		}
 
		public static string MustSelectUserToRemove
		{
			get
			{
				return SR.Keys.GetString("Must SelectUser To Remove");
			}
		}
 
		public static string NewPasswordLabel
		{
			get
			{
				return SR.Keys.GetString("New Password Label");
			}
		}
 
		public static string PasswordsMustMatch
		{
			get
			{
				return SR.Keys.GetString("Passwords Must Match");
			}
		}
 
		public static string RoleAlreadyExists
		{
			get
			{
				return SR.Keys.GetString("Role Already Exists");
			}
		}
 
		public static string UnhandledException
		{
			get
			{
				return SR.Keys.GetString("Unhandled Exception");
			}
		}
 
		public static string UserAlreadyExists
		{
			get
			{
				return SR.Keys.GetString("User Already Exists");
			}
		}
        public static string UserUpdated
        {
            get
            {
                return SR.Keys.GetString("User Updated");
            }
        }
        public static string UserCreated
        {
            get
            {
                return SR.Keys.GetString("User Created");
            }
        }
		public static string NoDatabaseExceptionMessage(string paragraphSeparator1, string paragraphSeparator2, string paragraphSeparator3, string exceptionMessage)
		{
			object[] objArray1 = new object[4] { paragraphSeparator1, paragraphSeparator2, paragraphSeparator3, exceptionMessage } ;
			return SR.Keys.GetString("NoDatabaseExceptionMessage", objArray1);
		}
 
		public static string UsersInRole(string role)
		{
			object[] objArray1 = new object[1] { role } ;
			return SR.Keys.GetString("UsersInRole", objArray1);
		}
 

 

	}
}
