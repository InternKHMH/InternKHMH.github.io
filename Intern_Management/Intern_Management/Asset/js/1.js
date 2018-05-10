 $(function(){
   
 	var totalProject =$(".total").data("total")*20;
 	var completedProject=$(" span.completed").data("completed")*20;
 	var ProcessingProject=$("span.processing").data("processing")*20;

 	$("span.total").width(totalProject);
 	$("span.completed").width(completedProject);
 	$("span.processing").width(ProcessingProject);

     $('.linkProject').click(function(event){
         event.preventDefault();
         $('.DetailProject').addClass('hienlen');
         
     })

    $('.nutBackDashboard').click(function(event){
        $('.DetailProject').removeClass('hienlen');
        $('.DetailProject').addClass('dixuong');
    })


    $('.linkProject').click(function(event){
    	event.preventDefault();
    	var IdProject = $('.linkProject').data("idproject");
     	alert(IdProject);


     	 $.ajax({
     	 	url: '/Admin/ProjectManager/GetInforProject',
     	 	type: 'POST',
     	 	dataType: 'json',
     	 	data: { ProjectID: IdProject },
     	 })
     	 .done(function() {
     	 	console.log("success");
     	 })
     	 .fail(function() {
     	 	console.log("error");
     	 })
     	 .always(function(res) {
     	 	console.log(res.hoten);
     	 });
     	

    })
    
    
 
})  
 