/* ---------------------------------------------
 Contact form
 --------------------------------------------- */
$(document).ready(function(){
    $("#submit_btn").click(function(){
        
        //get input field values
        var user_name = $('input[Name=Name]').val();
        var user_email = $('input[Name=Email]').val();
        var user_message = $('textarea[Name=Message]').val();
        
        //simple validation at client's end
        //we simply change border color to red if empty field using .css()
        var proceed = true;
        if (user_name == "Name") {
            $('input[Name=Mame]').css('border-color', '#e41919');
            proceed = false;
        }
        if (user_email == "Email") {
            $('input[Name=Mmail]').css('border-color', '#e41919');
            proceed = false;
        }
        
        if (user_message == "Message") {
            $('textarea[Name=Message]').css('border-color', '#e41919');
            proceed = false;
        }
    });
    
    //reset previously set border colors and hide all message on .keyup()
    $("#contact_form input, #contact_form textarea").keyup(function(){
        $("#contact_form input, #contact_form textarea").css('border-color', '');
        $("#result").slideUp();
    });
    
});
