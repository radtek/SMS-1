define(['Fields/FieldFactory'], function (FieldFactory) {
    "use strict";
    var ColumnVM = function (data, root) {
        data = data || {};
        var self = this;
        self.root = root;

        self.fields = ko.observableArray();

        //using the twelve column bootstrap system
        //ex. col-md-3
        self.colSpan = ko.observable();

        self.initialize(data);
    };

    ColumnVM.prototype = {
        initialize: function (data) {
            var self = this;

            self.colSpan(data.colSpan);

            self.fields(ko.utils.arrayMap(data.fields, function (fieldData) {

                return FieldFactory.getViewModel(fieldData, self.root);
            }));
        },
        toJSON: function () {
            var copy = this;

            delete copy.root;
            return copy;
        }
    };

    return ColumnVM;
});