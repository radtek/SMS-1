define(['Company/ViewModels/CompanyVM'], function myfunction(CompanyVM) {
    "use strict";

    var AllCompaniesVM = function (data) {
        data = data || {};
        var self = this;

        self.verifiedCompanies;

        self.unverifiedCompanies;

        self.verifiedCompany = ko.observable();
        self.unverifiedCompany = ko.observable();

        self.selectedUnverifiedCompany = null;
        self.selectedVerifiedCompany = null;

        self.newCompanyId;

        self.initialize(data);

        self.onChange = function (e, that, gridNameForChange) {
            e.preventDefault();
            var dataItem = that.dataItem($(that.select()).closest("tr"));

            if (gridNameForChange == 'unverified-grid') {
                self.unverifiedCompany().initialize(dataItem);
                self.selectedUnverifiedCompany = dataItem;
            }
            else {
                self.verifiedCompany().initialize(dataItem);
                self.selectedVerifiedCompany = dataItem;
            }
        }

        self.onDataBound = function (e, gridNameForUpdate) {
            var selectedItem;

            var theGridEl = $("#" + gridNameForUpdate);

            var theGrid = theGridEl.data("kendoGrid");

            if (theGrid.dataSource.data().length < 1) {
                return;
            }

            if (gridNameForUpdate == 'unverified-grid') {

                if (self.newCompanyId) {
                    var grid = $("#unverified-grid").data("kendoGrid");
                    var dataUnverifiedCompanies = grid.dataSource.data();

                    for (var i = 0; i < dataUnverifiedCompanies.length; i++) {
                        if (self.newCompanyId == (dataUnverifiedCompanies[i].companyId)) {

                            selectedItem = dataUnverifiedCompanies[i];
                            break;
                        }
                    }

                    //remove companyId, clean the model
                    self.newCompanyId = '';
                }
                else {
                    if (self.selectedUnverifiedCompany != null) {
                        self.unverifiedCompany().initialize(self.selectedUnverifiedCompany);

                        selectedItem = self.selectedUnverifiedCompany;
                    }
                    else {
                        return;
                    }
                }
            }
            else {
                if (self.selectedVerifiedCompany != null) {
                    self.verifiedCompany().initialize(self.selectedVerifiedCompany);

                    selectedItem = self.selectedVerifiedCompany;
                }
                else {
                    return;
                }
            }

            if (selectedItem) {
                var targetUid = selectedItem.uid;

                var theGridEl = $("#" + gridNameForUpdate);

                var theGrid = theGridEl.data("kendoGrid");

                var row = theGridEl.find("tr[data-uid='" + targetUid + "']");
                theGrid.select(row);

                var scrollContentOffset = theGridEl.find("tbody").offset().top;
                var selectContentOffset = theGrid.select().offset().top;
                var distance = selectContentOffset - scrollContentOffset;

                //    animate our scroll
                theGridEl.find(".k-grid-content").animate({
                    scrollTop: distance
                }, 400);
            }
        }

        self.onDataBinding = function (args, gridName) {
        }

        self.test = function (searchData) {
            var searchval = searchData;
            if (!searchval) {
                return;
            }
            var grid = $("#verified").data("kendoGrid");
            grid.select("tr:containsIgnoreCase('" + searchval + "')");
        }

        self.unverifiedGridOptions = function (data) {
            return {
                data: data,
                scrollable: true,
                change: function (e) {
                    self.onChange(e, this, 'unverified-grid');
                },
                sortable: {
                    mode: "single",
                    allowUnsort: false

                },
                selectable: true,
                dataBound: function (e) {
                    self.onDataBound(e, 'unverified-grid');
                },
                dataBinding: function (e) {
                    self.onDataBinding(e, 'unverified-grid');
                },
                dataSource: {
                    schema: {
                        model: {
                            id: 'id',
                            fields: {
                                'companyName': { type: 'string' },
                                'companyAddress1': { type: 'string' },
                                'companyPostCode': { type: 'string' },
                                'sysAdmin': { type: 'string' },
                                'systemAdminTel': { type: 'string' },
                                'systemAdminEmail': { type: 'string' },
                                'companyRecordCreated': { type: 'date' }
                            }
                        }
                    },
                    sort: { field: 'companyRecordCreated', dir: 'asc' }
                },
                columns: [{
                    field: 'companyName',
                    width: 150,
                    headerTemplate: '<label class="underline">Company Name</label>'
                },
                {
                    field: 'companyAddress1',
                    width: 250,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Address 1</label>'
                },
                {
                    field: 'companyPostCode',
                    width: 120,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Post Code</label>'
                },
                {
                    field: 'sysAdmin',
                    width: 180,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">System Administrator</label>'
                },
                {
                    field: 'systemAdminTel',
                    width: 130,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Telephone No</label>'
                },
                {
                    field: 'systemAdminEmail',
                    width: 200,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Email</label>'
                },
                {
                    field: 'companyRecordCreated',
                    template: "#= kendo.toString(kendo.parseDate(companyRecordCreated, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                    headerTemplate: '<label class="underline">Record Created</label>',
                    width: 150
                }]

            }
        };

        self.verifiedGridOptions = function (data) {
            return {
                scrollable: true,
                data: data,
                change: function (e) {
                    self.onChange(e, this, 'verified-grid');
                },
                sortable: {
                    mode: "single",
                    allowUnsort: false
                },
                selectable: true,
                dataBound: function (e) {
                    self.onDataBound(e, 'verified-grid');
                },
                dataBinding: function (e) {
                    self.onDataBinding(e, 'verified-grid');
                },
                dataSource: {
                    schema: {
                        model: {
                            id: 'id',
                            fields: {
                                'companyName': { type: 'string' },
                                'companyPinCode': { type: 'string' },
                                'companyPinCreated': { type: 'date' },
                                'companyPostCode': { type: 'string' },
                                'sysAdmin': { type: 'string' },
                                'systemAdminTel': { type: 'string' },
                                'systemAdminEmail': { type: 'string' },
                                'companyRecordCreated': { type: 'date' }
                            }
                        }
                    },
                    sort: { field: 'companyRecordCreated', dir: 'asc' }
                },
                columns: [{
                    title: 'Company Name',
                    field: 'companyName',
                    width: 150,
                    headerTemplate: '<label class="underline">Company Name</label>'
                },
                {
                    title: 'PIN Number',
                    field: 'companyPinCode',
                    width: 100,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">PIN Number</label>'
                },
                {
                    title: 'PIN Created',
                    field: 'companyPinCreated',
                    template: "#= (companyPinCreated== null) ? ' ' : kendo.toString(kendo.parseDate(companyPinCreated, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                    width: 100,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">PIN Created</label>'
                },
                {
                    title: 'Post Code',
                    field: 'companyPostCode',
                    width: 120,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Post Code</label>'
                },
                {
                    title: 'System Administrator',
                    field: 'sysAdmin',
                    width: 180,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">System Administrator</label>'
                },
                {
                    title: 'Telephone No',
                    field: 'systemAdminTel',
                    width: 130,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Telephone No</label>'
                },
                {
                    title: 'Email',
                    field: 'systemAdminEmail',
                    width: 200,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Email</label>'
                },
                {
                    title: 'Record Created',
                    field: 'companyRecordCreated',
                    template: "#= kendo.toString(kendo.parseDate(companyRecordCreated, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                    headerTemplate: '<label class="underline">Record Created</label>',
                    width: 150
                }]
            }
        };
    }

    AllCompaniesVM.prototype.initialize = function (data) {
        var self = this;
        self.verifiedCompanies = data.verifiedCompanies;
        self.unverifiedCompanies = data.unverifiedCompanies;

        self.newCompanyId = data.newCompanyId;
        self.verifiedCompany(new CompanyVM());
        self.unverifiedCompany(new CompanyVM());
    }

    AllCompaniesVM.prototype.addCompany = function ($data) {
        var self = this;

    };

    return AllCompaniesVM;
});