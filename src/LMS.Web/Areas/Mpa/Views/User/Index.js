(function () {
    $(function () {

        abp.localization.defaultSourceName = 'LMS';
        var _userService = abp.services.app.user;
        var L = function (name) {
            return abp.localization.localize(name)
        }

        var _createOrEditModal = new app.ModalManager({
            viewRul: '/Admin/User/CreateOrEditModal',
            scriptUrl: '~/Areas/Admin/Views/User/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditUserModal'
        });

        //提示信息
        var lang = {
            "sProcessing": "处理中...",
            //"sLengthMenu": "每页 _MENU_ 项",
            "sLengthMenu": "_MENU_",
            "sZeroRecords": "没有匹配结果",
            //"sInfo": "当前显示第 _START_ 至 _END_ 项，共 _TOTAL_ 项。",
            "sInfo": "共 _TOTAL_ 项",
            "sInfoEmpty": "第 0 至 0 项，共 0 项",
            "sInfoFiltered": "",
            "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
            "sInfoPostFix": "",
            "sSearch": "搜索:",
            "sUrl": "",
            "sEmptyTable": "表中数据为空",
            "sLoadingRecords": "载入中...",
            "sInfoThousands": ",",
            "oPaginate": {
                "sFirst": "首页",
                "sPrevious": "<",
                "sNext": ">",
                "sLast": "末页",
                "sJump": "跳转"
            },
            "oAria": {
                "sSortAscending": ": 以升序排列此列",
                "sSortDescending": ": 以降序排列此列"
            }
        };

        var _$usersTable = $('#userList').DataTable({
            //提示信息
            language: lang,
            //为奇偶行加上样式，兼容不支持CSS伪类的场合
            stripeClasses: ["odd", "even"],
            searching: true //启用原生搜索
            , serverSide: true //启用服务器端分页
            //, dom: "<'row'<'col-sm-12'f>>" +
            //"<'row'<'col-sm-12'tr>>" +
            //"<'row'<'col-sm-5'i><'col-sm-7'<'col-sm-6 col-md-2'l><'col-sm-10'p>>>"
            //分页样式：simple,simple_numbers,full,full_numbers
            //, pagingType: "simple_numbers"
            //, orderMulti: false //启用多列排序
            //, order: [] //取消默认排序查询,否则复选框一列会出现小箭头
            //, renderer: "bootstrap" //渲染样式：Bootstrap和jquery-ui
            //, info: true
            , stateSave: true
            //, lengthMenu: [[10, 20, 50, -1], [10, 20, 50, "All"]]
            , processing: true //隐藏加载提示,自行处理
            , "ajax": {
                "url": "/Mpa/User/List"
                , "type": "post"
                //, "data": function (data) {
                //    //data.Name = $("#name").val();;//此处是添加额外的请求参数
                //    return JSON.stringify(data);
                //}
            }
            , "columns": [
                //{ "data": "Id", visible: false, },
                { "data": "null", "defaultContent": '' },
                { "data": "Name", visible: false, },
                { "data": "Surname", visible: false, },
                { "data": "UserName" },
                { "data": "FullName" },
                { "data": "EmailAddress" }
            ]
            //columnDefs 会覆盖 columns 里的内容
            , "columnDefs": [
            {
                //0表示第一行 -1 表示最后一行
                targets: 0
                , "width": "80"
                , searchable: false
                , orderable: false
                , render: function (data, type, full, meta) {
                    return '<div class="btn-group" style="min-width:90px;"><button type="button" class="btn btn-info btn-sm dropdown-toggle" data-toggle="dropdown" aria-expanded="false">Action</button><button type="button" class="btn btn-info btn-sm dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><span class="caret"></span><span class="sr-only">Toggle Dropdown</span></button><ul class="dropdown-menu" role="menu"><li><a class="edit" id="' + full.Id + '" href="javascript:void(0);">' + L('Edit') + '</a></li><li><a href="#">Another action</a></li><li><a href="#">Something else here</a></li><li class="divider"></li><li><a  class="delete" id="' + full.Id + '" href="javascript:void(0);" style="color:red;">' + L('Delete') + '</a></li></ul></div>';
                }
            }]
        });

        //bind edit
        $('#userList tbody').on('click', 'a[class="edit"]', function () {

            var uId = $(this).attr("id");
            _createOrEditModal.open({ Id: uId });

        });
        // bind delete
        $('#userList tbody').on('click', 'a[class="delete"]', function () {
            var uId = $(this).attr("id");
            $.confirm({
                icon: 'fa fa-warning',
                type: 'red',
                typeAnimated: true,
                title: 'Warning',
                buttons: {
                    yes: {
                        text: 'Yes', // Some Non-Alphanumeric characters
                        action: function () {
                            _userService.deleteUser({ Id: uId }).done(function () {
                                abp.notify.success(L("DeleteSuccessfully"));
                                getUsers(true);
                            }).always(function () {
                            });
                        }
                    },
                    no: {
                        text: 'No', // Some Non-Alphanumeric characters
                        action: function () {
                        }
                    }
                },
                content: "Are you sure to delete this record?",
            });
        });

        $('#CreateNewUserButton').click(function () {
            _createOrEditModal.open();
        });

        abp.event.on('app.createOrEditUserModalSaved', function () {
            getUsers(true);
        });

        function getUsers(reload) {
            if (reload) {
                _$usersTable.ajax.reload();
            } else {
                _$usersTable.ajax.reload();
                //_$usersTable.jtable('load', {
                //    filter: $('#UsersTableFilter').val(),
                //    permission: $("#PermissionSelectionCombo").val(),
                //    role: $("#RoleSelectionCombo").val()
                //});
            }
        }
    });
})();