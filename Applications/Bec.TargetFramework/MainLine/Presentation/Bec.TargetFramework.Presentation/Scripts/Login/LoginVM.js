define(['Login/LoginExecutor'], function (LoginExecutor) {
    "use strict";

    var LoginVM = function (data) {
        data = data || {};
        var self = this;

        self.username = ko.observable();
        self.usernameCaption = ko.observable();

        self.password = ko.observable();
        self.passwordStars = ko.observable();
        self.passwordCaption = ko.observable();

        self.showErrors = ko.observable();

        self.returnUrl;
        self.authenticateUserURL;

        self.customErrMessage = ko.observable();
        self.isWaitingForResponse = ko.observable();

        self.errorMessages = {};

        self.initialize(data);
    }

    LoginVM.prototype.initialize = function (data) {
        var self = this;

        self.showErrors(false);

        self.returnUrl = data.returnURL;
        self.authenticateUserURL = data.authenticateUserURL;

        self.usernameCaption(data.usernameCaption);
        self.passwordCaption(data.passwordCaption);

        //------Error Message Handling
        if (data.errorMessages) {
            self.errorMessages = data.errorMessages
        }

        self.username.extend({
            required: {
                message: ko.utils.stringFormat(self.errorMessages["required"], self.usernameCaption()), // "Username is required!",
            }
        });

        self.password.extend({
            required: {
                message: ko.utils.stringFormat(self.errorMessages["required"], self.passwordCaption()),//"Password is required!",
            }
        });

        //clear the error messages
        self.username.error('');
        self.password.error('');

        self.isWaitingForResponse(false);


    };

    LoginVM.prototype.confirmLogin = function (model, event) {
        var self = this;

        self.showErrors(false);
        self.customErrMessage('');

        if (self.isValid() && !self.isWaitingForResponse()) {
            var isOpera = !!window.opera || navigator.userAgent.indexOf(' OPR/') >= 0;
            var isFirefox = typeof InstallTrigger !== 'undefined';   // Firefox 1.0+
            var isSafari = Object.prototype.toString.call(window.HTMLElement).indexOf('Constructor') > 0;
            // At least Safari 3+: "[object HTMLElementConstructor]"
            var isChrome = !!window.chrome && !isOpera;
            var isIE = /*@cc_on!@*/false || !!document.documentMode;

            var stars = '';
            var generateStars = function myfunction(char) {
                for (var i = 0; i < self.password().length; i++) {
                    stars += char;
                }
            }

            if (isChrome || isSafari || isOpera) {
                generateStars('\u2022');
            }

            if (isFirefox || isIE) {
                generateStars('\u25CF');
            }

            self.passwordStars(stars);

            self.showErrors(false);
            self.isWaitingForResponse(true);

            var button = $('#login-btn')[0];
            var buttonHTML = button.innerHTML;

            ko.utils.markButtonAsWaitingForResponse(button);

            var onSuccess = function (data) {

                if (data.returnUrl) {
                    
                    window.location.href = data.returnUrl;
                }
                else {
                    self.customErrMessage(data.validationMessage);
                    ko.utils.unmarkButtonAsWaitingForResponse(button, buttonHTML);

                    setTimeout(function () { self.isWaitingForResponse(false)}, 1000);
                }
            };

            var onError = function (data) {
                self.isWaitingForResponse(false);
                self.showErrors(false);
                ko.utils.unmarkButtonAsWaitingForResponse(button, buttonHTML);
            };

            var userVM = self.toJSON();

            LoginExecutor.authenticateUser(userVM, onSuccess, onError, self.authenticateUserURL);
        }
        else {
            if (!self.isWaitingForResponse()) {
                self.showErrors(true);
            }
        }
    };

    LoginVM.prototype.toJSON = function () {
        var copy = ko.toJS(this);

        delete copy.confirmLogin;
        delete copy.initialize;
        delete copy.isValid;
        delete copy.toJSON;
        delete copy.attachEvents;
        delete copy.authenticateUserURL;
        return copy;
    }

    LoginVM.prototype.isValid = function () {
        var self = this;
        var errors = ko.validation.group([self.username, self.password]);

        if (errors().length < 1) {
            return true;
        }
        else {
            errors.showAllMessages();
            return false;
        }
    }

    return LoginVM;
})