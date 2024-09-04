var currentUrl = window.location.pathname;

$('#sidebarMenu .nav-link').removeClass('active').css('color', '');

$('#sidebarMenu .nav-link').each(function () {
    if ($(this).attr('href') === currentUrl) {
        $(this).addClass('active');

        $(this).removeClass('text-white').css('color', '#FF4E88');
    }
});