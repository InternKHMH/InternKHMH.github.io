 $(function(){
   
 	var totalProject =$(".total").data("total")*20,
        completedProject=$(" span.completed").data("completed")*20,
 	    ProcessingProject=$("span.processing").data("processing")*20,
        ManagerName="";


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
    var projectIDClickLink=null;
    $('.linkProject').click(function(event){

    	event.preventDefault();
        projectIDClickLink=null;
        //cho trang daitail luôn scroll lên trên
        $(".DetailProject,html, body").animate({ scrollTop: 0 }, "slow");

    	var IdProject = $(this).data("idproject");
        projectIDClickLink=IdProject;
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
     	    
            $('.DetailProject .projectName').html('Project Name: '+res[1]);
            $('.DetailProject .teamLeader').html('Scrum Master: '+res[2]);
             
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

                dsmb+='<td data-iduser='+res[0][i].Key+'>'+res[0][i].Value+'</td>';//<i class="fa fa-times"></i> bo giua
                
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
                // motdong+='<td>  <i class="fa fa-edit"></i>  <i class="fa fa-times"></i></td>';
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

    $('body').on('click','span.nutsaveadd.btn.btn-outline-success',function(event){
       

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
                            motproject+='<td>';
                            motproject+='<i class="fa fa-pencil nuteditproject mr-1" data-nuteditproject="'+res[0]+'" data-toggle="modal" data-target="#formupdateproject"></i>';
                            motproject+=' <i class="fa fa-times-circle nutdeleteproject" data-toggle="modal" data-target="#exampleModalCenter" data-nutdeleteproject="'+res[0]+'"></i>';
                            motproject+=' </td>';
                           // motproject+='<td><i class="fa fa-times-circle nutdeleteproject" data-nutdeleteproject="'+res[0]+'></i></td>';
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
                     $('.modal.fade.divdeleteproject ').removeClass('in');
                     $('.modal.fade.divdeleteproject ').css('display','none');
                    $('.modal.fade.divdeleteproject').attr('aria-hidden','true');
                     $('body').removeClass('modal-open');
                    // $('body').css('padding-right','0px');
                     $('.modal-backdrop.fade.in').remove();

                }
               
             });
             

         });
    });
    // end xu y delete project 

    //processing when update project 
    var managerID="";
    var dongDuocChonEdit=null,startusName="";

    $('body').on('click','.fa.fa-pencil.nuteditproject.mr-1',function(event) {
        //load  data to form update 
        dongDuocChonEdit=null;startusName="";
        dongDuocChonEdit=$(this).parent().parent();
        var projectname=$(this).parent().parent().children('.projectnametb').children().html();
        var startdate=$(this).parent().parent().children('.startdatetb').html();
        var enddate=$(this).parent().parent().children('.enddatetb').html();
        var olmanagerid=$(this).parent().parent().children('.managernametb').data('managerid'),
        projectid=$(this).parent().parent().children('.projectnametb').children('.linkProject').data('idproject');
        startusName=$(this).parent().parent().children('.statusnametb').html();

        managerID=olmanagerid;
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
            
            //gan du lieu cu len form nhap du lieu edit
             // lay du lieu danh sach cac manager
            var dsmanager='';
            //var olmanagerid=$('.managernametb').data('managerid');
          
            for(var i=0;i<res[0].length;i++)
            {
                if(olmanagerid==res[0][i].Key)
                {
                    ManagerName=res[0][i].Value;
                    dsmanager+='<option data-managerid="'+res[0][i].Key+'" selected>'+res[0][i].Value+'</option>';
                }
                else
                dsmanager+='<option data-managerid="'+res[0][i].Key+'">'+res[0][i].Value+'</option>';
            }
            $('.diveditproject select#manager').html(dsmanager);

            $('.projectnameedit').attr("placeholder",projectname);

            $(' .diveditproject .projectnameedit').attr('data-projectidedit',projectid);
 

           if(startdate!=null||startdate!="")
           {
            $('#updatestartdate').val(startdate);
           }
            
            if(enddate!=null||enddate!="")
            {
                $("#updateenddate").val(enddate);
                 
            }


            //xong viec gan du lieu cu
        
        });
        
    });

    //khi click vao nut update du lieu project
    $('body').on('change','.diveditproject #manager',function(event){
        var selected=$(this).find('option:selected');
        managerID=selected.data('managerid');

    });

    $('body').on('click','.diveditproject .acceptupdate',function(event){

        //lay cac truong du lieu
        var projectNameOld=$('.diveditproject .projectnameedit').attr('placeholder'),
            startDate=$('.diveditproject #updatestartdate').val(),
            endDate=$('.diveditproject #updateenddate').val(),
            managerName=$('.diveditproject #manager').val(),
            projecteditid=$('.diveditproject input.projectnameedit').data('projectidedit'),
            projectNameNew=$('.diveditproject .projectnameedit').val();
        

        $('.diveditproject .errorupdateproject').html('');
          

        //kiem tra du lieu trong 
        if(projectNameNew=="")
        {
            projectNameNew=projectNameOld;
        }
        if(endDate=="" || startDate=="")
        {
              $('.diveditproject .errorupdateproject').html('You must enter EndDate  and StartDate!');
              return false;
        }
        else 
        {
            if(endDate<startDate)
            {
                //hien thong bao loi va yeu cau nhap lai
                $('.diveditproject .errorupdateproject').html('You must enter EndDate > StartDate!');
                return false;

            }
        }

        //update du lieu
        $.ajax({
            url: '/Admin/ProjectManager/Update',
            type: 'POST',
            dataType: 'json',
            data: {
                projectName: projectNameNew,
                newManagerID:managerID,
                startDate:startDate,
                endDate:endDate,
                projectID:projecteditid
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

            $('.modal.fade.diveditproject').removeClass('in');
            $('.modal.fade.diveditproject').css('display','none');
            $('.modal.fade.diveditproject').attr('aria-hidden','true');
            $('body').removeClass('modal-open');
            $('body').css('padding-right','0px');
            $('.modal-backdrop.fade.in').remove();

            if(managerName!=ManagerName)//neu manager thay doi thi khi back project manager page
                                         // phai xoa du project do trong list
            {

                // xoa dong tren giao dien
                dongDuocChonEdit.remove();
            }

            else
            {
              
                //update lai du lieu va ve lai giao dien
                var dulieu='';
                dulieu+='<td scope="row" class="projectnametb"><a href="#" data-idproject="'+projecteditid+'" class="linkProject">'+projectNameNew+'</a></td>';
                dulieu+='<td class="managernametb" data-managerid="5">'+managerName+'</td>';
                dulieu+=' <td class="startdatetb">'+startDate+'</td>';
                dulieu+='<td class="enddatetb">'+endDate+'</td>';
                dulieu+=' <td class="statusnametb">'+startusName+'</td>';
                dulieu+='<td>';
                dulieu+=' <i class="fa fa-pencil nuteditproject mr-1" data-nuteditproject="'+projecteditid+'" data-toggle="modal" data-target="#formupdateproject"></i>';
                dulieu+=' <i class="fa fa-times-circle nutdeleteproject" data-toggle="modal" data-target="#exampleModalCenter" data-nutdeleteproject="'+projecteditid+'"></i>';
                dulieu+=' </td>'; 

                dongDuocChonEdit.html(dulieu);                   

            }

        });
       
    });

    //end processing when update project 



///////////////////////////////////xu ly su kien tren trang detail project ////////////////////////////
    
    //assign Scrum master

    $('body').on('click','.DetailProject .table.memberlist .lstmember tr td',function(event){

        var projectID=projectIDClickLink,
            scrumMasterID=$(this).data('iduser'),
            fullNameScrumMaster=$(this).html();


        $.ajax({
            url: '/Admin/ProjectManager/AssignScrumMaster',
            type: 'POST',
            dataType: 'json',
            data: {projectID: projectID,userID:scrumMasterID},
        })
        .done(function() {
            console.log("success");
        })
        .fail(function() {
            console.log("error");
        })
        .always(function() {
            console.log("complete");
            $('.DetailProject.hienlen .teamLeader').html('Scrum Master: '+fullNameScrumMaster)

        });
        


    });

    // end assign scrum master


















    function doingay(ngay)
    {
            var edate=new Date(parseInt(ngay.slice(6,-2)));
            edate='' + (1 + edate.getMonth()) + '-' + edate.getDate() + '-' + edate.getFullYear();
            return edate;
    }
})  

 
