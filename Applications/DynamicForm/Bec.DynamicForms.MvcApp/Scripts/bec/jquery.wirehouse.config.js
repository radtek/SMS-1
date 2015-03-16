/************************
  Wirehouse Jquery Config
  Author: Matt Litherland
  Date: 15/07/2010
************************/ 

//Top Nav 
$("#topnav li:last-child").addClass("last-child");

//Default Table
$("table tr:nth-child(even)").css("background", "#f8f8f8");
$("table tr:first-child").addClass("first-child");

//Tables + Lists
$(".db_docs tr:nth-child(odd)").css("background", "#f8f8f8"); ;
$(".db_issues tr:nth-child(even)").css("background","#f8f8f8");
$(".user_logs tr:nth-child(even)").css("background","#f8f8f8");
$(".news tr:nth-child(even)").css("background","#f8f8f8");
$(".users tr:nth-child(even)").css("background", "#f8f8f8");

$(".no_alt_table tr:nth-child(even)").css("background", "#f8f8f8");
$(".no_alt_table tr:nth-child(odd)").css("background", "#f8f8f8");


$(".simpleTable tr:nth-child(even)").css("background", "#ffffff");
$(".simpleTable tr:nth-child(odd)").css("background", "#ffffff");

$("#settings_wrap ul.account li:last-child").addClass("last-child");
$("#form_wrap .form_col:first-child").addClass("first-child");
$("#bc_topmenu li:last-child").addClass("ie");
$("#bc_topmenu li:last-child a").addClass("ie");

//Breadcrumb
$(".breadcrumb ul li:first-child").addClass("first-child");

//ToDo List
$("ul.todo li.day ~ li:nth-child(2n+1)").addClass("even");
$("ul.todo li.day").removeClass("even");

$("a.addToDo").click(function () {
 $("div.add_todo").slideToggle("fast");
});

//ToolTip
$(function(){
 $(".tooltip").tipTip({
   delay: 100
 });
});

//Auto Tabbing (Time Input)
$('.time_001').keyup(function(){
  if($(this).val().length==$(this)[0].maxLength){
    $('.time_002').focus();
  }
});
$('.time_003').keyup(function(){
  if($(this).val().length==$(this)[0].maxLength){
    $('.time_004').focus();
  }
});

//Sortable Config
$(function () {
 $(".column").sortable({
    connectWith: '.column',
    revert: true,
    containment: 'document',
    tolerance: 'pointer',
    opacity: 0.95,
    forcePlaceholderSize: false,
    forceHelperSize: false,
    items: 'div.portlet'
 });

 $(".portlet").addClass("rnd").find(".portlet-header").prepend('<span class="ui-icon ui-icon-minusthick"></span>').end().find(".portlet-content");

 $(".portlet-header .ui-icon").click(function () {
  $(this).toggleClass("ui-icon-minusthick").toggleClass("ui-icon-plusthick");
  $(this).parents(".portlet:first").find(".portlet-content").toggle();
 });

 $(".column").disableSelection();

});

/*Jquery Buttons*/
$(function() {
 $("button.btn, input:submit.btn, a.btn").button();
});

$( ".collapse" ).button({ icons: {secondary:'ui-icon-closethick'},text: false });

/*Hidden Add Issue Area*/
$("a.add_001").click(function () {
 $("div.add_001").slideToggle("fast");
});

//DatePicker
//DatePicker
  $("#datepicker").datepicker({
   numberOfMonths: 1,
   showButtonPanel: false,
   dateFormat: 'dd-mm-yy'
  });
  
  $(".datepicker").datepicker({
   numberOfMonths: 2,
   showButtonPanel: true,
   dateFormat: 'dd-mm-yy'
  });


//Dialog Edit User
$('.create-user')
 .button()
 .click(function() {
 $('#dialog-modal').dialog('open');
 $("#dialog-modal").dialog({
    height: 'auto',
	width: 460,
    modal: true,
    draggable: false,
    show: 'fade',
    resizable: false
}); $('#dialog-modal-create').parent().appendTo('form'); 
});
 
