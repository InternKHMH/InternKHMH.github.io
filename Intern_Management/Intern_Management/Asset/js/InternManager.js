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
 	

 	//xu ly scroll 

 	// $(window).scroll(function(event) {
 		

 	// 	$('.nutthemintern.btn.btn-primary').css({
 	// 		top: $(window).scrollTop()-200			
 	// 	});
 		
 		
 	
 	// });

 	
})  
 