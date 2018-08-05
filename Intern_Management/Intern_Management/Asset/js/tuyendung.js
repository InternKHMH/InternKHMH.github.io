document.addEventListener("DOMContentLoaded",function()
{
	//xu ly hieu ung khi click nut chuyen slide
	var cacnut=document.querySelectorAll('.chuyenslide ul li');
	var slides=document.querySelectorAll('.cacslide ul li');

	var thoigian=setInterval(function(){
		var nutkichhoat=document.querySelector('.cacslide ul li.active');

		var vt=0;
		for(vt=0;nutkichhoat=nutkichhoat.previousElementSibling;vt++){}
			
			for(var i=0;i<slides.length;i++)
			{
				slides[i].classList.remove('active');
				cacnut[i].classList.remove('kichhoat')
				

			}
			if(slides[vt].nextElementSibling==null)
			{
				slides[0].classList.add('active');
				cacnut[0].classList.add('kichhoat');
				


			}
			else
			{
				slides[vt].nextElementSibling.classList.add('active');
				cacnut[vt].nextElementSibling.classList.add('kichhoat');
				
			}


	}, 5000);

	for (var i = 0; i <cacnut.length; i++) {
		cacnut[i].onclick=function(){
			//xu ly giao dien khi click nut chuyen slide 
			//xoa class active tren tat ca cac the li
			// var nutcoclassactive=document.querySelector('.chuyenslide ul li.kichhoat');
			// nutcoclassactive.classList.remove('kichhoat');
			// this.classList.add('kichhoat');
			clearInterval(thoigian);
			//cach cua duc viet
			for(var k=0;k<cacnut.length;k++)
			{
				cacnut[k].classList.remove('kichhoat');

			}
			this.classList.add('kichhoat');

			var nutkichhoat = this ; 
			var vitrinut = 0 ; 
			for (vitrinut = 0;nutkichhoat = nutkichhoat.previousElementSibling; vitrinut++) {	}
			//lay vi tri slide duoc kich hoat
			//cho slide voi vi tri nut tren hien ra
			for(var i=0;i<slides.length;i++)
			{
				slides[i].classList.remove('active');

			}
			slides[vitrinut].classList.add('active');

		}
	}

})