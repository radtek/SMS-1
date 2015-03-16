

//http://stackoverflow.com/questions/20728551/knockout-validation-addclass-to-parent-of-validation-element
ko.bindingHandlers.parentValidationElement = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var cssClass = ko.utils.unwrapObservable(valueAccessor);
        var obs = ko.utils.unwrapObservable(allBindingsAccessor()).value;

        var decorateElement = obs && obs.isModified && obs.isValid && obs.isModified() && !obs.isValid();
        if (decorateElement) {
            $(element).parent().addClass(cssClass);
        } else {
            $(element).parent().removeClass(cssClass);
        }
    }
}

// use this others are legacy
ko.utils.isEmptyString = function (value) {
    var val;
    if (ko.utils.isFunction(value)) {
        val = ko.unwrap(value);
    }
    else {
        val = value;
    }
    if (ko.utils.isEmptyObject(val) || val === "" || val === '') {
        return true;
    } else {
        return false;
    }
};

ko.utils.isString = function (str) {
    if (typeof str == 'string' || str instanceof String) {
        return true;
    } else {
        return false;
    }
}

ko.utils.isNumber = function (value) {
    var val;
    if (ko.utils.isFunction(value)) {
        val = ko.unwrap(value);
    }
    else {
        val = value;
    }

    if (ko.utils.isEmptyString(val) || isNaN(val)) {
        return false;
    } return true;
};


ko.utils.isEmptyObject = function (value) {
    var val;
    if (ko.utils.isFunction(value)) {
        val = ko.unwrap(value);
    }
    else {
        val = value;
    }

    if (val === null || val === undefined) {
        return true;
    } else {
        return false;
    }
};

ko.utils.isFunction = function (functionToCheck) {
    var getType = {};
    return functionToCheck && getType.toString.call(functionToCheck) === '[object Function]';
}

//ko.utils.isFunction = function (value) {
//    if (typeof (value) == "function") {
//        return true;
//    }
//    else {
//        return false;
//    }
//}

// Just like in C#, example: stringFormat('{0} is dead, but {1} is alive! {0} {2}', 'ASP', 'ASP.NET')
ko.utils.stringFormat = function (format) {
    var args = Array.prototype.slice.call(arguments, 1);
    return format.replace(/{(\d+)}/g, function (match, number) {
        return typeof args[number] != 'undefined' ? args[number] : match;
    });
};

ko.utils.parseNumber = function (value) {
    return ko.utils.isNumber(ko.unwrap(value)) ? ko.unwrap(value) : 0;
};

ko.utils.parseNullableNumber = function (value) {
    var number = ko.unwrap(value);
    return number == 0 ? null : number;
};


//Guids
ko.utils.generateGuid = function () {
    var guid = (function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
                       .toString(16)
                       .substring(1);
        }
        return function () {
            return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
                   s4() + '-' + s4() + s4() + s4();
        };
    })();
    return guid();
}

ko.utils.isEmptyGuid = function (value) {
    var val = ko.unwrap(value);
    if (val === null || val === ko.constants.GUID_EMPTY || val === undefined || val === "" || val === '') {
        return true;
    } else {
        return false;
    }
}

ko.utils.isValidUkey = function (ukey) {
    var result = true;
    if (ukey) {
        var pattern = "^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$";

        var modifiers = 'im';

        var patt = new RegExp(pattern, modifiers);

        var isValid = patt.test(ukey);

        if (!isValid) {
            result = false;
        }
    }
    else {
        result = false;
    }

    return result;
}

//=================== Strings

ko.utils.showDotsIfEmpty = function (value) {
    var val = ko.unwrap(value);
    return ko.utils.isEmptyString(val) ? "..." : val;
};

ko.utils.keepNCharacters = function (value, characters) {
    var val = ko.unwrap(value);
    if (ko.utils.isEmptyString(val)) {
        return "...";
    } else {
        var txt = val.slice(0, characters) + (val.length > characters ? '...' : '');
        return txt;
    }
};



