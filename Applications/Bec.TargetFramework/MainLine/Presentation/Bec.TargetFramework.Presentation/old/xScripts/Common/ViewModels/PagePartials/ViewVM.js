define(['PagePartials/SectionVM'], function (SectionVM) {
    "use strict";
    var ViewVM = function (data) {
        data = data || {};
        var self = this;

        //const
        self.ukey;
        
        self.metaData = data;
        self.name = ko.observable();
        self.sections = ko.observableArray();
        self.isCustom = ko.observable();
        self.initialize(data, self);

        //validatable fields added here
        self.validatableFields = ko.observableArray();
    };

    ViewVM.prototype = {
        initialize: function (data, root) {
            var self = this;

            self.ukey = data.ukey;
            self.isCustom = ko.observable(data.isCustom);
            self.name(data.name);

            self.sections(ko.utils.arrayMap(data.sections, function (sectionData) {
                return new SectionVM(sectionData, root);
            }));
        },

        toJSON: function () {
            var copy = this;

            return copy;
        },

        isValid: function () {
            var errors = ko.validation.group(self.validatableFields());

            if (errors.length > 0) {
                errors.ShowAllMessages();
                return false;
            }
            else {
                return true;
            }
        }
    };

    return ViewVM;
});