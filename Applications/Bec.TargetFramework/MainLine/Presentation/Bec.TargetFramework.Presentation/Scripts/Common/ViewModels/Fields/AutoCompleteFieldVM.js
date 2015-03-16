define([], function () {
    "use strict";
    var AutoCompleteFieldVM = function (data, root) {
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

        //actually the selected value which might not be from choices
        self.value = ko.observable();
        self.choices = ko.observableArray();

        //const
        self.type = "AutoCompleteField";

        self.initialize(data);

        //any html element options passed to the element using ko and data-bind
        self.kendoAutocompleteOptions = {
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

    AutoCompleteFieldVM.prototype = {
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

            self.choices(ko.utils.arrayMap(data.choices, function (proposal) {
                return proposal;
            }));

            self.validationRules(ko.utils.arrayMap(data.validationRules, function (validationRule) {
                return validationRule;
            }));

            //check if we have validation rules to apply on the field
            if (self.validationRules().length > 0) {

                //if we have validation rules this means that the field is validatable
                self.isValidatable(true);

                //setting the validaton messages text to correspond to the current field name
                //adding field name to template error messages
                for (var i = 0; i < self.validationRules().length; i++) {
                    var currValidatonRule = self.validationRules()[i];
                  
                    //if required rule exists than the field is required
                    if (currValidatonRule.errorRuleName.toLowerCase() == "required") {
                        self.isRequired(true);
                    }
                }

                //add validation
                if (self.isValidatable()) {

                    if (self.validationRules().length > 0) {
                        ko.utils.addCustomValidator(self.value, self.validationRules())
                    }
                }
            }
            else {
                self.isValidatable(false);
                self.isRequired(false);
            }

            //update Error Message each time validation fires event
            if (self.value.isValid) {
                self.value.isValid.subscribe(function (newValue) {
                    var errorMsgs = ko.validation.group([self.value]);
                    if (errorMsgs && errorMsgs() && errorMsgs().length > 0) {
                        var errMsg = '';

                        for (var i = 0; i < errorMsgs().length; i++) {
                            errMsg += ko.utils.stringFormat(errorMsgs()[i] + ' ', self.title());
                        }
                        self.errorMsg(errMsg);
                    }
                })
            }
        },

        toJSON: function () {
            var copy = this;

            delete copy.root;
            return copy;
        }
    };

    return AutoCompleteFieldVM;
});