//===================DATES===================
ko.utils.isValidDate = function (str) {
    var rm = str.split('/');

    if (rm.length < 2) {
        rm = str.split(' ');
    }

    if (rm.length < 2) {
        rm = str.split('-');
    }

    if (rm.length > 1) {
        var m = 1 * rm[0],
        d = 1 * rm[1],
        y = 1 * rm[2]
        ;
        if (isNaN(m * d * y)) { return false; }
        if (d < 1) { return false; } // day can't be 0
        if (m < 1 || m > 12) { return false; } // month must be 1-12
        if (m === 2) { // february
            var is_leap_year = ((y % 4 === 0) && (y % 100 !== 0)) || (y % 400 === 0);
            if (is_leap_year && d > 29) { return false; } // leap year
            if (!is_leap_year && d > 28) { return false; } // non-leap year
        }
            // test any other month
        else if (((m === 4 || m === 6 || m === 9 || m === 11) && d > 30) ||
            ((m === 1 || m === 3 || m === 5 || m === 7 || m === 8 || m === 10 || m === 12) && d > 31)) {
            return false;
        }
    }
    else {
        return false;
    }

    return true;
}

// Legacy
ko.utils.parseKendoDate = function (d) {
    var date = ko.unwrap(d);
    if (ko.utils.dateIsValid(date)) {
        return new Date(date);
    } else {
        return null;
    }
}

//===================/DATES===================

//=================== ARRAYS===================
ko.utils.isEmptyRepeater = function (value) {
    var val = ko.unwrap(value);
    var itemsCount = 0;
    for (var i = 0; i < val.length; i++) {
        var state = val[i].rowState();
        if (state !== ko.constants.rowStates.DELETED && state !== ko.constants.rowStates.TEMPORARY)
            itemsCount++;
    }

    return itemsCount == 0;
}

ko.utils.isEmptyArray = function (value) {
    var val = ko.unwrap(value);
    if (val === null || val === undefined) {
        return true;
    } else {
        if (val.length === 0) {
            return true;
        } else {
            return false;
        }
    }
};

ko.utils.getIndexOf = function (arr, needle) {
    if (typeof Array.prototype.indexOf === 'function') {
        indexOf = Array.prototype.indexOf;
    } else {
        indexOf = function (needle) {
            var i = -1, index = -1;

            for (i = 0; i < arr.length; i++) {
                if (arr[i] === needle) {
                    index = i;
                    break;
                }
            }
            return index;
        };
    }
    return indexOf.call(arr, needle);
};

//===================/ARRAYS===================

//=================== Others===================

ko.utils.parseBoolean = function (str) {
    switch (str.toLowerCase()) {
        case "true": case "yes": case "1": return true;
        case "false": case "no": case "0": case null: return false;
        default: return Boolean(str);
    }
};

ko.utils.getOptionsByFieldName = function (array, fieldName) {
    if (typeof (ko.unwrap(fieldName)) !== 'string') {
        throw new Error("field name must be string")
    }

    if (!Array.isArray(array)) {
        throw new Error("the Array argument must be instance of array")
    }

    var options = ko.utils.arrayFilter(array, function (i) {
        return i.key === fieldName;
    })

    return options[0].value
}

ko.utils.getMessageByKeyFromArr = function (array, key) {
    if (typeof (ko.unwrap(key)) !== 'string') {
        throw new Error("Key must be string")
    }

    if (!Array.isArray(array)) {
        throw new Error("the Array argument must be instance of array")
    }

    var messages = ko.utils.arrayFilter(array, function (i) {
        return i.key === key;
    })

    if (messages.length > 0) {
        return messages[0].value
    } else {
        return "";
    }
}

