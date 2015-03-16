
function addRow(modelName) {
    var grid = Ext.getCmp(gridId);
    grid.editingPlugin.cancelEdit();

    // create model
    var p = Ext.create(modelName);

    grid.store.insert(0, p);
    grid.editingPlugin.startEdit(0, 0);

};

var beforeEdit = function () {
};

var completeEdit = function () {
}

var cancelEdit = function (editor, e, eOpts) {

    var grid = e.grid;
    var sm = grid.getSelectionModel();
    grid.editingPlugin.cancelEdit();

    // remove phantom row when cancelling
    grid.getStore().each(function (record, index) {
        if (record.phantom) {
            grid.getStore().remove(record);
            return false;
        }
    });
};

function removeGridRow(grid,index) {
    grid.editingPlugin.cancelEdit();
    grid.store.remove(grid.store.getAt(index));

    if (grid.store.getCount() > 0) {
        sm.select(0);
    }
}

function createNewModelFromEditor(e) {
    var newModel = e.record.copy();
    newModel.set(e.newValues);

    return newModel;
}

