using System;

namespace Utilites
{
	/// <summary>
	/// Summary description for LinkTabs.
	/// </summary>
	public class LinkTabs
	{
		private string _name;
		private string _path;

		public LinkTabs(string newName, string newPath)
		{
			_name = newName;
			_path = newPath;
		}
		public string Name
		{
			get { return _name;}
			set { _name = value;}
		}

		public string Path 
		{
			get { return _path; }
			set { _path = value; }
		}
	}
}
