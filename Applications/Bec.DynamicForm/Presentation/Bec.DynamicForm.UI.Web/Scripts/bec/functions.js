function hideshowhipdiv() {


    if (document.getElementById('ctl00_ContentPlaceHolder1_rd38_16').checked)
        document.getElementById('ctl00_ContentPlaceHolder1_divHiden').style.display = 'inline';
    else
        document.getElementById('ctl00_ContentPlaceHolder1_divHiden').style.display = 'none';
   
}
function Confirm_Delete() {
    if (confirm("Are you sure you want to delete this record"))
        return true;
    return false;
}

function toggleDisplayByRadio(divId,src) {



    if (document.getElementById(src).checked)
        document.getElementById(divId).style.display = 'inline';
    else
        document.getElementById(divId).style.display = 'none';

}
function toggleDisplayByRadioDouble(div1,div2, src) {



    if (document.getElementById(src).checked) {
        document.getElementById(div1).style.display = 'inline';
        document.getElementById(div2).style.display = 'none';
    }
    else {
        document.getElementById(div1).style.display = 'none';
        document.getElementById(div2).style.display = 'inline';
    }

}
function toggleDisplayByRadioDoubleSame(div1, div2, src) {



    if (document.getElementById(src).checked) {
        document.getElementById(div1).style.display = 'inline';
        document.getElementById(div2).style.display = 'inline';
    }
    else {
        document.getElementById(div1).style.display = 'none';
        document.getElementById(div2).style.display = 'none';
    }

}
function toggleDisplayByDropdownDouble(div1, div2, src) {


    var lstBx = document.getElementById(src);
    if (lstBx.selectedIndex >= 0) {

        var text = lstBx.options[lstBx.selectedIndex].text;
        if (text == "Yes") {
            document.getElementById(div1).style.display = 'inline';
            document.getElementById(div2).style.display = 'none';
        }
        else {
            document.getElementById(div1).style.display = 'none';
            document.getElementById(div2).style.display = 'inline';
        }
    }

}
function sametoggleDisplayByDropdown(div1, div2, src) {


    var lstBx = document.getElementById(src);
    if (lstBx.selectedIndex >= 0) {

        var text = lstBx.options[lstBx.selectedIndex].text;
        if (text == "Yes") {
            document.getElementById(div1).style.display = 'inline';
            document.getElementById(div2).style.display = 'inline';
        }
        else {
            document.getElementById(div1).style.display = 'none';
            document.getElementById(div2).style.display = 'none';
        }
    }

}

function toggleDisplay(divId, src, choices) {
    var lstBx = document.getElementById(src);
    if (lstBx.selectedIndex >= 0) {
       var text = lstBx.options[lstBx.selectedIndex].value;
       var array = choices.split("||");
       if (!Array.prototype.indexOf) {
           Array.prototype.indexOf = function (obj) {
               for (var i = (0), j = this.length; i < j; i++) {
                   if (this[i] === obj) { return i; }
               }
               return -1;

           }

       }
       var index = array.indexOf(text);
      
       if (index >-1)
           document.getElementById(divId).style.display = 'none';
        else
            document.getElementById(divId).style.display = 'inline';
    }
}

function toggleDisplayMultiple(divId, src, choices) {
    var lstBx = document.getElementById(src);
    if (lstBx.selectedIndex >= 0) {
        var text = lstBx.options[lstBx.selectedIndex].value;
        var array = choices.split("||");
        if (!Array.prototype.indexOf) {
            Array.prototype.indexOf = function (obj) {
                for (var i = (0), j = this.length; i < j; i++) {
                    if (this[i] === obj) { return i; }
                }
                return -1;

            }

        }
        var index = array.indexOf(text);
        var divArray = divId.split("||");
       
        if (index > -1) {
            for (var i = 0; i < divArray.length; i++) {
                document.getElementById(divArray[i]).style.display = 'inline';
            }
        }
        else {
            for (var i = 0; i < divArray.length; i++) {
                document.getElementById(divArray[i]).style.display = 'none';
            }
           
        }
    }
}

