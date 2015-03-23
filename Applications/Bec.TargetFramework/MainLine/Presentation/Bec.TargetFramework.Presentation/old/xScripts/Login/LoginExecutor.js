define([], function () {

    var LoginExecutor = function () {
        //Private members

        // Request params
        var _requestParamNameData = "data=";

        // Urls
        //var _authenticateUserUrl = '/UserAccount/Login/AuthenticateUser';

        // Functions
        function authenticateUser(userVM, onSuccess, onError,  authenticateUserURL) {

            $.ajax({
                type: "POST",
                contentType: "application/x-www-form-urlencoded; application/json; charset=UTF-8",//"application/json; charset=utf-8",
                dataType: "json",
                url: authenticateUserURL,
                data: userVM,
                success: onSuccess,
                error: onError
            });
        };

        return {
            authenticateUser: authenticateUser
        };
    }();

    return LoginExecutor;
});