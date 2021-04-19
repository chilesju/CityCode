
var popUp; 
var popUp2

function OpenAddress(idname, postBack)
{
	popUp = window.open('SearchAddress.aspx?formname=' + document.forms[0].name + 
		'&id=' + idname + '&selected=' + document.forms[0].elements[idname].value + '&postBack=' + postBack, 
		'popupcal','scrollbars=yes,resizable=yes,width=550,height=500,left=200,top=250');
}

function SetAddress(formName, id, address, postBack)
{
	eval('var theform = document.' + formName + ';');
	popUp.close();
	
	theform.elements[id].value = address;
}	


function OpenComments(idname, postBack)
{
	popUp2= window.open('AddCommentsToResolution.aspx', null,'scrollbars=yes,resizable=yes,width=550,height=500,left=200,top=250');
	
}
function CloseComments()
{
	 popUp2.close();
	
}
function ChangeStreetText()
{
	var addressText = document.getElementById('txtAddress');
	var streetText = document.getElementById('txtStreetNumber');
	var directionText = document.getElementById('directionList');
	var roadText = document.getElementById('txtRoad');
	addressText.value= streetText.value + ' ' + directionText.options[directionText.selectedIndex].text + ' ' + roadText.value;

}	

function DisableStreet()
{
	var addressText = document.getElementById('txtIntersection');
	var streetText = document.getElementById('txtStreetNumber');
	var directionText = document.getElementById('directionList');
	var roadText = document.getElementById('txtRoad');
	if(addressText.value=='')
	{
		streetText.disabled=false;
		directionText.disabled=false;
		roadText.disabled=false;
	}
	else
	{
		streetText.disabled=true;
		directionText.disabled=true;
		roadText.disabled=true;
	}

}
function GetAddressText()
{
 var datetext= document.getElementById('txtChosenAddress');
 var list = document.getElementById('addressList');
 datetext.value=list.options[list.selectedIndex].text;
}
function DisablePersonalInfo()
{
	var checkbx =document.getElementById('chbxAnonymous');
	var first =document.getElementById('txtFirstName');
	var last =document.getElementById('txtLastName');
	var phone =document.getElementById('txtPhoneNumber');
	var email =document.getElementById('txtEmail');

	var yes = document.getElementById('rbtnYes');
	var no = document.getElementById('rbtnNo');

	if(checkbx.checked==true)
	{
		first.disabled=true;
		first.style.backgroundColor="#E0E0E0";
		last.disabled=true;
		last.style.backgroundColor="#E0E0E0";
		phone.disabled=true;
		phone.style.backgroundColor="#E0E0E0";
		email.disabled=true;
		email.style.backgroundColor="#E0E0E0";
	yes.checked=false;
	no.checked=true;


	}
	else
	{
		first.disabled=false;
		first.style.backgroundColor="";
		last.disabled=false;
		last.style.backgroundColor="";
		phone.disabled=false;
		phone.style.backgroundColor="";
		email.disabled=false;
		email.style.backgroundColor="";
		yes.checked=true;
		no.checked=false;

		}

}