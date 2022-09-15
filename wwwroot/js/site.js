// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function () {
    'use strict'
    const forms = document.querySelectorAll('.requires-validation')
    Array.from(forms)
      .forEach(function (form) {
        form.addEventListener('submit', function (event) {
          if (!form.checkValidity()) {
            event.preventDefault()
            event.stopPropagation()
          }
    
          form.classList.add('was-validated')
        }, false)
      })
    })()










    $(function(){
      var loading = $('#loadbar').hide();
      $(document)
      .ajaxStart(function () {
          loading.show();
      }).ajaxStop(function () {
        loading.hide();
      });
      
      $("label.btn").on('click',function () {
        var choice = $(this).find('input:radio').val();
        $('#loadbar').show();
        $('#quiz').fadeOut();
        setTimeout(function(){
             $( "#answer" ).html(  $(this).checking(choice) );      
              $('#quiz').show();
              $('#loadbar').fadeOut();
             /* something else */
        }, 1500);
      });
  
      $ans = 3;
  
      $.fn.checking = function(ck) {
          if (ck != $ans)
              return 'INCORRECT';
          else 
              return 'CORRECT';
      }; 
  });	
  


  setInterval(function () {    

   
        $("#segundos").html(parseInt($("#segundos").html())+1);  
    
    
},1000);

















var contactForm = function() {
  if ($('#contactForm').length > 0 ) {
    $( "#contactForm" ).validate( {
      rules: {
        name: "required",
        subject: "required",
        email: {
          required: true,
          email: true
        },
        message: {
          required: true,
          minlength: 5
        }
      },
      messages: {
        name: "Please enter your name",
        subject: "Please enter your subject",
        email: "Please enter a valid email address",
        message: "Please enter a message"
      },
      /* submit via ajax */
      
      submitHandler: function(form) {		
        var $submit = $('.submitting'),
          waitText = 'Submitting...';

        $.ajax({   	
            type: "POST",
            url: "php/sendEmail.php",
            data: $(form).serialize(),

            beforeSend: function() { 
              $submit.css('display', 'block').text(waitText);
            },
            success: function(msg) {
                 if (msg == 'OK') {
                   $('#form-message-warning').hide();
                  setTimeout(function(){
                     $('#contactForm').fadeIn();
                   }, 1000);
                  setTimeout(function(){
                     $('#form-message-success').fadeIn();   
                   }, 1400);

                   setTimeout(function(){
                     $('#form-message-success').fadeOut();   
                   }, 8000);

                   setTimeout(function(){
                     $submit.css('display', 'none').text(waitText);  
                   }, 1400);

                   setTimeout(function(){
                     $( '#contactForm' ).each(function(){
                        this.reset();
                    });
                   }, 1400);
                   
                } else {
                   $('#form-message-warning').html(msg);
                  $('#form-message-warning').fadeIn();
                  $submit.css('display', 'none');
                }
            },
            error: function() {
              $('#form-message-warning').html("Something went wrong. Please try again.");
               $('#form-message-warning').fadeIn();
               $submit.css('display', 'none');
            }
          });    		
        } // end submitHandler

    });
  }
};
contactForm();


