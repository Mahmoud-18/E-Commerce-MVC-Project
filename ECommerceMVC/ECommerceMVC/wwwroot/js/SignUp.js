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

function togglePasswordVisibility() {
    var passwordInput = document.getElementById("repassword");
    var passwordToggleBtn = document.querySelector(".password-toggle-btn");
    var passwordFieldType = passwordInput.getAttribute("type");

    if (passwordFieldType === "password") {
        passwordInput.setAttribute("type", "text");
        passwordToggleBtn.innerHTML = '<i class="fa fa-eye-slash"></i>';
    } else {
        passwordInput.setAttribute("type", "password");
        passwordToggleBtn.innerHTML = '<i class="fa fa-eye"></i>';
    }
}



 

var input = document.querySelector('#phone');
var iti = window.intlTelInput(input, {
    initialCountry: 'auto',
    preferredCountries: [
        'eg',
        'sd',
        'ly',
        'jo',
        'iq',
        'sa',
        'kw',
        'bh',
        'qa',
        'ae',
        'om',
        'lb',
        'sy',
        'ye',
        'ma',
        'tn',
        'dz',
        'mr',
        'so',
        'km',
        'dj',
        'ps',
        'mr',
        'eh',
    ],
    separateDialCode: true,
    geoIpLookup: function (success, failure) {
        $.get('https://ipinfo.io', function () { }, 'jsonp').always(function (
            resp
        ) {
            var countryCode = resp && resp.country ? resp.country : '';
            success(countryCode);
        });
    },
    utilsScript:
        'https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.13/js/utils.js',
});

var flag = document.querySelector('#flag');
var country_code_input = document.querySelector('#country_code');

iti.promise.then(function () {
    var country = iti.getSelectedCountryData();
    flag.style.backgroundImage =
        "url('https://cdnjs.cloudflare.com/ajax/libs/flag-icon-css/3.5.0/flags/1x1/" +
        country.iso2 +
        ".svg')";
    country_code_input.value = country.dialCode;
});

input.addEventListener('countrychange', function () {
    var country = iti.getSelectedCountryData();
    flag.style.backgroundImage =
        "url('https://cdnjs.cloudflare.com/ajax/libs/flag-icon-css/3.5.0/flags/1x1/" +
        country.iso2 +
        ".svg')";
    country_code_input.value = country.dialCode;
});

