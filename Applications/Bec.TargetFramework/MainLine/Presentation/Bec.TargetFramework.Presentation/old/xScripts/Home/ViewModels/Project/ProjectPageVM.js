define([], function () {
    "use strict";

    var ProjectPageVM = function (data) {
        data = data || {};
        var self = this;

        self.name = ko.observable();

        self.initialize(data);
        self.attachEvents();
    }

    ProjectPageVM.prototype.initialize = function (data) {
        var self = this;
        self.name(data.name);
    }

    ProjectPageVM.prototype.isValid = function () {
        var self = this;
        if (self.name()) {
            return true;
        }
        else {
            return false;
        }
    }

    ProjectPageVM.prototype.attachEvents = function () {
        $(".menu-toggle-partial").on('click', function (e) {
            e.preventDefault();
            $("#wrapper").toggleClass("toggled");
        });
    };

    return ProjectPageVM;
})