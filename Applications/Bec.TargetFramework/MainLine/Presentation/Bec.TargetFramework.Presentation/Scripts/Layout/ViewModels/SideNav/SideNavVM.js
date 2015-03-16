define([], function () {
    "use strict";

    var SideNavVM = function (data, root) {
        data = data || {};
        var self = this;
        self.root = root;

        self.name = ko.observable();
        self.clientsCaption = ko.observable();
        self.ordersCaption = ko.observable();
        self.projectsCaption = ko.observable();
        self.testDynamicCaption = ko.observable();
        self.testLoadingView = ko.observable();
        

        self.initialize(data);
    }

    SideNavVM.prototype.initialize = function (data) {
        var self = this;

        self.name(data.name);
        if (data.captions) {
            self.clientsCaption(data.captions.clients);
            self.ordersCaption(data.captions.orders);
            self.projectsCaption(data.captions.projects);
            self.testDynamicCaption(data.captions.testDynamic);
            self.testLoadingView(data.captions.testLoadingView);
        }
    }

    SideNavVM.prototype.isValid = function () {
        var self = this;

        if (self.name()) {
            return true;
        }
        else {
            return false;
        }
    }

    return SideNavVM;
})