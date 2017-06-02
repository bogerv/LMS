(function () {
    $(function () {
        abp.localization.defaultSourceName = 'Wicrecend';
        var L = function (name) {
            return abp.localization.localize(name)
        }

        var _roleService = abp.services.app.role;

        var _CreateOrEditModal = new app.ModalManager({
            viewRul: "/Admin/Role/CreateOrEditRole",
            scriptUrl: "~/Areas/Admin/Views/Role/_CreateOrEditModal.js",
            modalClass: "CreateOrEditRoleModal"
        });

        var _$rolesTable = $('#roleList').DataTable({//提示信息
            searching: true //启用原生搜索
            , serverSide: true //启用服务器端分页
            , stateSave: true
            , processing: true //隐藏加载提示,自行处理
            , "ajax": {
                "url": "/Admin/Role/List"
                , "type": "post"
                //, "data": function (data) {
                //    //data.Name = $("#name").val();;//此处是添加额外的请求参数
                //    return JSON.stringify(data);
                //}
            }
            , "columns": [
                { "data": "null", "defaultContent": '' },
                { "data": "Name" },
                { "data": "DisplayName" },
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
        $('#roleList tbody').on('click', 'a[class="edit"]', function () {

            var uId = $(this).attr("id");
            _CreateOrEditModal.open({ Id: uId });

        });
        // bind delete
        $('#roleList tbody').on('click', 'a[class="delete"]', function () {
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
                            _roleService.deleteRole({ Id: uId }).done(function () {
                                getRoles(true);
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

        var _$modal = $('#RoleCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        _$form.find('button[type="submit"]').on('click', function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject();

            _roleService.createRole(user).done(function () {
                table.ajax.reload();
            }).always(function () {
                _$modal.modal('hide');
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        $('#CreateNewRoleButton').click(function () {
            _CreateOrEditModal.open();
        });

        abp.event.on('app.createOrEditRoleModalSaved', function () {
            getRoles(true);
        });

        function getRoles(reload) {
            if (reload) {
                _$rolesTable.ajax.reload();
            } else {
                _$rolesTable.ajax.reload();
            }
        }
    });
})();