//Dialog Add User
$('.add-user')
 .button()
 .click(function() {
 $('#dialog-modal-add').dialog('open');
 $("#dialog-modal-add").dialog({
    height: 'auto',
	width: 800,
    modal: true,
    draggable: false,
    show: 'fade',
    resizable: false
}); $('#dialog-modal-add').parent().appendTo('form'); 
});
//Dialog Add User
$('.add-private')
 .button()
 .click(function () {
     $('#dialog-modal-private').dialog('open');
     $("#dialog-modal-private").dialog({
         height: 'auto',
         width: 500,
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-private').parent().appendTo('form');
 });
 //Payment dialog
 $('.add-payment')
 .button()
 .click(function () {
     $('#dialog-modal-payment').dialog('open');
     $("#dialog-modal-payment").dialog({
         height: 'auto',
         width: 460,
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-payment').parent().appendTo('form');
 });

 //Invite Dialog
 $('.add-invite')
 .button()
 .click(function () {
     $('#dialog-modal-invite').dialog('open');
     $("#dialog-modal-invite").dialog({
         height: 'auto',
         width: 800,
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-invite').parent().appendTo('form');
 });
 //Change Email Dialog
 $('.add-email')
 .button()
 .click(function () {
     $('#dialog-modal-email').dialog('open');
     $("#dialog-modal-email").dialog({
         height: 'auto',
         width: 460,
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-email').parent().appendTo('form');
 });


 //Edit Lawyer Capacity
 $('.edit-Lawyer-Capacity')

 .click(function () {
     $('#dialog-modal-Capacity').dialog('open');
     $("#dialog-modal-Capacity").dialog({
         height: 'auto',
         width: 700,
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-Capacity').parent().appendTo('form');
 });

 $('.openFollowUp')

 .click(function () {
     $('#dialog-modal-followup').dialog('open');
     $("#dialog-modal-followup").dialog({
         height: 'auto',
         width: 'auto',
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-followup').parent().appendTo('form');
 });

 $('.openIdUpload')

 .click(function () {
     $('#dialog-modal-idUpload').dialog('open');
     $("#dialog-modal-idUpload").dialog({
         height: 'auto',
         width: 'auto',
         modal: true,
         draggable: true,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-idUpload').parent().appendTo('form');
 });

 $('.openIdDownload')

 .click(function () {
     $('#dialog-modal-idDownload').dialog('open');
     $("#dialog-modal-idDownload").dialog({
         height: 'auto',
         width: 'auto',
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-idDownload').parent().appendTo('form');
 });

 $('.openalerts')

 .click(function () {
     $('#dialog-modal-openalerts').dialog('open');
     $("#dialog-modal-openalerts").dialog({
         height: 'auto',
         width: 700,
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-openalerts').parent().appendTo('form');
 });

 $('.openActivityDetails')

 .click(function () {
     $('#dialog-modal-activityDetails').dialog('open');
     $("#dialog-modal-activityDetails").dialog({
         height: 'auto',
         width: 'auto',
         modal: true,
         draggable: false,
         show: 'fade',
         resizable: false
     }); $('#dialog-modal-activityDetails').parent().appendTo('form');
 });

/*Autocomplete*/
$(function() {
 var availableTags = [
    "Aberdeen Office",
    "Birmingham Office",
    "Blackpool Office",
    "Cardiff Office",
    "Liverpool Office",
    "London Office",
    "Manchester Office",
    "Newcastle Office",
    "Swansea Office"
 ];
 $(".auto").autocomplete({
    source: availableTags
 });
});

/*Multicol*/
//try{8
    $('ol.bc_progress').makeacolumnlists({ cols: 2, colWidth: 0, equalHeight: false, startN: 1 });
//} catch (err)
//{
//}
