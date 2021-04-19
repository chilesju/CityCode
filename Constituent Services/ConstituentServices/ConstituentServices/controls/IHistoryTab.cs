using System;

namespace Constituent_Services.controls
{
	
	public interface IHistoryTab
	{
		int IncidentId 
		{
			get;
			set;
		}
		void Initialize();
	}
}
