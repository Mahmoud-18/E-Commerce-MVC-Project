// Password visibility toggle for Password cell
$(document).ready(function () {
    $('.password-toggle-btn').click(function () {
        var passwordInput = $('#password');
        var passwordInputType = passwordInput.attr('type');

        if (passwordInputType === 'password') {
            passwordInput.attr('type', 'text');
            $(this).html('<i class="fa fa-eye-slash"></i>');
        } else {
            passwordInput.attr('type', 'password');
            $(this).html('<i class="fa fa-eye"></i>');
        }
    });
});