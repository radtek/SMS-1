define(["Layout/TopNav/TopNavVM", "Layout/SideNav/SideNavVM"], function (TopNavVM, SideNavVM) {
    "use strict";

    var LayoutVM = function (data) {
        data = data || {};
        var self = this;

        self.name = ko.observable();
        self.topNav = ko.observable();
        self.sideNav = ko.observable();

        self.initialize(data, self);

        self.attachEvents();
    }

    LayoutVM.prototype.initialize = function (data, root) {
        var self = this;
        self.name(data.name);

        self.topNav(new TopNavVM(data.topNavModel, root));
        self.sideNav(new SideNavVM(data.sideNavModel, root));
    }

    LayoutVM.prototype.isValid = function () {

        if (self.name()) {
            return true;
        }
        else {
            return false;
        }
    }

    LayoutVM.prototype.attachEvents = function () {
        $(".menu-toggle").on('click', function (e) {
            e.preventDefault();
            $("#wrapper").toggleClass("toggled");
        });

        $(".side-nav-btn").click(function (e) {
            e.preventDefault();
            var url = $(this).attr("href");
            $("#main-page-wrapper").load(url);
        });
    };

    return LayoutVM;
})