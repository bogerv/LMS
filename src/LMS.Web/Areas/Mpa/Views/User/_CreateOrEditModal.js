(function ($) {
        
    app.modals.CreateOrEditUserModal = function () {

        var _userService = abp.services.app.user;

        var _modalManager;
        var _$userBasicInfoForm = null;

        function _findAssignedRoleNames() {
            var assignedRoleNames = [];

            _modalManager.getModal()
                .find('#user-roles .user-role-check-list input[type=checkbox]')
                .each(function () {
                    if ($(this).is(':checked')) {
                        assignedRoleNames.push($(this).attr('name'));
                    }
                });

            return assignedRoleNames;
        }

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

            _$userBasicInfoForm = _modalManager.getModal().find('form[name=UserBasicInfoForm]');
            _$userBasicInfoForm.validate();
        }

        this.save = function () {
            if (!_$userBasicInfoForm.valid()) {
                return;
            }

            var assignedRoleNames = _findAssignedRoleNames();
            var user = _$userBasicInfoForm.serializeFormToObject();

            user.IsActive = user.IsActive === "on" ? true : false;
            //if (user.SetRandomPassword) {
            //    user.Password = null;
            //}

            _modalManager.setBusy(true);
            _userService.createOrUpdateUser({
                user: user,
                assignedRoleNames: assignedRoleNames,
                //sendActivationEmail: user.SendActivationEmail,
                //SetRandomPassword: user.SetRandomPassword
            }).done(function () {
                abp.localization.defaultSourceName = 'Wicrecend';
                abp.notify.success(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditUserModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };

    };

})(jQuery);