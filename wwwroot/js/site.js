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
  