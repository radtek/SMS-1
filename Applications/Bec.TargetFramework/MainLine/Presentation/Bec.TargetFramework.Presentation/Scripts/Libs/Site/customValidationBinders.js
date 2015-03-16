//--------------Custom Validation Rules ------------>

//===================REGEX===================

ko.utils.regexValidation = function (val, pattern) {
    var result = true;
    val === null || val === undefined ? val = '' : true;

    if (typeof val !== 'string' && val !== undefined && pattern) {
        val = val.toString();
    }

    if (val !== undefined && val !== null) {
        var modifiers = 'im';

        var patt = new RegExp(pattern, modifiers);

        var isValid = patt.test(val);

        return isValid;
    }
    else {
        result = false;
    }

    val === '' ? val = null : true;

    return result;
}

ko.utils.addCustomValidator = function (observable, validationRules) {
    if (validationRules) {

        observable.validation = ko.observable();

        var validationRulesBag = [];

        $.each(validationRules, function myfunction(index, validationRule) {
            if (validationRule.errorMessage && validationRule.errorRuleName) {

                var customValidationRule = ko.validation.rules[validationRule.errorRuleName];

                if (customValidationRule) {
                    customValidationRule.message = validationRule.errorMessage;

                    if (customValidationRule.validator) {
                        validationRulesBag.push(customValidationRule);
                    }
                    else {
                        throw new Error(ko.utils.stringFormat('No such validator as {0} !', validationRule.errorRuleName));
                    }
                    
                }
            }
        })

        observable.extend({
            validation: validationRulesBag
        })
    }
};

//===================/REGEX===================

ko.validation.rules['number'] = {
    validator: function (val) {
        return ko.utils.isNumber(ko.unwrap(val));
    }
};

//----------------- Dates
ko.validation.rules['minDate'] = {
    validator: function (val, params) {
        var currentDate = ko.unwrap(val);
        var minDate = ko.unwrap(params.otherVal);
        if (ko.utils.dateIsValid(currentDate) && ko.utils.dateIsValid(minDate)) {
            if (params.equals) {
                return currentDate.getTime() >= minDate.getTime();
            } return currentDate.getTime() > minDate.getTime();
        } return true;
    }
};

ko.validation.rules['maxDate'] = {
    validator: function (val, params) {
        var currentDate = ko.unwrap(val);
        var maxDate = ko.unwrap(params.otherVal);
        if (ko.utils.dateIsValid(currentDate) && ko.utils.dateIsValid(maxDate)) {
            if (params.equals) {
                return currentDate.getTime() <= maxDate.getTime();
            } return currentDate.getTime() < maxDate.getTime();
        } return true;
    }
};

//----------------- Arrays

// Use this if you need to validate array to have atleast 1 item.
ko.validation.rules['notEmptyArray'] = {
    validator: function (array) {
        return array.length > 0;
    }
};

// Use this if you need to validate array used in grid to have atleast 1 item.
ko.validation.rules['notEmptyRepeater'] = {
    validator: function (data) {
        var itemsCount = 0;
        for (var i = 0; i < data.length; i++) {
            var state = data[i].rowState();
            if (state !== ko.constants.rowStates.DELETED && state !== ko.constants.rowStates.TEMPORARY)
                itemsCount++;
        }

        return itemsCount > 0;
    }
};

// Use this if you need to validate array used in grid to have atleast 1 item.
ko.validation.rules['notEmptyGridArray'] = {
    validator: function (data) {
        var itemsCount = 0;
        for (var i = 0; i < data.length; i++) {
            var state = data[i].rowState();
            if (state !== ko.constants.rowStates.DELETED && state !== ko.constants.rowStates.TEMPORARY)
                itemsCount++;
        }

        return itemsCount;
    }
};

//self.Measurements = ko.observableArray().extend({ AtLeastOne: function () {
//    return this && this.HasValues();
//}});
ko.validation.rules['atLeastOne'] = {
    validator: function (array, predicate) {
        var self = this;
        self.predicate = predicate;
        return ko.utils.arrayFirst(array, function (item) {
            return self.predicate.call(item);
        }) != null;
    },
    message: 'The array must contain at least one valid element.'
};

//----------------- Strings

