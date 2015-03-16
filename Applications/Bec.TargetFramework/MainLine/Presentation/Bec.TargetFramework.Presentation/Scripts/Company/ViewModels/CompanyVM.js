define([], function myfunction() {
    "use strict";

    var CompanyVM = function (data) {
        data = data || {};
        var self = this;
        
        self.name = ko.observable();
        self.address1 = ko.observable();
        self.address2 = ko.observable();
        self.townCity = ko.observable();
        self.county = ko.observable();
        self.postCode = ko.observable();
        self.firstName = ko.observable();
        self.lastName = ko.observable();
        self.sysAdmin = ko.observable();
        self.tel = ko.observable();
        self.recordCreated = ko.observable();
        self.email = ko.observable();
        self.isVerified = ko.observable();
        self.regulator = ko.observable();
        self.regulatorToDisplay = ko.observable();
        self.isPinCreated = ko.observable();
        self.pinCreated = ko.observable();
        self.pinCode = ko.observable();

        self.data;

        self.initialize(data);
    }

    CompanyVM.prototype.initialize = function (data) {
        var self = this;

        self.name(data.name || '-');
        self.address1(data.address1 || '-');
        self.address2(data.address2 );
        self.townCity(data.townCity);
        self.county(data.county);
        self.postCode(data.postCode);
        self.firstName(data.firstName);
        self.lastName(data.lastName);
        self.sysAdmin(data.sysAdmin || '-');
        self.tel(data.tel || '-');

        if (data.recordCreated) {
             self.recordCreated(new Date(data.recordCreated));
        }
        else {
            self.recordCreated('-');
        }
       
        self.email(data.email || '-');
        self.isVerified(data.isVerified || '-');
        self.regulator(data.regulator || '-');
        self.regulatorToDisplay(data.regulatorToDisplay || '-');
        self.isPinCreated(data.isPinCreated || '-');

        if (data.pinCreated) {
            self.pinCreated(new Date(data.pinCreated));
        }
        else {
            self.pinCreated('-');
        }
     
        self.pinCode(data.pinCode || '-');

        self.data = data;
    }

    return CompanyVM;
});