ko.utils.getMessageByKeyFromObj = function (obj, key) {

    if ((typeof obj === "object") && (obj !== null)) {
        if (typeof (ko.unwrap(key)) !== 'string') {
            throw new Error("Key must be string")
        }

        var message = obj[key];

        if (message != null && message.length > 0) {
            return message;
        } else {
            throw new Error(ko.utils.stringFormat("There is no such key as {0} in the error messages", key));
        }
    }
    else {
        throw new Error("ko.utils.getMessageByKeyFromArr argument must be a instance of object!");
    }
}
//===================/Others===================



//================Buttons===============
ko.utils.markButtonAsWaitingForResponse = function (btnElement) {
    $(btnElement).html('<span class="glyphicon glyphicon-refresh fa-spin"></span>')
    $(btnElement).attr("disabled", true);
}

ko.utils.unmarkButtonAsWaitingForResponse = function (btnElement, btnInitialHtml) {
    $(btnElement).html(btnInitialHtml)
    $(btnElement).removeAttr("disabled");
}

ko.utils.highlight = function (element, duration) {
    var $element = $(element);
    duration = duration || 1000;

    $element.addClass('highlighted');

    setTimeout(function () {
        $element.removeClass('highlighted');
    }, duration);
};
//===========/Buttons====================

//===============KendoGrid===================

ko.utils.addIconsOfKendoGridActions = function (containerElement) {
    var container = $(containerElement);

    var editSpans = container.find(".k-grid-edit").children("span")
        .addClass("glyphicon")
        .addClass("glyphicon-pencil")
        .removeClass("k-icon")
        .removeClass("k-edit");

    var deleteSpans = container.find(".k-grid-delete").children("span")
        .addClass("glyphicon")
        .addClass("glyphicon-trash");

    var deletePopUpSpans = container.find(".k-grid-deletePopUp").children("span")
        .addClass("glyphicon")
        .addClass("glyphicon-trash");

    var detailsSpans = container.find(".k-grid-details").children("span")
        .addClass("glyphicon")
        .addClass("glyphicon-eye-open");

    var createSpans = container.find(".k-grid-create").children("span")
        .addClass("glyphicon")
        .addClass("glyphicon-plus");

    var assignSpans = container.find(".k-grid-assign").children("span")
          .addClass("glyphicon")
          .addClass("glyphicon-plus");

    var addSpans = container.find(".k-grid-add").children("span")
        .removeClass("k-icon")
        .removeClass("k-add")
        .addClass("glyphicon")
        .addClass("glyphicon-plus");
};

ko.utils.getKendoColumnTextByUkey = function (gridId, data, columnField) {
    var grid = $('#' + gridId).data('kendoGrid');

    for (var i = 0; i < grid.options.columns.length; i++) {
        var column = grid.options.columns[i];

        if (column.field === columnField) {
            for (var j = 0; j < column.values.length; j++) {
                var value = column.values[j];
                if (data[columnField] === value.value) {
                    return value.text;
                }
            }

            break;
        }
    }

    return data[columnField];
};

ko.utils.collapse = function (element, targetId) {
    var classUp = 'glyphicon-chevron-up';
    var classDown = 'glyphicon-chevron-down';

    var btn = $(element);
    var btnSpan = $(btn.children()[0]);
    var target = $(document.getElementById(targetId));

    var shouldCollapse = target.css("display") == "none" ? false : true;
    if (shouldCollapse) {
        target.hide();
        btnSpan.removeClass(classDown).addClass(classUp);
    } else {
        target.show();
        btnSpan.removeClass(classUp).addClass(classDown);
    }
}

ko.bindingHandlers.upDownBtn = {
    classUp: 'glyphicon-chevron-up',
    classDown: 'glyphicon-chevron-down',
    update: function (element, valueAccessor) {
        var btnSpan = $(element).find("span.glyphicon");
        var isUp = ko.unwrap(valueAccessor());
        if (isUp) {
            btnSpan.removeClass(ko.bindingHandlers.upDownBtn.classDown);
            btnSpan.addClass(ko.bindingHandlers.upDownBtn.classUp);
        } else {
            btnSpan.removeClass(ko.bindingHandlers.upDownBtn.classUp);
            btnSpan.addClass(ko.bindingHandlers.upDownBtn.classDown);
        }
    }
}

