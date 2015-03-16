Ext.define(null, {
    override: 'Ext.data.Store', constructor: function () {
        this.callParent(arguments);
        if (this.autoLoad) {
            this.loading = true;
        }
    }
});

var SearchForObject = function(results, searchField, searchValue) {
    var value = null;

    for (var i = 0; i < results.length; i++) {
        if (results[i][searchField] == searchValue) {
            value = results[i];
        }
    }

    return value;
};

var FieldSetter = function(form, fieldName, value) {
    form.findField(fieldName).setValue(value);
};


var ComboSetter = function (comboBox, value) {
    var store = comboBox.store;
    var valueField = comboBox.valueField;
    var displayField = comboBox.displayField;

    var recordNumber = store.findExact(valueField, value, 0);

    if (recordNumber == -1)
        return -1;

    var displayValue = store.getAt(recordNumber).data[displayField];
    comboBox.setValue(value);
    comboBox.setRawValue(displayValue);
    comboBox.selectedIndex = recordNumber;
    return recordNumber;
};

