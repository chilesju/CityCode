using System;
using Utilites;


namespace Constituent_Services.controls
{
	
	public interface  IIncidentTab
	{
		int IncidentId 
		{
			get;
			set;
		}
		Utilites.Assignment IndividualAssignment
		{
			get;
			set;
		}


		void Initialize();

	}
}
