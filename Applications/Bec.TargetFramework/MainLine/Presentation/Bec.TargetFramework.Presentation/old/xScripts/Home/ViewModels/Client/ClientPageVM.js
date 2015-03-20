define(['HomeVM/Client/ClientVM'], function (ClientVM) {
    "use strict";

    var ClientPageVM = function (data) {
        data = data || {};
        var self = this;

        self.clientEditMode = ko.observable();
        self.clients = ko.observableArray();

        self.initialize(data);
        self.attachEvents();
    }

    ClientPageVM.prototype.initialize = function (data) {
        var self = this;
        self.clientEditMode(new ClientVM({}, self));
    };

    ClientPageVM.prototype.addClient = function (data) {
        var self = this;
        //check if not empty
        if (self.clientEditMode().firstName() &&
            self.clientEditMode().lastName()) {

            var newClientData = {
                firstName: self.clientEditMode().firstName(),
                lastName: self.clientEditMode().lastName()
            };

            var newClient = new ClientVM(newClientData, self);

            self.clients.push(newClient);

            self.clientEditMode().firstName('');
            self.clientEditMode().lastName('');
        }
    };

    ClientPageVM.prototype.clearEditClient = function ($data) {
        var self = this;

        self.clientEditMode().firstName('');
        self.clientEditMode().lastName('');
    };

    ClientPageVM.prototype.isValid = function () {

        if (self.clients().length > 0) {
            return true;
        }
        else {
            return false;
        }
    };

    ClientPageVM.prototype.attachEvents = function () {
        $(".menu-toggle-partial").on('click', function (e) {
            e.preventDefault();
            $("#wrapper").toggleClass("toggled");
        });
    };

    return ClientPageVM;
})