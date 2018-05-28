 $(function(){
 	$('.tbuser tbody tr').click(function(event) {
 		event.preventDefault();
 		$('.detailUser').addClass('detailUserShow');
 		$('.den').addClass('hienthi');

 		var bien=$('.tbUser tr').data('iduser');
 		alert(bien[1]);


 	});
 	$('.nutthoat').click(function(event){
 		$('.detailUser').addClass('detailAndi');
 		$('.den').removeClass('hienthi');
 		$('.detailUserShow').removeClass('detailUserShow');
 		$('.detailUser').removeClass('detailAndi');

 		$.ajax({
 			url: '/path/to/file',
 			type: 'POST',
 			dataType: 'json',
 			data: {param1: 'value1'},
 		})
 		.done(function() {
 			console.log("success");
 		})
 		.fail(function() {
 			console.log("error");
 		})
 		.always(function(res) {
 			console.log("complete");
 			
 		});
 		

 	})
})  
 