ko.validation.rules['requiredLength'] = {
    validator: function (val, otherVal) {
        var pattern = '^[\\s\\S]{1,}$';
        var validatioResult = ko.utils.regexValidation(val, pattern);
        return validatioResult;
    }
};

ko.validation.rules['alphabetic'] = {
    validator: function (val, otherVal) {
        var pattern = '[A-z]';
        var validatioResult = ko.utils.regexValidation(val, pattern);
        return validatioResult;
    }
};

ko.validation.rules['noNumeric'] = {
    validator: function (val, otherVal) {
        var pattern = '^([^0-9]*)$';
        var validatioResult = ko.utils.regexValidation(val, pattern);
        return validatioResult;
    }
};

ko.validation.rules['numeric'] = {
    validator: function (val, otherVal) {
        var pattern = '^([0-9]*)$';
        var validatioResult = ko.utils.regexValidation(val, pattern);
        return validatioResult;
    }
};

//ex: var c = TryParseInt("abv", null); 
//This will return null 
ko.utils.TryParseInt = function (str, defaultValue) {
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return retValue;
}

ko.validation.rules['isInt32'] = {
    validator: function (val, otherVal) {
        var result = ko.utils.TryParseInt(val, null);

        if (result != null) {
            return true;
        }
        else {
            return false;
        }
    }
}

ko.validation.rules['email'] = {
    validator: function (val, otherVal) {
        if (val == '' || val == null)
            return true;

        var pattern = '^(([^<>()[\\]\\\\.,;:\\s@]+(\\.[^<>()[\\]\\\\.,;:\\s@]+)*)|(.+))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$';
        var validatioResult = ko.utils.regexValidation(val, pattern);
        return validatioResult;
    }
};

ko.validation.rules['phone'] = {
    validator: function (val, otherVal) {
        var pattern = '^[0-9+-/\\(\\)]*$';
        var validatioResult = ko.utils.regexValidation(val, pattern);
        return validatioResult;
    }
};

ko.validation.rules['notEmpty'] = {
    validator: function (val) {
        return !ko.utils.isEmptyString(val)
    }
};

ko.validation.rules['nonEmptyGuid'] = {
    validator: function (val) {
        return !ko.utils.isEmptyGuid(val);
    }
};

ko.validation.rules['guidFormat'] = {
    validator: function (val, otherVal) {

        if (val) {
            var pattern = '^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$';
            var validatioResult = ko.utils.regexValidation(val, pattern);
            return validatioResult;
        }

        return true;
    }
};

ko.validation.rules['maxLength20'] = {
    validator: function (val) {
        var text = val;
        if (text != null)
            return !(text.length > 20);
        else
            return true;
    }
};

ko.validation.rules['maxLength50'] = {
    validator: function (val) {
        var text = ko.unwrap(val);
        if (text != null)
            return !(text.length > 50);
        else
            return true;
    }
};

ko.validation.rules['maxLength200'] = {
    validator: function (val) {
        var text = ko.unwrap(val);
        if (text != null)
            return !(text.length > 200);
        else
            return true;
    }
};

ko.validation.rules['maxLength2000'] = {
    validator: function (val) {
        var text = ko.unwrap(val);
        if (text != null)
            return !(text.length > 2000);
        else
            return true;
    }
};

ko.validation.rules['maxLength'] = {
    validator: function (val, otherVal) {
        var text = ko.unwrap(val);
        if (text != null)
            return !(text.length > otherVal);
        else
            return true;
    }
};

ko.validation.rules['greaterThan'] = {
    validator: function (val, otherVal) {
        var firstVal = ko.unwrap(val);
        return firstVal > otherVal;
    }
};

ko.validation.rules['greaterThanOrEqualsTo'] = {
    validator: function (val, otherVal) {
        var firstVal = ko.unwrap(val);
        return firstVal > otherVal;
    }
};

ko.validation.rules['isNotZero'] = {
    validator: function (val, otherVal) {
        if (val != 0) {
            return true;
        }
        return false;
    }
};

ko.validation.rules['nonEmptyArr'] = {
    validator: function (val) {

        return val.length > 0;
    },
    message: 'The array must contain at least one valid element.'
};

ko.validation.registerExtenders();