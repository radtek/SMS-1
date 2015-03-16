var searchFieldTriggerClick = function (field, trigger, index) {

    var me = field,
    store = me.up("grid").getStore(),
    value = me.getValue();

    if (index == 0) {
        me.setValue('');
        store.clearFilter();
        trigger.hide();
    }
    else {
        if (value.length > 0) {
            // Param name is ignored here since we use custom encoding in the proxy.
            // id is used by the Store to replace any previous filter
            store.filter({
                id: store.proxy.filterParam,
                property: store.proxy.filterParam,
                value: value
            });
            me.getTrigger(0).show();
        }
    }
};

var PrepareEditDeleteToolbar = function (grid, command, record, row) {
    if (command.items.items[0].command.toLowerCase() == "delete") {
        if (row.data.IsDisabled == true) {
            command.items.getAt(0).disable();
        }
    }

        if (row.data.IsDeleted == true) {
            command.items.getAt(0).hide();
        }
        else {
            command.items.getAt(0).show();
        }
    
};


var PrepareDeleteTooltip = function (grid, command, record, row) {
    debugger;
    if (command.items.items[0].command.toLowerCase() == "delete") {
        if (row.data.IsDisabled == true) {
            command.items.getAt(0).disable();
        }
    }
    else {

        if (row.data.IsDeleted == true) {
            command.items.getAt(0).hide();
        }
        else {
            command.items.getAt(0).show();
        }
    }
};

var PrepareActiveInactiveToolbar = function (grid, toolbar, rowIndex, record) {
    if (record.data.IsActive == true) {
        toolbar.items.getAt(0).show();
        toolbar.items.getAt(1).hide();
    }
    else {
        toolbar.items.getAt(1).show();
        toolbar.items.getAt(0).hide();
    }
};

var onSpecialKey = function (field, e) {
    if (e.getKey() === e.ENTER) {
        searchFieldTriggerClick(field, null, 1);
        e.stopEvent();
    }
};