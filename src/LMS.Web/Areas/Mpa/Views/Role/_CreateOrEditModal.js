(function ($) {

    app.modals.CreateOrEditRoleModal = function () {

        var _modalManager;
        var _roleService = abp.services.app.role;
        var _$roleBasicRoleForm = null;
        var _permissionsTree;

        function _initCheckbox() {
            var _$checkbox = $("input[type=checkbox]");
            _$checkbox.each(function () {
                $(this).iCheck({
                    checkboxClass: 'icheckbox_square-blue user-role-check-list',
                    radioClass: 'iradio_square-blue',
                    increaseArea: '20%' // optional
                });
            });
        }

        this.init = function (modalManager) {

            _initCheckbox();
            _modalManager = modalManager;

            _permissionsTree = new PermissionsTree();
            _permissionsTree.init(_modalManager.getModal().find('.permission-tree'));

            _$roleBasicRoleForm = _modalManager.getModal().find('form[name=BasicRoleForm]');
            _$roleBasicRoleForm.validate();
        };

        this.save = function () {

            if (!_$roleBasicRoleForm.validate()) {
                return;
            }

            var role = _$roleBasicRoleForm.serializeFormToObject();

            role.IsActive = role.IsActive === "on" ? true : false;

            _modalManager.setBusy(true);
            _roleService.createOrEditRole({
                role: role,
                grantedPermissionNames: _permissionsTree.getSelectedPermissionNames()
            }).done(function () {
                abp.localization.defaultSourceName = 'Wicrecend';
                abp.notify.success(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditRoleModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });

        };

    };

})(jQuery);