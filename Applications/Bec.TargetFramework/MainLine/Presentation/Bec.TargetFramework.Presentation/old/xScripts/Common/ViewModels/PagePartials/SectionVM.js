define(['PagePartials/RowVM'], function (RowVM) {
    "use strict";
    var SectionVM = function (data, root) {
        data = data || {};
        var self = this;
        self.root = root;

        self.rows = ko.observableArray();
        self.name = ko.observable();
        self.initialize(data);
    };

    SectionVM.prototype = {
        initialize: function (data) {
            var self = this;
            self.name(data.name);
            self.rows(ko.utils.arrayMap(data.rows, function (rowData) {
                return new RowVM(rowData, self.root);
            }));
        },
        toJSON: function () {
            var copy = this;

            delete copy.root;
            return copy;
        }
    };

    return SectionVM;
});