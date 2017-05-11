


(function () {
    $(function () {

        var _$usersTable = $('#UsersTable');
        var _userService = abp.services.app.user;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.User.CreateUser"),
            edit: abp.auth.hasPermission("Pages.User.EditUser"),
            'delete': abp.auth.hasPermission("Pages.User.DeleteUser")

        };

 
    



        _$usersTable.jtable({

            title: app.localize('User'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _userService.getPagedUsersAsync
        }
            },

        fields: {
           
            actions: {
                title: app.localize('Actions'),
                width: '10%',
                sorting: false,
                display: function (data) {
                    var $span = $('<span></span>');
                    //编辑
                    if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
location.href = abp.appPath + 'Mpa/UserManage/CreateOrEditUserModal?id='+data.record.id;                            });
                    }
                    //删除
                    if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteUser(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateUser") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
							location.href = abp.appPath + 'Mpa/UserManage/CreateOrEditUserModal'				                  

                            });
                    }

                    return $span;
            }
        },
		//此处开始循环数据

	 

          id: {           
                 key: true,
                list: false
         }, 	  

userName: {
            title: app.localize('UserName'),
            width: '10%'
         },     
	  

localName: {
            title: app.localize('LocalName'),
            width: '10%'
         },     
	  

emailAddress: {
            title: app.localize('EmailAddress'),
            width: '10%'
         },     
	  

lastLoginTime: {
            title: app.localize('LastLoginTime'),
            width: '10%'
         },     
	 
            }

        });

		
				       

     //  打开添加窗口MPA
       $('#CreateNewUserButton').click(function () {
            //        console.log(abp.appPath);的默认值为"/";
           location.href = abp.appPath+'Mpa/UserManage/CreateOrEditUserModal';
       });

 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getUsers();
        });




//模糊查询功能
function getUsers(reload) {
    if (reload) {
        _$usersTable.jtable('reload');
    } else {
        _$usersTable.jtable('load', {
            filtertext: $('#UsersTableFilter').val()
        });
    }
}
//
//删除当前user实体
function deleteUser(user) {   
    abp.message.confirm(
        app.localize('UserDeleteWarningMessage', user. userName),
            function (isConfirmed) {
                if (isConfirmed) {
                    _userService.deleteUserAsync({
                        id: user.id
                        }).done(function () {
                            getUsers(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportUsersToExcelButton').click(function () {
    _userService
        .getUsersToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetUsersButton').click(function (e) {
    e.preventDefault();
    getUsers();
});

//制作User事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditUserModalSaved', function () {
    getUsers(true);
});

getUsers();
 
 
    });
})();
