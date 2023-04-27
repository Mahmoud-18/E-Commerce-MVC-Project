
    $(function () {
        // Validate the contact form
        $("#contactForm").validate({
            rules: {
                Name: "required",
                Email: {
                    required: true,
                    email: true
                },
                Subject: "required",
                Message: "required"
            },
            messages: {
                Name: "Please enter your name",
                Email: {
                    required: "Please enter your email",
                    email: "Please enter a valid email address"
                },
                Subject: "Please enter a subject",
                Message: "Please enter a message"
            },
            submitHandler: function (form) {
                // Handle the form submission with Ajax
                $.ajax({
                    type: "POST",
                    url: form.action,
                    data: $(form).serialize(),
                    success: function () {
                        // Display a success message
                        $("#success").html("Your message has been sent. Thank you!").show();
                        // Reset the form
                        form.reset();
                    },
                    error: function () {
                        // Display an error message
                        $("#success").html("Sorry, there was a problem sending your message. Please try again.").show();
                    }
                });
                return false;
            }
        });
    });
