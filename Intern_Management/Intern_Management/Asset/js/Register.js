$(function () {

    var myApp = angular.module('myApp', []);
    myApp.controller('mainController', ['$scope', function ($scope) {
    $scope.xoadulieu=false;
    $scope.picture="slected picture";
    $scope.thongbaochung="bạn cần nhập đầy đủ các trường thông tin";
    $scope.addIntern = function () {
            var username = $scope.username,
                fullname = $scope.fullname,
                password = $scope.password,
                confirmpassword=$scope.confirmpassword,
                university = $scope.university,
                userdes = $scope.userdes,
                address = $scope.address,
                specialized = $scope.specialized;
            var pc = $('#picture').val();


            //kiểm tra đây đủ dữ liệu

            if (username == undefined || fullname == undefined || password == undefined || university == undefined || userdes == undefined || address == undefined || specialized == undefined || pc == undefined)
            {
                $scope.username="";
               return false;
            }

            //kiem tra username da ton tai chua


            if(password!=confirmpassword)
            {
                $scope.confirmpassword="";
            	$scope.thongbaochung="bạn nhập lại mật khẩu không chính xác vui lòng kiểm tra lại!";
                return false;
            }


            $.ajax({
            	url: '/Register/AddRegiterByStudent',
            	type: 'POST',
            	dataType: 'json',
            	data: {
            			username : username,
		                fullname: fullname,
		                password: password,
		                university:university,
		                userdes : userdes,
		                address : address,
		                specialized :specialized,
		         		pc : $('#picture').val()
		         	},
		         	
            })
            .done(function() {
                console.log("success");
                
                
            })
            .fail(function() {
            	console.log("error");
            })
            .always(function(res) {
                console.log("complete");
                if(res==-1)//trùng user name
                {
                    $scope.username="";
                    $scope.thongbaochung="username đã tồn tại";
                }
                if(res==0)
                {
                    //có lỗi khi thêm
                }
                if(res==1)
                {
                   
                }

                
            });
            xoadulieu();
            
        };
    var xoadulieu=function(){
                $scope.username = "";
                $scope.fullname = "";
                $scope.password = "";
                $scope.university = "";
                $scope.userdes = "";
                $scope.address = "";
                $scope.specialized = "";
                $scope.xoadulieu=true;
               $('#pictureUpload').attr('src','#');
            $('#picture').val("");
    };
    $('#btnUpload').click(function(){
		    $('#fileUpload').trigger('click');
	    });
    $('#fileUpload').change(function () {

		    //kiem tra trinfh duyet co ho tro form data khong 
		    if(window.FormData!==undefined)
		    {
			    //lay du lieu tren file upload
			    var fileUpload=$('#fileUpload').get(0);
			    var files=fileUpload.files;
			    //tao doi tuong form data 
			    var formData= new FormData();

			    formData.append('file',files[0]);
              
			    $.ajax({

				    type:'POST',
				    url: '/Register/PostImageCover',
				    contentType: false, //khong co header
				    processData: false,//khong xu ly du  lieu
				    data: formData,
				    success: function(urlImage)
				    {
					    $('#pictureUpload').attr('src','/Asset/ImagesTemp/'+urlImage);
					    $('#picture').val(urlImage);

				    },
				    error:function(err)
				    {

				    }

			    });


               
                
		    }
	    });
     }]);

});