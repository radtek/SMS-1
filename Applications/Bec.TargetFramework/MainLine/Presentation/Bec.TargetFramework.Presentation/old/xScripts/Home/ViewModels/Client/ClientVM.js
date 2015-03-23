define([], function () {
    "use strict";

    var ClientVM = function (data, root) {
        data = data || {};
        var self = this;
        self.root = root;

        self.firstName = ko.observable();
        self.lastName = ko.observable();

        self.fullName = ko.computed(function () {
            if (self.firstName() || self.lastName()) {
                return self.firstName() + ' ' + self.lastName();
            }
            else {
                return '';
            }
        });

        self.initialize(data);
    }

    ClientVM.prototype.initialize = function (data) {
        var self = this;
        self.firstName(data.firstName || '');
        self.lastName(data.lastName || '');
    }

    ClientVM.prototype.removeClient = function (client) {
        var self = this;
        self.root.clients.remove(client);
    };

    ClientVM.prototype.isValid = function () {

        if (self.fullName()) {
            return true;
        }
        else {
            return false;
        }
    }

    return ClientVM;
})