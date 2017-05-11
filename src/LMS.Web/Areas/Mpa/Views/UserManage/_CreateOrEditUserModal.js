
(function ($) {
    app.modals.CreateOrEditUserModal = function () {

        var _modalManager;

        var _userService = abp.services.app.user;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$userInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$userInformationForm = _modalManager.getModal().find("form[name=userInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 	 	 // 初始化 LastLoginTime 的包含时分秒的日期控件
		   //包含时分秒的日期选择器             
            $("input[name=LastLoginTime]").datetimepicker({
                autoclose: true,
                isRTL: false,
                format: "yyyy-mm-dd hh:ii",
                pickerPosition: ("bottom-left"),
				//默认为E文按钮要中文，自己去找语言包
				   todayBtn: true,
				     language: "zh-CN"
            });
	 


			
			
      


        }
        
        this.save = function () {
            if (!_$userInformationForm.valid()) {
                return;
            }
            //校验通过

            var user = _$userInformationForm.serializeFormToObject();
          //  console.log(user);

            _modalManager.setBusy(true);

            _userService.createOrUpdateUserAsync({
                userEditDto: user
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditUserModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   