define([], function myfunction() {
    "use strict";

    var CompanyVM = function (data) {
        data = data || {};
        var self = this;
        
        self.companyId = ko.observable();
        self.companyName = ko.observable();
        self.companyAddress1 = ko.observable();
        self.companyAddress2 = ko.observable();
        self.companyTownCity = ko.observable();
        self.companyCounty = ko.observable();
        self.companyPostCode = ko.observable();
        self.systemAdminTitle = ko.observable();
        self.systemAdminFirstName = ko.observable();
        self.systemAdminLastName = ko.observable();
        
        self.systemAdminTel = ko.observable();
        self.companyRecordCreated = ko.observable();
        self.systemAdminEmail = ko.observable();
        self.isCompanyVerified = ko.observable();
        self.companyRegulator = ko.observable();
        self.companyOtherRegulator = ko.observable();
        self.regulatorToDisplay = ko.observable();
        self.isCompanyPinCreated = ko.observable();
        self.companyPinCreated = ko.observable();
        self.companyPinCode = ko.observable();

        self.sysAdmin = ko.computed(function () {
            
            if (self.systemAdminFirstName() ||
                    self.systemAdminLastName()) {
                
                var result = (
                    self.systemAdminTitle() +
                    (self.systemAdminFirstName() ? ' ' : '') +
                    (self.systemAdminFirstName() || '') +
                    ' ' +
                    (self.systemAdminLastName() || '')
                );

                return result;
                
            }
            else {
                return '-';
            }
        }, self);

        self.initialize(data);
    }

    CompanyVM.prototype.initialize = function (data) {
        var self = this;

        self.companyId = ko.observable(data.companyId);
        self.companyName(data.companyName || '-');
        self.companyAddress1(data.companyAddress1 || '-');
        self.companyAddress2(data.companyAddress2);
        self.companyTownCity(data.companyTownCity);
        self.companyCounty(data.companyCounty);
        self.companyPostCode(data.companyPostCode);
        self.systemAdminTitle(data.systemAdminTitle);
        self.systemAdminFirstName(data.systemAdminFirstName);
        self.systemAdminLastName(data.systemAdminLastName);
        self.systemAdminTel(data.systemAdminTel || '-');

        if (data.companyRecordCreated) {
            self.companyRecordCreated(new Date(data.companyRecordCreated));
        }
        else {
            self.companyRecordCreated('-');
        }
       
        self.systemAdminEmail(data.systemAdminEmail || '-');
        self.isCompanyVerified(data.isCompanyVerified || '-');
        self.companyRegulator(data.companyRegulator || '-');
        self.companyOtherRegulator(data.companyOtherRegulator || '-');
        self.isCompanyPinCreated(data.isCompanyPinCreated || '-');

        if (data.companyPinCreated) {
            self.companyPinCreated(new Date(data.companyPinCreated));
        }
        else {
            self.companyPinCreated('-');
        }
     
        self.companyPinCode(data.companyPinCode || '-');

        self.data = data;
    }

    return CompanyVM;
});

