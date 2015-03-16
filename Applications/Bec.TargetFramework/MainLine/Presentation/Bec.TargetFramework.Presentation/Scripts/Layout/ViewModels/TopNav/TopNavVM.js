define([], function () {
    "use strict";

    var TopNavVM = function (data, root) {
        data = data || {};
        var self = this;
        self.root = root;

        self.name = ko.observable();

        self.initialize(data);
    }

    TopNavVM.prototype.initialize = function (data) {
        var self = this;

        self.name(data.name);
    }

    TopNavVM.prototype.isValid = function () {
        var self = this;

        if (self.name()) {
            return true;
        }
        else {
            return false;
        }
    }

    return TopNavVM;
})