 $(function(){


     $('.linkProject').click(function(event){
         event.preventDefault();
         $('.DetailProject').addClass('hienlen');
         
     })

    $('.nutBackDashboard').click(function(event){
        $('.DetailProject').removeClass('hienlen');
        $('.DetailProject').addClass('dixuong');
    })

    
 
})  
 