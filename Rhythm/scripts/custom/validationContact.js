function ContactForm(container) {

    var errors =
    [
        {
            selector: "#Name",
            mess: "Это поле обязательно для заполнения",
            reg: /[a-zA-zа-яА-Я\`-]([\s]?[a-zA-zа-яА-Я\`-]){4,25}/i,
            req: true
        },
        {
            selector: "#Message",
            mess: "Это поле обязательно для заполнения",
            reg: /[a-zA-zа-яА-Я\`-]([\s]?[a-zA-zа-яА-Я\`-]){5,1000}/i,
            req: true
        },
        {
            selector: "#Email",
            reg: /^[a-z]+[a-z0-9_\-]+\.?[a-z0-9_]+\.?[a-z0-9_]+@[a-z]+\.[a-z]{2,6}\b/ig,
            mess: "E-mail должен содержать “@” и “.”",
            req: true
        }
    ]

    $("#Name").inputmask("Regex");
    $("#Message").inputmask("Regex");
    $("#Email").inputmask("Regex");

    function validationView(input, regexp, message, req) {

        var inputValue = $(container + " " + input).val();
        var conditional;

        $(container + " " + "#result").removeClass("error").next(".error").remove();

        if (req) {

            conditional = !inputValue.match(regexp);
        }
        else {

            conditional = inputValue && !inputValue.match(regexp);
        }

        if (conditional) {

            $(container + " " + "#result").addClass("error").after("<p class='error'>" + message + "</p>");

            return false
        }
        return true
    };

    function validate(err, event) {

        var valid = err.map(function (it, ind) {

            return validationView(it.selector, it.reg, it.mess, it.req);
        });

        if (valid.indexOf(false) < 0 && event) {

        }
    };

    function inputValidate() {

        $(document).on("input", container + " .validate.error", function (e) {

            validate(errors);
        })
    };

    function saveData() {

        $(document).on("click", container + " #sendMessage", function (e) {

            e.preventDefault();
            validate(errors, e);
        })
    };

    return ({
        init: function () {
            inputValidate();
            saveData();
        }
    });
};

$(document).ready(function () {
    var contactForm = ContactForm(".contact.form").init();
});