define(['Company/CompanyExecutor'], function (CompanyExecutor) {
    "use strict";

    var AddCompanyVM = function (data) {
        data = data || {};
        var self = this;
        self.titleChoices = ko.observableArray(["Mr.", "Mrs.", "Miss.", "Ms.", "Dr."]);
        self.titleOptionLabel = ko.observable("  ");

        self.regulatorChoices = ko.observableArray(["SRA", "CLC", "Other"]);
        self.regulatorOptionLabel = ko.observable("Please Select");

        self.name = ko.observable();
        self.address1 = ko.observable();
        self.address2 = ko.observable();
        self.townCity = ko.observable();
        self.county = ko.observable();
        self.postCode = ko.observable();
        self.firstName = ko.observable();
        self.lastName = ko.observable();
        self.tel = ko.observable();
        self.email = ko.observable();
        self.regulator = ko.observable();
        self.otherRegulator = ko.observable();

        self.addCompanyUrl;
        self.returnUrl;

        self.initialize(data);
    }

    AddCompanyVM.prototype.initialize = function (data) {
        var self = this;
            
        self.addCompanyUrl = data.addCompanyUrl;
        self.returnUrl = data.returnUrl;
    }

    AddCompanyVM.prototype.reset = function () {
        var self = this;

        self.name('');
        self.address1('');
        self.address2('');
        self.townCity('');
        self.county('');
        self.postCode('');
        self.firstName('');
        self.lastName('');
        self.tel('');
        self.email('');
        self.regulator('');
        self.otherRegulator('');
    }

    AddCompanyVM.prototype.addCompany = function (model, event) {

        $('.cancel-add-company-btn').addClass('fired');

        var self = this;
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
        };

        var button = $('#save-company-btn')[0];
        var buttonHTML = button.innerHTML;

        ko.utils.markButtonAsWaitingForResponse(button);

        var addCompanyVM = self.toJSON();
        CompanyExecutor.addCompany(addCompanyVM, onSuccess, onError);
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
        return copy;
    }

    return AddCompanyVM;
})
