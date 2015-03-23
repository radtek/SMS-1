define(['PagePartials/ColumnVM'], function (ColumnVM) {
    "use strict";
    var RowVM = function (data, root) {
        data = data || {};
        var self = this;
        self.root = root;

        self.columns = ko.observableArray();

        self.initialize(data, root);
    };

    RowVM.prototype = {
        initialize: function (data, root) {
            var self = this;

            self.columns(ko.utils.arrayMap(data.columns, function (colData) {
                return new ColumnVM(colData, self.root);
            }));
        },
        toJSON: function () {
            var copy = this;

            delete copy.root;
            return copy;
        }
    };

    return RowVM;
});