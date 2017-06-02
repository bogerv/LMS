var app = app || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('LMS');
    app.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(app);