define(["Fields/TextFieldVM",
        "Fields/AutoCompleteFieldVM"],
    function (TextFieldVM,
              AutoCompleteFieldVM) {

        var FieldFactory = {
            getViewModel: function (data, root) {
                if (data == null) {
                    throw new Error("Missing argument");
                } else {
                    var fieldType = data.type;
                    var viewModelresult;
                    switch (fieldType) {
                        case "TextField":
                            viewModelresult = new TextFieldVM(data, root); break;
                        case "AutoCompleteFieldVM":
                            viewModelresult = new AutoCompleteFieldVM(data, root); break;
                        default:
                            throw new Error("Such type: " + data.type + " does not exist");
                    }

                    return viewModelresult;
                }
            }
        };

        return FieldFactory;
    });