 $(function(){


 	//xu ly jquery giao dien slide 
 	// khi an nut phai
 	var dangxuly='khong';

 	var thoigian=setInterval(function(event){

 		if(dangxuly=='khong')
 		{
 			dangxuly='dangxuly';
 			
 			var phantuhientai=$('.khoislide .motslide.active'),
 				phantutieptheo=$('.khoislide .motslide.active').prev();
 				

 			if(phantutieptheo.html()==null) //neu dang o slide cuoi
 			{
 				phantutieptheo=$('.khoislide .container .row .col-xs-8 .motslide:nth-child(4)');
 			}
 			// console.log(phantuhientai.html());
 		
	 		//add class an di cho phantuhientai
	 		phantuhientai.addClass('slideandibenphai');
	 		//xoa di class dang active cua phan tu hien tai
	 		
	 		
	 		$('body').on('animationend webkitAnimationEnd oAnimationEnd',phantuhientai,function(event){
	 			
	 			phantuhientai.removeClass('slideandibenphai');
	 			phantuhientai.removeClass('active');
	 		});

	 		phantutieptheo.addClass('hienratubentrai');

	 		$('body').on('animationend webkitAnimationEnd oAnimationEnd',phantutieptheo,function(event){
	 			
	 			phantutieptheo.removeClass('hienratubentrai');
	 			phantutieptheo.addClass('active');
	 		})
	 		dangxuly='khong';
 		}
 		return false;

 	}, 3000);

 	
 	$('body').on('click','.khoislide .nutphai',function(event){
 		clearInterval(thoigian);
 		if(dangxuly=='khong')
 		{
 			dangxuly='dangxuly';
 			
 			var phantuhientai=$('.khoislide .motslide.active'),
 			phantutieptheo=$('.khoislide .motslide.active').next();

 			if(phantutieptheo.data('endslide')=='endslide') //neu dang o slide cuoi
 			{
 				phantutieptheo=$('.khoislide .container .row .col-xs-8 .motslide:nth-child(1)');
 			}
 		
	 		//add class an di cho phantuhientai
	 		phantuhientai.addClass('slideandibentrai');
	 		//xoa di class dang active cua phan tu hien tai
	 		
	 		
	 		$('body').on('animationend webkitAnimationEnd oAnimationEnd',phantuhientai,function(event){
	 			
	 			phantuhientai.removeClass('slideandibentrai');
	 			phantuhientai.removeClass('active');
	 		});

	 		phantutieptheo.addClass('hienratubenphai');

	 		$('body').on('animationend webkitAnimationEnd oAnimationEnd',phantutieptheo,function(event){
	 			
	 			phantutieptheo.removeClass('hienratubenphai');
	 			phantutieptheo.addClass('active');
	 		})
	 		dangxuly='khong';
 		}
 		return false;
 	
 	});

 	$('body').on('click','.khoislide .nuttrai',function(event){

 		clearInterval(thoigian);
 		if(dangxuly=='khong')
 		{
 			dangxuly='dangxuly';
 			
 			var phantuhientai=$('.khoislide .motslide.active'),
 				phantutieptheo=$('.khoislide .motslide.active').prev();

 			if(phantutieptheo.html()==null) //neu dang o slide cuoi
 			{
 				phantutieptheo=$('.khoislide .container .row .col-xs-8 .motslide:nth-child(4)');

 
 			}
 			// console.log(phantuhientai.html());
 		
	 		//add class an di cho phantuhientai
	 		phantuhientai.addClass('slideandibenphai');
	 		//xoa di class dang active cua phan tu hien tai
	 		
	 		
	 		$('body').on('animationend webkitAnimationEnd oAnimationEnd',phantuhientai,function(event){
	 			
	 			phantuhientai.removeClass('slideandibenphai');
	 			phantuhientai.removeClass('active');
	 		});

	 		phantutieptheo.addClass('hienratubentrai');

	 		$('body').on('animationend webkitAnimationEnd oAnimationEnd',phantutieptheo,function(event){
	 			
	 			phantutieptheo.removeClass('hienratubentrai');
	 			phantutieptheo.addClass('active');
	 		})
	 		dangxuly='khong';
 		}
 		return false;
 	
 	});
 	//xong xu ly slide 
 	


     ///xu ly khi click vao nut add intern
 	$('body').on('click', '.nutthemintern', function (event) {

 	    $.ajax({
 	        url: '/InternManager/Get_7_StudentRegister',
 	    	type: 'GET',
 	    	dataType: 'json',
 	    	data: { numberSkip :0},
 	    })
 	    .done(function() {
 	    	console.log("success");
 	    })
 	    .fail(function() {
 	    	console.log("error");
 	    })
 	    .always(function(res) {
 	    	
 	    	var dl='';
 	    	for (var i = 0; i <res.length; i++) {
 	    		 dl+=' <tr>';
	 	    	 dl+='<td class="fullname" data-idintern="1">'+res[i].FullName+'</td>';
	 	    	 dl+='<td class="birthday">17/05/1995</td>';
	 	    	 dl+=' <td class="university">'+res[i].University+'</td>';
	 	    	 dl+=' <td class="specialized">'+res[i].specialized+'</td>';
	 	    	 dl+='<td class="address">'+res[i].userAddress+'</td>';
	 	    	 dl+=' <td class="kichhoat tooltip-test" title="Active intern">InActive</td>';
	 	    	 dl+='<td><i class="fa fa-times"></i></td>';
	 	    	 dl+=' </tr>';
 	    
 	    	}

 	    	$('.danh_sach_student_register').html(dl);
 	    });
 	    



 	});




     //end xu ly khi an vao nut add intern


 	
})  
 