$(function () {
	var myApp=angular.module('myApp',[]);
	myApp.controller('mainCtrl', ['$scope', function ($scope) {
	    $scope.count = 0;
	    $scope.chuyentrang=function()
	    {
	        $scope.nhom0=false;
	    }

	    $scope.tang=function()
	    {
	        $scope.count++;
	        $scope.nhom0 = false;
	    }
	}]);

	
	$('.taskendtoday .motkhoi.endtoday1.nhom0').addClass('listaskhienthi');

	$('body').on('click', '._3nut ul li', function (event) {

	    var classNhomHienThi = '.motkhoi' + '.endtoday1' + '.' + ($(this).data('tennhom'));
	 
	    $('.listaskhienthi').removeClass('listaskhienthi')

	    $(classNhomHienThi).addClass('listaskhienthi');
	})

	$('body').on('click', '.motkhoiproject.nutxemdetailproject', function (event) {
	    //lay id project duoc chon
	    var idproject = $(this).data('idproject');
	    
	    $('.inputluuidproject').val(idproject);

	    //lay du lieu  cua project len

	    $.ajax({
	        url: '/Member/Project/GetInforProject',
	        type: 'POST',
	        dataType: 'json',
	        data: {
	   
	            ProjectID: idproject
	        },
	    })
          .done(function () {
              console.log("success");
          })
          .fail(function () {
              console.log("error");
          })
          .always(function (dulieu) {
              //cho noi dung vao cac truong du lieu
              console.log(dulieu);
             // $('.container.DetailProject projectName').html()
             $('.modal.fade .DetailProject .projectName').html('Project: '+dulieu[1]);
             $('.modal.fade .DetailProject .teamLeader').html('Leader: '+dulieu[2]);

             var dsmember='';
             var dsmemberadd='';
             try {
	             	 for(var i=0;i<dulieu[0].length;i=i+2)
		             {
		             	  dsmember+='<tr> <td>'+dulieu[0][i].Value+'</td> <td>'+dulieu[0][i+1].Value+'</td></tr>';
		             	 // dsmemberadd+='<option data-iduseraddfeature="'+dulieu[0][i].Key+'">'+dulieu[0][i].Value+'</option><option data-iduseraddfeature="'+dulieu[0][i+1].Key+'">'+dulieu[0][i+1].Value+'</option>';
		             	  dsmemberadd+='<option value="'+dulieu[0][i].Key+'">'+dulieu[0][i].Value+'</option><option value="'+dulieu[0][i+1].Key+'">'+dulieu[0][i+1].Value+'</option>';
		             }
            	 } catch(e) 
            	 {
             		
             		 dsmember+='<tr> <td>'+dulieu[0][dulieu[0].length-1].Value+'</td> <td></td></tr>';
             		// dsmemberadd+='<option data-iduseraddfeature="'+dulieu[0][dulieu[0].length-1].Key+'">'+dulieu[0][dulieu[0].length-1].Value+'</option>';
             		 dsmemberadd+='<option value="'+dulieu[0][dulieu[0].length-1].Key+'">'+dulieu[0][dulieu[0].length-1].Value+'</option>';
             	
             	}
            
             	$('.taskoweraddfeature').html(dsmemberadd);
            $('.modal.fade .DetailProject .lstmember').html(dsmember);

            //load danh sach feature
            var dsfeature='';
            for(var i=0;i<dulieu[5].length;i++)
            {
            	dsfeature+='<tr><td>'+dulieu[5][i].FeatureName+'</td><td>'+dulieu[5][i].FeatureOwer+'</td><td>'+dulieu[5][i].FeatureStatus+'</td></tr>'
            }

            $('.feature_member .listfeaturemember').html(dsfeature);
          });
	})

	$('body').on('click','.nutthemfeature',function(event){
		
		//kiem tra xem user co phai leader khong\
		$.ajax({
			url: '/Member/Project/IsLeader',
			type: 'POST',
			dataType: 'json',
			data: {projectId: $('.inputluuidproject').val()},
		})
		.done(function() {
			console.log("success");
		})
		.fail(function() {
			console.log("error");
		})
		.always(function(res) {
			if(res==0)
			{
				$('.thongbaocoquyenthemkhong').html("You can't do it because you are intern not is leader project!");
			}
			else
			{
				$('.thongbaocoquyenthemkhong').html("");				
				$('.formaddfeature').addClass('hienthi');

			}
		});
	})

	$('body').on('click','.nutaddtaskchinhthuc',function(event){
		//lay thong tin duoc nhap

		$('.thongbaocoquyenthemkhong').html("");

		var taskName=$('.tasknameaddfeature').val(),
			endDate=$('.enddateaddfeature').val(),
			description=$('.descriptionaddfeature ').val(),
			userid=$('.taskoweraddfeature').val(),
			projectId=$('.inputluuidproject').val();

		var status="InActive";
		var taskower=$( ".taskoweraddfeature option:selected" ).text();

			if(taskName==""||endDate==""||description==""||userid=="")
			{
				$('.thongbaocoquyenthemkhong').html('bạn cần nhập đầy đủ các trường dữ liệu');
			}
			else
			{
				$.ajax({
					url: '/Member/Project/AddTask',
					type: 'POST',
					dataType: 'json',
					data: {
						taskName: taskName,
						endDate: endDate,
						description: description,
						taskOwer: userid,
						projectId:projectId
						},
				})
				.done(function() {
					console.log("success");
				})
				.fail(function() {
					console.log("error");
				})
				.always(function() {
					dsfeature='<tr><td>'+taskName+'</td><td>'+taskower+'</td><td>'+status+'</td></tr>';
					   $('.feature_member .listfeaturemember').append(dsfeature);

				});
				
			}
	})

	//khi click nut xem chi tiet task

	$('body').on('click','.motkhoi.endtoday1',function(event){
		//lấy thông tin của task được click hiện thị lên

		$('.noidungtrangchitietfeature').addClass('dtfeaturehienthi');

	})

	$('body').on('click','.nutthoatdetailfeature',function(event){
		$('.noidungtrangchitietfeature').removeClass('dtfeaturehienthi');
	})

})