function toggleDisplayRadioBtnList(cnt, divId, radio, choices) {
var rd = document.getElementsByName(radio);

var array = choices.split("||");
var divArray = divId.split("||");

    for (var j = 0; j < cnt; j++) {
        var rdItem = radio + "_" + j.toString();
     
        if (!Array.prototype.indexOf) {
            Array.prototype.indexOf = function (obj) {
                for (var i = (0), j = this.length; i < j; i++) {
                    if (this[i] === obj) { return i; }
                }
                return -1;

            }
       
        }
      
             var index = array.indexOf(document.getElementById(rdItem).value);

        if (document.getElementById(rdItem).checked && index > -1) {
            for (var i = 0; i < divArray.length; i++) {
              
                 document.getElementById(divArray[i]).style.display = 'inline';
            }
            break;
        }
        else {
            for (var i = 0; i < divArray.length; i++) {
               
                document.getElementById(divArray[i]).style.display = 'none';
            }
        } 
    }
}

function toggleDisplayCheckBoxList(divId, checkBox, choices) {

    var elementRef = document.getElementById(checkBox);
    var checkBoxArray = elementRef.getElementsByTagName('input');
  
    var array = choices.split("||");
    var divArray = divId.split("||");

     for (var i = 0; i < divArray.length; i++) {
                document.getElementById(divArray[i]).style.display = 'none';
            }

    for (var i = 0; i < checkBoxArray.length; i++) {
        var checkBoxRef = checkBoxArray[i];
        var chkItem = checkBox + "_" + i.toString();
        var labelArray = checkBoxRef.parentNode.getElementsByTagName('label');

        if (!Array.prototype.indexOf) {
            Array.prototype.indexOf = function (obj) {
                for (var i = (0), j = this.length; i < j; i++) {
                    if (this[i] === obj) { return i; }
                }
                return -1;

            }
          
        }
        var index = array.indexOf(labelArray[0].innerHTML);
        if (document.getElementById(chkItem).checked == true && index > -1) {
              for (var i = 0; i < divArray.length; i++) {
                document.getElementById(divArray[i]).style.display = 'inline';
            }
            break;
        }
    }
//    

//    for (var j = 0; j < cnt; j++) {
//        var rdItem = checkBox + "_" + j.toString();
//        var labelArray = rdItem.parentNode.getElementsByTagName('label');
//        alert(labelArray[0].innerHTML);

//        var index = array.indexOf(document.getElementById(rdItem).value);
//        if (document.getElementById(rdItem).checked && index > -1) {
//          
//            for (var i = 0; i < divArray.length; i++) {
//                document.getElementById(divArray[i]).style.display = 'inline';
//            }
//            break;
//        }
//        else {
//            for (var i = 0; i < divArray.length; i++) {
//                document.getElementById(divArray[i]).style.display = 'none';
//            }
//        }
//    }
}

    function toggleMultipleDiv(divId, isVisible) {
      
    var divArray = divId.split("||");

    for (var i = 0; i < divArray.length; i++) {
        if (isVisible == 1)
            document.getElementById(divArray[i]).style.display = 'inline';
    else
        document.getElementById(divArray[i]).style.display = 'none';
    }

}

function toggleDisplayByDropdown(divId, src,notEqualToMe) {


    var lstBx = document.getElementById(src);
    if (lstBx.selectedIndex >= 0) {

        var text = lstBx.options[lstBx.selectedIndex].text;

        if (text =="Yes")
            document.getElementById(divId).style.display = 'inline';
        else
            document.getElementById(divId).style.display = 'none';
    }
}
function hideDisplayItemsbyNo(divId, src, notEqualToMe) {


    var lstBx = document.getElementById(src);
    if (lstBx.selectedIndex >= 0) {

        var text = lstBx.options[lstBx.selectedIndex].text;

        if (text == "No")
            document.getElementById(divId).style.display = 'none';
        else
            document.getElementById(divId).style.display = 'inline';
    }
}

//function toggleDisplayByDropdownChoice(divId, src, choices) {


//    var lstBx = document.getElementById(src);
//    if (lstBx.selectedIndex >= 0) {

//        var text = lstBx.options[lstBx.selectedIndex].text;

//        if (text == choices)
//            document.getElementById(divId).style.display = 'none';
//        else
//            document.getElementById(divId).style.display = 'inline';
//    }
//}

// postback to Server

function fnClickUpdate(sender, e) {
    __doPostBack(sender, e);
}
//

function fnhidePopUp(div) {
    $find('pnlPostcodeFinder').hide();
}



        function checkAgreement(source, args) {
            var elem = document.getElementById('ctl00_Centercontentplaceholder_chkAgree');
            if (elem.checked) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }

        function checkAge(source, args) {
            var elem = document.getElementById('<%= chkAgree.ClientID %>');
            if (elem.checked) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        } 
 
    
