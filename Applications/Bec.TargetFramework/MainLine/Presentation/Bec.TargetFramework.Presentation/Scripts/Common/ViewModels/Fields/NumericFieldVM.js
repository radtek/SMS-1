/// <reference path="../../../Vendor/Knockout/knockout-3.1.0.js" />
define([], function () {
    "use strict";
    var NumericFieldVM = function (data, root) {
        data = data || {};
        var self = this;
        self.root = root;

        self.isCustom = ko.observable();
        self.title = ko.observable();
        self.name = ko.observable();
        self.isRequired = ko.observable();
        self.isValidatable = ko.observable();
        self.errorMsg = ko.observable();
        self.isReadOnly = ko.observable();
        self.validationRules = ko.observableArray();

        self.value = ko.observable();
        self.step = ko.observable();
        self.min = ko.observable();
        self.max = ko.observable();
        self.format = ko.observable();

        //const
        self.type = "NumericField";

        self.initialize(data);

        //any html element options passed to the element using ko and data-bind
        self.kendoNumericOptions = {
            dataTextField: 'name',
            data: self.choices,
            value: self.value,
            enabled: self.isReadonly
        };

        self.attrOptions = {
            title: self.title,
            name: self.name,
            id: self.root.name() + '_' + self.name() + '_' + self.title(),
            enabled: self.isReadonly
        };

        self.labelAttrOptions = {
            title: self.title,
            "for": self.root.name() + '_' + self.name() + '_' + self.title(),
            id: self.root.name() + '_' + self.name() + '_' + self.title() + ' ' + ' label'
        };
    };

    NumericFieldVM.prototype = {
        initialize: function (data) {
            var self = this;

            self.isCustom(data.isCustom);
            self.value(data.value);
            self.title(data.title);
            self.name(data.name);
            self.isRequired(data.isRequired);
            self.isReadOnly(data.isReadOnly);
            self.isValidatable(data.isValidatable);
            self.errorMsg(data.errorMsg);

            self.step = ko.observable(data.step || 1);
            self.min = ko.observable(data.min || 0);
            self.max = ko.observable(data.max || 100);
            self.format(data.format || 'n');
            
            if (self.isRequired()) {
                self.value.extend({
                    required: {
                        message: self.errorMsg
                    }
                });
            }
        },
        toJSON: function () {
            var copy = this;

            delete copy.root;
            delete copy.caption;
            delete copy.toolTip;
            return copy;
        }
    }

    return NumericFieldVM;
});