$(function(){
  $('header').data('size','big');
});

$(window).scroll(function(){
  if($(document).scrollTop() > 0)
{
    if($('header').data('size') == 'big')
    {
        $('header').data('size','small');
        $('header').stop().animate({
            height:'134px'
        },600);
        $('#navigation ul').stop().animate({
            marginTop: '34px'
        },600);
        $('#logoimg').stop().animate({
            marginTop: '10px'
            width"10px"
        },600);
    }

}
else
  {
    if($('header').data('size') == 'small')
      {
        $('header').data('size','big');
        $('header').stop().animate({
            height:'137px'
        },600);
        $('#navigation ul').stop().animate({
            marginTop: '58px'
        },600);
        $('#logoimg').stop().animate({
            marginTop: '23px'
        },600);
      }
  }
});





