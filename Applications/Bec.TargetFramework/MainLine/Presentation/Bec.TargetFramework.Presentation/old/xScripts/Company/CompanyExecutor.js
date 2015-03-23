define([], function () {

    var CompanyExecutor = function () {
        //Private members

        // Request params
        var _requestParamNameData = "data=";

        // Functions
        function addCompany(addCompanyVM, onSuccess, onError) {
            $.ajax({
                type: "POST",
                contentType: "application/x-www-form-urlencoded; application/json; charset=UTF-8",//"application/json; charset=utf-8",
                dataType: "json",
                url: addCompanyVM.addCompanyUrl,
                data: addCompanyVM,
                success: onSuccess,
                error: onError
            });
        };
        return {
            addCompany: addCompany
        };
    }();

    return CompanyExecutor;
});