define(['Company/ViewModels/CompanyVM'], function myfunction(CompanyVM) {
    "use strict";

    var AllCompaniesVM = function (data) {
        data = data || {};
        var self = this;

        self.verifiedCompanies = data.verifiedCompanies;

        self.unverifiedCompanies = data.unverifiedCompanies;

        self.verifiedCompany = ko.observable();
        self.unverifiedCompany = ko.observable();

        self.selectedUnverifiedCompany = null;
        self.selectedVerifiedCompany = null;

        self.companyAddedTickDate;

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

            //console.log(new Date());
            //console.log('onDataBound ' + gridNameForUpdate);
            //console.log($("#" + gridNameForUpdate).data("kendoGrid").dataSource.data().length);
            //console.log('');
            

            if (gridNameForUpdate == 'unverified-grid') {

                if (self.companyAddedTickDate) {
                    var grid = $("#unverified-grid").data("kendoGrid");
                    var dataUnverifiedCompanies = grid.dataSource.data();

                    for (var i = 0; i < dataUnverifiedCompanies.length; i++) {
                        if (self.companyAddedTickDate == (new Date(dataUnverifiedCompanies[i].recordCreated)).getTime()) {
                            selectedItem = dataUnverifiedCompanies[i];
                            break;
                        }
                    }
                    var targetUid = selectedItem.uid;

                    var theGridEl = $("#" + gridNameForUpdate);

                    var theGrid = theGridEl.data("kendoGrid");

                    var row = theGridEl.find("tr[data-uid='" + targetUid + "']");
                    theGrid.select(row);

                    var scrollContentOffset = theGridEl.find("tbody").offset().top;
                    var selectContentOffset = theGrid.select().offset().top;
                    var distance = selectContentOffset - scrollContentOffset;

                    self.companyAddedTickDate = '';
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
                dataBinding:  function (e) {
                    self.onDataBinding(e, 'unverified-grid');
                },
                dataSource: {
                    schema: {
                        model: {
                            id: 'id',
                            fields: {
                                'name': { type: 'string' },
                                'address1': { type: 'string' },
                                'postCode': { type: 'string' },
                                'sysAdmin': { type: 'string' },
                                'tel': { type: 'string' },
                                'email': { type: 'string' },
                                'recordCreated': { type: 'date' }
                            }
                        }
                    },
                    sort: { field: 'recordCreated', dir: 'asc' }
                },
                columns: [{
                    field: 'name',
                    width: 150,
                    headerTemplate: '<label class="underline">Company Name</label>'
                },
                {
                    field: 'address1',
                    width: 250,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Address 1</label>'
                },
                {
                    field: 'postCode',
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
                    field: 'tel',
                    width: 130,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Telephone No</label>'
                },
                {
                    field: 'email',
                    width: 200,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Email</label>'
                },
                {
                    field: 'recordCreated',
                    template: "#= kendo.toString(kendo.parseDate(recordCreated, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
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
                                'name': { type: 'string' },
                                'pinCode': { type: 'string' },
                                'pinCreated': { type: 'date' },
                                'postCode': { type: 'string' },
                                'sysAdmin': { type: 'string' },
                                'tel': { type: 'string' },
                                'email': { type: 'string' },
                                'recordCreated': { type: 'date' }
                            }
                        }
                    },
                    sort: { field: 'recordCreated', dir: 'asc' }
                },
                columns: [{
                    title: 'Company Name',
                    field: 'name',
                    width: 150,
                    headerTemplate: '<label class="underline">Company Name</label>'
                },
                {
                    title: 'PIN Number',
                    field: 'pinCode',
                    width: 100,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">PIN Number</label>'
                },
                {
                    title: 'PIN Created',
                    field: 'pinCreated',
                    template: "#= (pinCreated== null) ? ' ' : kendo.toString(kendo.parseDate(pinCreated, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                    width: 100,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">PIN Created</label>'
                },
                {
                    title: 'Post Code',
                    field: 'postCode',
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
                    field: 'tel',
                    width: 130,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Telephone No</label>'
                },
                {
                    title: 'Email',
                    field: 'email',
                    width: 200,
                    sortable: false,
                    headerTemplate: '<label class="noUnderline">Email</label>'
                },
                {
                    title: 'Record Created',
                    field: 'recordCreated',
                    template: "#= kendo.toString(kendo.parseDate(recordCreated, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                    headerTemplate: '<label class="underline">Record Created</label>',
                    width: 150
                }]
            }
        };
    }

    AllCompaniesVM.prototype.initialize = function (data) {
        var self = this;
        self.companyAddedTickDate = data.companyAddedTickDate;
        self.verifiedCompany(new CompanyVM());
        self.unverifiedCompany(new CompanyVM());
    }

    AllCompaniesVM.prototype.addCompany = function ($data) {
        var self = this;

    };

    return AllCompaniesVM;
});