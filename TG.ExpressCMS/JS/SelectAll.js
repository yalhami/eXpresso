function SelectAll(CheckBoxControl, RepeaterName) 
            {
	        if (CheckBoxControl.checked == true) 
		         {
			        var i;
			        for (i=0; i < document.forms[0].elements.length; i++) 
			         {
		              if ((document.forms[0].elements[i].type == 'checkbox') &&  
			           (document.forms[0].elements[i].name.indexOf(RepeaterName) > -1)) 
		              {
			            document.forms[0].elements[i].checked = true;
		               }
		             }
		          } 
		        else 
		         {
		           var i;
		           for (i=0; i < document.forms[0].elements.length; i++) 
		            {
		              if ((document.forms[0].elements[i].type == 'checkbox') && 
			          (document.forms[0].elements[i].name.indexOf(RepeaterName) > -1)) 
		               {
			              document.forms[0].elements[i].checked = false;
		               }
		            }
		         }
	        }  