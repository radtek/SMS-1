define([], function () {
    "use strict";

    var OrderPageVM = function (data) {
        data = data || {};
        var self = this;

        self.name = ko.observable();

        self.initialize(data);
        self.attachEvents();
    }

    OrderPageVM.prototype.initialize = function (data) {
        var self = this;
        self.name(data.name);
    }

    OrderPageVM.prototype.isValid = function () {
        var self = this;
        if (self.name()) {
            return true;
        }
        else {
            return false;
        }
    }

    OrderPageVM.prototype.attachEvents = function () {
        $(".menu-toggle-partial").on('click', function (e) {
            e.preventDefault();
            $("#wrapper").toggleClass("toggled");
        });
    };

    return OrderPageVM;
})