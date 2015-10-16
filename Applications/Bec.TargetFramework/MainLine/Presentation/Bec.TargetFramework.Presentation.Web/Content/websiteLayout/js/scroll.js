$( document ).ready(function() {

	/*SCROLL TO HOME*/
	$( "#nav-home" ).click(function() {
		$('html, body').animate({
		    scrollTop: 0
		}, 1000);
	});

	/*SCROLL TO ABOUT*/
	$( "#nav-about" ).click(function() {
		$('html, body').animate({
		    scrollTop: $("#about").offset().top
		}, 1000);
	});

	/*SCROLL TO WORK*/
	$( "#nav-work" ).click(function() {
		$('html, body').animate({
		    scrollTop: $("#portfolio").offset().top
		}, 1000);
	});

	/*SCROLL TO SERVICES*/
	$( "#nav-services" ).click(function() {
		$('html, body').animate({
		    scrollTop: $("#services").offset().top
		}, 1000);
	});

	/*SCROLL TO CONTACT*/
	$( "#nav-contact" ).click(function() {
		$('html, body').animate({
		    scrollTop: $("#contact").offset().top
		}, 1000);
	});
});

