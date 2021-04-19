var popUp; 

function OpenCalendar(idname, postBack, expDate)
{
	popUp = window.open('Calendar.aspx?formname=' + document.forms[0].name + 
		'&id=' + idname + '&selected=' + document.forms[0].elements[idname].value + '&postBack=' + postBack +'&expDate=' +document.forms[0].elements[expDate].value +'&status='+ document.forms[0].elements['txtStatus'].value, 
		 'popupcal',
		'width=450,height=450');
}

function SetDate(formName, id, newDate, postBack)
{
	eval('var theform = document.' + formName + ';');
	popUp.close();
	theform.elements[id].value = newDate;
	theform.elements['txtRenew'].value='true';
	if(postBack)
	{
		__doPostBack(id,'');
		
     }
}

function CloseWindow(formName,status)
{

	eval('var theform = document.' + formName + ';');
	if(status=='ACTIVE')
	{
		theform.elements['btnRenew'].disabled=false;
		theform.elements['btnRenew'].value='Renew';
		theform.elements['btnDelete'].disabled=false;
		//theform.elements['btnActivate'].disabled=;
		theform.elements['btnPrint'].disabled=false;
		theform.elements['btnRevoke'].disabled=false;
		theform.elements['btnSurrender'].disabled=false;
		theform.elements['btnUpdateLicense'].disabled=false;
	}
	else if(status=='EXPIRED')
	{
	theform.elements['btnRenew'].disabled=false;
	theform.elements['btnRenew'].value='Renew';
	theform.elements['btnDelete'].disabled=false;
	//theform.elements['btnActivate'].disabled=false;
	//theform.elements['btnPrint'].disabled=false;
	//theform.elements['btnRevoke'].disabled=false;
	//theform.elements['btnSurrender'].disabled=false;
	//theform.elements['btnUpdateLicense'].disabled=false;
	}
	else if(status=="PENDING")
	{
	
	//theform.elements['btnRenew'].disabled=false;
	//theform.elements['btnRenew'].value='Renew';
	theform.elements['btnDelete'].disabled=false;
	//theform.elements['btnActivate'].disabled=false;
	//theform.elements['btnPrint'].disabled=false;
	//theform.elements['btnRevoke'].disabled=false;
	//theform.elements['btnSurrender'].disabled=false;
	//theform.elements['btnUpdateLicense'].disabled=false;
	
	}
	else
	{
		theform.elements['btnRenew'].disabled=false;
		theform.elements['btnRenew'].value='Renew';
		theform.elements['btnDelete'].disabled=false;
		theform.elements['btnActivate'].disabled=false;
		//theform.elements['btnPrint'].disabled=false;
		//theform.elements['btnRevoke'].disabled=false;
		//theform.elements['btnSurrender'].disabled=false;
		//theform.elements['btnUpdateLicense'].disabled=false;
	}
	popUp.close();				 
}
