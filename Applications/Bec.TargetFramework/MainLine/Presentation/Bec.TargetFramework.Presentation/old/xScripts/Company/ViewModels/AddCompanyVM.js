define(['Company/CompanyExecutor'], function (CompanyExecutor) {
    "use strict";

    var AddCompanyVM = function (data) {
        data = data || {};
        var self = this;
        self.titleChoices = ko.observableArray(["Mr.", "Mrs.", "Miss.", "Ms.", "Dr."]);
        self.titleOptionLabel = ko.observable(" ");

        self.regulatorChoices = ko.observableArray(["SRA", "CLC", "Other"]);
        self.regulatorOptionLabel = ko.observable("Please Select");

        self.companyName = ko.observable();
        self.companyAddress1 = ko.observable();
        self.companyAddress2 = ko.observable();
        self.additionalAddressInformation = ko.observable();
        self.companyTownCity = ko.observable();
        self.companyCounty = ko.observable();
        self.companyPostCode = ko.observable();
        self.systemAdminTitle = ko.observable().extend({ rateLimit: 150 });
        self.systemAdminFirstName = ko.observable();
        self.systemAdminLastName = ko.observable();
        self.systemAdminTel = ko.observable();
        self.systemAdminEmail = ko.observable();
        self.companyRegulator = ko.observable().extend({ rateLimit: 150 });
        self.companyOtherRegulator = ko.observable().extend({ rateLimit: 150 });

        self.companyRegulatorGeneral = ko.observable().extend({ rateLimit: 150 });

        self.addCompanyUrl;
        self.returnUrl;

        self.initialize(data);
    }

    AddCompanyVM.prototype.initialize = function (data) {
        var self = this;

        self.addCompanyUrl = data.addCompanyUrl;
        self.returnUrl = data.returnUrl;

        self.companyName.extend({
            required: true
        });

        self.companyAddress1.extend({
            required: true
        });

        self.companyTownCity.extend({
            required: true
        });

        self.companyPostCode.extend({
            required: true
        });

        self.systemAdminFirstName.extend({
            required: true
        });

        self.systemAdminLastName.extend({
            required: true
        });

        self.systemAdminTel.extend({
            required: true
        });

        self.systemAdminEmail.extend({
            required: true
        });

        self.companyRegulatorGeneral.extend({
            required: true
        });


        self.systemAdminTitle.extend({
            required: true
        });

        self.companyRegulator.subscribe(function (companyRegulatorNewValue) {
            //if (companyRegulatorNewValue != 'Other') {
            //    self.companyOtherRegulator('');
            //}

            if (companyRegulatorNewValue == 'Please Select') {
                self.companyRegulator('');
                self.companyOtherRegulator('');
            }

            if (companyRegulatorNewValue == 'Other') {
                self.companyRegulatorGeneral('');

                self.companyRegulatorGeneral('something');
            }
            else {
                self.companyOtherRegulator('');
                self.companyRegulatorGeneral(companyRegulatorNewValue);
            }
        });

        self.companyOtherRegulator.subscribe(function (companyOtherRegulatorNewValue) {
            self.companyRegulatorGeneral(companyOtherRegulatorNewValue);
        });

        self.systemAdminTitle.subscribe(function (titleNewValue) {
            if (titleNewValue == ' ') {
                self.systemAdminTitle('');
            }
        })
    };

    AddCompanyVM.prototype.addCompany = function (model, event) {
        var self = this;

        if (self.isValid()) {
            if (self.companyOtherRegulator()) {
                self.companyRegulator('');
            }

            $('.cancel-add-company-btn').addClass('fired');


            var onSuccess = function (data) {
                if (data.returnUrl) {
                    window.location.href = data.returnUrl;
                }
                else {
                    $('.cancel-add-company-btn').removeClass('fired');
                    ko.utils.unmarkButtonAsWaitingForResponse(button, buttonHTML);
                }
            };

            var onError = function (data) {
                $('.cancel-add-company-btn').removeClass('fired');
                ko.utils.unmarkButtonAsWaitingForResponse(button, buttonHTML);
                debugger;
                window.location.href = '~/UserAccount/Login/Index';
            };

            var button = $('#save-company-btn')[0];
            var buttonHTML = button.innerHTML;

            ko.utils.markButtonAsWaitingForResponse(button);

            var addCompanyVM = self.toJSON();
            CompanyExecutor.addCompany(addCompanyVM, onSuccess, onError);
        }
        
    };

    AddCompanyVM.prototype.toJSON = function () {
        var copy = ko.toJS(this);

        delete copy.titleChoices;
        delete copy.regulatorChoices;
        delete copy.titleOptionLabel;
        delete copy.regulatorOptionLabel;
        delete copy.reset;
        delete copy.initialize;
        delete copy.addCompany;
        delete copy.toJSON;
        delete copy.isValid;
        return copy;

    }

    AddCompanyVM.prototype.isValid = function () {
        var self = this;

        var errors = ko.validation.group([
            self.companyName,
            self.companyAddress1,
            self.companyTownCity,
            self.companyPostCode,
            self.systemAdminFirstName,
            self.systemAdminLastName,
            self.systemAdminTel,
            self.systemAdminEmail,
            self.systemAdminTitle
        ]);

        if (errors().length < 1) {
            if (self.companyRegulator() || self.companyOtherRegulator()) {
                if (self.companyRegulator() == 'Other' && self.companyOtherRegulator()) {
                    return true;
                }

                if (self.companyRegulator() && self.companyRegulator() != 'Other') {
                    return true;
                }
            }
        }
       
        errors.showAllMessages();

        if (self.companyRegulator() == 'Other' && !self.companyOtherRegulator()) {
            self.companyRegulatorGeneral('');

            var customErrors = ko.validation.group([self.companyRegulatorGeneral]);
            customErrors.showAllMessages();
        }

        return false;
    }

    return AddCompanyVM;
})
