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

//su kien hien thi trang detail project
    $('.linkProject').click(function(event){

    	event.preventDefault();
        //cho trang daitail luôn scroll lên trên
        $(".DetailProject,html, body").animate({ scrollTop: 0 }, "slow");

    	var IdProject = $(this).data("idproject");
     	 $.ajax({
     	 	url: '/Admin/ProjectManager/GetInforProject',
     	 	type: 'GET',
     	 	dataType: 'json',
     	 	data: { ProjectID: IdProject },
     	 })
     	 .done(function(res) {

     	 })
     	 .fail(function() {
     	 
     	 })
     	 .always(function(res) {
     	    
             // console.log(res.dsuser);
            
            $('.DetailProject .projectName').html('Project Name: '+res[1]);
            $('.DetailProject .teamLeader').html('Team Leader: '+res[2]);
             
              // var edate = new Date(parseInt(res[4].substr(6)));

              //đưa dữ liệu vào cho 2 trường ngày bắt đầu và ngày kết thúc project
            if(res[3]!=null)
            {
                var sdate = new Date(parseInt(res[3].slice(6, -2)));
                sdate='' + (1 + sdate.getMonth()) + '/' + sdate.getDate() + '/' + sdate.getFullYear();//.toString().slice(-2);
            }
            
            if(res[4]!=null)
            {
                var edate=new Date(parseInt(res[4].slice(6,-2)));
                edate='' + (1 + edate.getMonth()) + '/' + edate.getDate() + '/' + edate.getFullYear();

            }  
            
            $('.DetailProject .date .startdate').html('Startdate : '+sdate);
            $('.DetailProject .date .enddate').html('Enddate : '+edate);
            
         
            var dsmb='';
            var j=0;
            for(var i=0;i<res[0].length;i++)
            {

                dsmb+='<tr>';

                dsmb+='<td>'+res[0][i].Value+' <i class="fa fa-times"></i></td>';
                
                dsmb+='</tr>';
        
            }

            $('.DetailProject .memberlist .lstmember').html(dsmb);
            
            // kêt thúc đưa dữ liệu vào các trường member của project
            
            // đưa danh sách các feature lên view
            var motdong='';
            for(var k=0;k<res[5].length;k++)
            {
               
                motdong+='<tr>';
                motdong+='<td scope="row">'+res[5][k].FeatureName+' </td>';
                motdong+=' <td>'+res[5][k].FeatureOwer+'</td>';
                motdong+=' <td>'+res[5][k].FeatureDuration+'</td>';
                motdong+=' <td>'+res[5][k].FeatureStatus+'</td>';
                motdong+='<td>  <i class="fa fa-edit"></i>  <i class="fa fa-times"></i></td>';
                motdong+=' </tr>';
             
            }

            $('.DetailProject .listfeaturemember').html(motdong);
            res="";
                               
     	 });
   }) ; 
    // end detail

    $( ".DetailProject" ).scroll(function() {

        $('.DetailProject .nutdilen').animate({scrollTop:$('.DetailProject .memberlist').offset().top});
    });

     $('.DetailProject .nutdilen').click(function(event){
         $(".DetailProject,html, body").animate({ scrollTop: 0 }, "slow");
     });


    //xu ly them project 
    $('.nutthemproject').click(function(event){
        //them from du lieu de nhap
      $(' div.dongthemproject').toggleClass('khoithemhienlen');
      $('div.tobangnoidung').addClass('mauden');
                  
    });
   

    $('body').on('click','div.tobangnoidung',function(event){
        $(' div.dongthemproject').toggleClass('khoithemhienlen');
        $('div.tobangnoidung').removeClass('mauden');
       
    });

    $('span.nutsaveadd.btn.btn-outline-success').click(function(event){
       

        var prname=$('.dongthemproject .projectnameadd').val();
        var startdate=$('.dongthemproject .startdateadd').val();
        var enddate=$('.dongthemproject .enddateadd').val();

        if(prname==''||startdate==''||enddate=='')
        {
             $('.dongthemproject .thongbaoloi').html('please fill in all the fields');  
           
        }
        else {

            if(enddate<startdate)
            {
                $('.dongthemproject .thongbaoloi').html('check your startdate less than enddate');
                    
            }
                else
                {
                     $(' div.dongthemproject').toggleClass('khoithemhienlen');
                      $('div.tobangnoidung').removeClass('mauden');
                     $.ajax({
                        url: '/Admin/ProjectManager/Add',
                        type: 'POST',
                        dataType: 'json',
                        data: {
                            ProjectName:prname,
                            StartDate:startdate,
                            EndDate:enddate
                         },
                    })
                    .done(function() {
                        console.log("success");
                    })
                    .fail(function() {
                        console.log("error");
                    })
                    .always(function(res) {
                        // xu  ly ve lai giao dien
                        if(res[0]!=-1)//neeu them that bai thi res =-1
                        {
                            var  motproject='';
                            motproject+=' <tr>';
                            motproject+='<td scope="row"><a href="#" data-idproject="'+res[0]+'" class="linkProject">'+prname+'</a></td>';
                            motproject+='<td>'+res[1]+'</td>';
                            motproject+=' <td>'+startdate+'</td>';
                            motproject+='<td>'+enddate+'</td>';
                            motproject+=' <td>inActive</td>';
                            motproject+='<td><i class="fa fa-times-circle nutdeleteproject" data-nutdeleteproject="'+res[0]+'></i></td>';
                            motproject+='</tr>';

                            $('.tddsproject .danhsachproject').append(motproject);
                        }
                        else
                        {
                              $('.dongthemproject .thongbaoloi').html('error add project');  
                        }
                    });
                }
        }

    });/* end nutsave*/

    $('div.dongthemproject').on('click','span.nutcanceladd.btn.btn-outline-danger',function(event){
        $(' div.dongthemproject').toggleClass('khoithemhienlen');
        $('div.tobangnoidung').removeClass('mauden');
    });

    //xu ly delete project 

    $('tbody.danhsachproject').on('click','.nutdeleteproject',function(event){
        //show dialog inf delete project 
        //get projectid can xoa 
        var xoagiaodien=$(this).parent().parent();
        var idprojectdelete =$(this).data("nutdeleteproject");
      
         $('.btn.btn-primary.yesdelteproject').click(function(event) {
             /* Act on the event */
             //goi mothod Delete trong controller ProjectManager tien hanh xoa
             $.ajax({
                 url: '/Admin/ProjectManager/Delete',
                 type: 'POST',
                 dataType: 'json',
                 data: {projectID: idprojectdelete},
             })
             .done(function() {
                 console.log("success");
             })
             .fail(function() {
                 console.log("error");
             })
             .always(function(res) {
                //xoa thanh cong thi ve lai giao dien
                if(res==-1)
                {

                }
                else
                {
                    xoagiaodien.remove();
                }
               
             });
             

         });
    });
    // end xu y delete project 



    //processing when update project 

    $('.fa.fa-pencil.nuteditproject.mr-1').click(function(event) {
        //load  data to form update 
        var projectname=$(this).parent().parent().children('.projectnametb').children().html();

        // su dung ajax de lay danh sach manager trong he thong
        $.ajax({
            url: '/Admin/ProjectManager/GetManager',
            type: 'GET',
            dataType: 'json',
            data: {},
        })
        .done(function() {
            console.log("success");
        })
        .fail(function() {
            console.log("error");
        })
        .always(function(res) {
            console.log(res);
        });
        
        
        
    });


    //end processing when update project 


})  

 
 // success: function (data) {
 //                    var rows = '';
 //                    $.each(data, function (i, item) {
 //                        rows += "<tr>"
 //                        rows += "<td>" + item.Id + "</td>"
 //                        rows += "<td>" + item.Name + "</td>"
 //                        rows += "<td>" + item.Author + "</td>"
 //                        rows += "<td>" + item.Price + "</td>"
 //                        rows += "<td><button type='button' id='btnEdit' class='btn btn-default' onclick='return getDetailBook(" + item.Id + ")'>Edit</button> <button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteBook(" + item.Id + ")'>Delete</button></td>"
 //                        rows += "</tr>";
 //                        $("#listBooks tbody").html(rows);
 //                    });