// instead of attr: { href: '' }
ko.bindingHandlers.href = {
    update: function (element, valueAccessor) {
        ko.bindingHandlers.attr.update(element, function () {
            return { href: valueAccessor() }
        });
    }
}

// instead of attr: { src: '' }
ko.bindingHandlers.src = {
    update: function (element, valueAccessor) {
        ko.bindingHandlers.attr.update(element, function () {
            return { src: valueAccessor() }
        });
    }
}

// instead of !visible()
ko.bindingHandlers.hidden = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        ko.bindingHandlers.visible.update(element, function () { return !value; });
    }
}

//<pre data-bind="toJSON: $root"></pre>
ko.bindingHandlers.toJSON = {
    update: function (element, valueAccessor) {
        return ko.bindingHandlers.text.update(element, function () {
            return ko.toJSON(valueAccessor(), null, 2);
        });
    }
}

ko.utils.cleanHtmlTags = function (str) {
    if (str) {
        return str.replace(/<[^>]*>/g, "");
    } else {
        return "";
    }
};

ko.utils.isValidImageType = function (imageType) {
    var imageTypes = ["image/gif", "image/jpeg", "image/pjpeg", "image/png", "image/svg+xml", "image/vnd.djvu", "image/example"];

    if (!imageType) {
        return false;
    }

    imageType = imageType.toLowerCase();

    for (var i = 0; i < imageTypes.length; i++) {
        if (imageType === imageTypes[i]) {
            return true;
        }
    }

    return false;
};

ko.utils.formatDate = function (date) {

    if (date) {
        var m_names = new Array("Jan", "Feb", "Mar",
        "Apr", "May", "Jun", "Jul", "Aug", "Sep",
        "Oct", "Nov", "Dec");

        var curr_date = ko.utils.padZeroes(date.getDate(), 2);
        var curr_month = ko.utils.padZeroes(date.getMonth() + 1, 2);
        var curr_year = date.getFullYear();
        var result = (curr_date + "/" + curr_month
        + "/" + curr_year);

        return result;
    }
    
    return '';
}


//padZeroes("3", 3);    // => "003"
//padZeroes("123", 3);  // => "123"
//padZeroes("1234", 3); // => "1234"
ko.utils.padZeroes = function (str, max) {
    str = str.toString();
    return str.length < max ? ko.utils.padZeroes("0" + str, max) : str;
}

ko.utils.parseCSharpTicks = function (ticksStr) {
    if (ticksStr) {
        var ticksInt = parseInt(ticksStr, 10);
        return Math.floor((ticksInt - 621355968000000000) / 10000);
    }
    return 0;
}

//for input scuh as search http://stackoverflow.com/questions/23087721/call-function-on-enter-key-press-knockout-js
ko.bindingHandlers.enterkey = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var allBindings = allBindingsAccessor();
        $(element).keypress(function (event) {
            var keyCode = (event.which ? event.which : event.keyCode);
            if (keyCode === 13) {
                allBindings.enterkey.call(viewModel);
                return false;
            }
            return true;
        });
    }
};



ko.bindingHandlers.visibility = (function () {
    function setVisibility(element, valueAccessor) {
        var visible = '';
        //if (ko.utils.isFunction(valueAccessor())) {
        //    visible = ko.unwrap(valueAccessor());
        //}
        //else {
        visible = valueAccessor();
        //}

        $(element).css('visibility', visible ? 'visible' : 'hidden');
    }
    return { init: setVisibility, update: setVisibility };
})();


//===============/KendoGrid===================

ko.constants = ko.constants || {};

ko.constants.GUID_EMPTY = "00000000-0000-0000-0000-000000000000";