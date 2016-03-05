$(function () {
    var btnAddItem = $("#submitAddItem");
    var itemListContainer = $("#helpItemListContainer");
    var orderListContainer = $("#helpOrderListContainer");
    $("#helpItemRoleId").val($("#helpItemRoleId option:first").val());
    function ignore(e) {
        if (e) {
            e.preventDefault();
        }
    }

    // submit from when Save button clicked
    btnAddItem.click(function () {
        $("#addItem-form").submit();
    });

    $("#cancelAddItem").click(function () {
        clearText();
    });

    var validator = $("#addItem-form").validate({
        ignore: '.skip',
        onfocusout: false,
        // Rules for form validation
        rules: {
            Title: {
                required: true
            },
            Selector: {
                required: true
            },
            RoleID: {
                required: true
            },
            Description: {
                required: true
            },
            EffectiveOn: {
                required: true
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    function createItem(item) {
        if (item.Status !== 800005) {
            var itemHtml = '<li class="ui-state-default" data-item-order="' + item.DisplayOrder + '">' +
                            '<span class="ui-icon ui-icon-arrowthick-2-n-s"></span>' +
                            '<span class="help-item-title">' + item.Title + '</span>' +
                            ' <span class="help-item-btn">' +
                             ' <a  id="' + item.HelpPageItemID + '" class="btn btn-primary btn-sm help-item-element-delete"><i class="fa fa-times"></i></a>' +
                             ' <a  id="' + item.HelpPageItemID + '" class="btn btn-primary btn-sm help-item-element"><i class="fa fa-edit"></i></a> ' +
                            '</span>' +
                          ' </li>';
            return itemHtml;
        } else {
            return '';
        }
    }
    function createOrder(order) {
        return '<li style="cursor: default;">' + order + '</li>';
    }
    function getDateFormat(d) {
        if (d !== undefined && d !== null) {
            var date = new Date(parseInt(d.replace("/Date(", "").replace(")/", "")));
            return date;
        }
    }
    function fDate(ds) {
        return $.datepicker.formatDate('dd/mm/yy', new Date(getDateFormat(ds)));
    };
    function setSelected(idOfSelect, values) {
        if (values == null) return;
        $("#" + idOfSelect + " option:selected").removeAttr("selected");
        $.each(values, function (i, e) {
            $("#" + idOfSelect + " option[value='" + e + "']").prop("selected", true);
        });
    }

    $(document).delegate(".help-item-element", "click", function () {
        var itemId = $(this).attr('id');
        $('.help-item-element').prop('disabled', false);
        $(this).prop('disabled', true);
        $('#helpItemEditId').val(itemId);
        ajaxWrapper({
            url: $("#getItem-form").attr('action'),
            data: $("#getItem-form").serializeArray(),
            type: 'POST'
        })
        .done(function (response) {
            if ((response !== null || response !== undefined) && (response.Item !== null)) {
                $('#helpPageItemId').val(itemId);
                btnAddItem.text("Save");
                $('#helpItemTitle').val(response.Item.Title);
                $('#helpItemSelector').val(response.Item.Selector);
                $('#helpItemDescription').val(response.Item.Description);
                $('#helpItemPosition').val(response.Item.Position);
                $('#effectiveDateInput').val(fDate(response.Item.EffectiveOn));
                $('#EffectiveOn').val(fDate(response.Item.EffectiveOn));
                $('#helpItemTabContainerId').val(response.Item.TabContainerId);
                setSelected('helpItemRoleId', response.Item.RoleId);
            }
        });
    });

    $(document).delegate(".help-item-element-delete", "click", function () {
        var itemId = $(this).attr('id');
        $('.help-item-element-delete').prop('disabled', false);
        $(this).prop('disabled', true);
        $('#helpItemDeleteId').val(itemId);
        ajaxWrapper({
            url: $("#deleteItem-form").attr('action'),
            data: $("#deleteItem-form").serializeArray(),
            type: 'POST'
        })
        .done(function (response) {
            if ((response !== null || response !== undefined) && (response.result)) {
                loadItemsForList(response.Items);
                clearText();
            }
        });
    });

    function validateSubmit(form) {
        if (validateAddHelpItem()) {
            btnAddItem.prop('disabled', true);
            ajaxWrapper({
                url: $(form).attr('action'),
                data: $(form).serializeArray(),
                type: 'POST'
            }).done(function (response) {
                if ((response !== null || response !== undefined) && (response.result)) {
                    loadItemsForList(response.Items);
                    clearText();
                }
            });
        } else {
            btnAddItem.prop('disabled', false);
            validator.showErrors({
                "Title": "This title exists. Please use different name"
            });
        }
    }

    function clearText() {
        $("#addItem-form input[type=text]").val('');
        if ($("#HelpPageTypeId").val() === "800001") {
            $("#EffectiveOn").val('');
        }
        $("#addItem-form select").prop('selectedIndex', '0');
        $("#addItem-form textarea").val('');
        btnAddItem.text("Add");
        $("#helpPageItemId").val("");
        $('.help-item-element').prop('disabled', false);
    }

    function updateItemOrder() {
        var items = itemListContainer.children("li");
        var newOrder = [];
        items.each(function () {
            var order = $(this).data("item-order");
            if (order !== null && order !== undefined) {
                newOrder.push(order);
            }
        });
        ajaxWrapper({
            url: itemListContainer.data("update-order-url"),
            data: {
                orders: newOrder,
                __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
            },
            type: 'POST'
        }).done(function (response) {
            if ((response !== null || response !== undefined) && (response.result)) {
                loadItemsForList(response.Items);
            }
        });
    }

    function loadItemsForList(items) {
        itemListContainer.html("");
        orderListContainer.html("");
        var order = 0;
        btnAddItem.prop('disabled', false);
        if (items != null && items.length >= 1) {
            for (var i = 0; i < items.length; i++) {
                var itemContent = createItem(items[i]);
                if (itemContent !== '') {
                    itemListContainer.append(itemContent);
                    order++;
                    orderListContainer.append(createOrder(order));
                }
            }
            $('#messageAlert').hide();
        }
    }

    itemListContainer.sortable({
        axis: 'y',
        containment: '#step2',
        stop: updateItemOrder
    });

    makeDatePicker("#effectiveDateInput", {
        minDate: new Date(), yearRange: "-110:+1"
    }, {
        onSelect: function (date, inst) {
            var birthDateField = $('#EffectiveOn');
            birthDateField.val(inst.input.data("val"));
            birthDateField.valid();
        }
    });

    function validateAddHelpItem() {
        var items = $("#helpItemListContainer li");
        var inputItemTitle = $("#helpItemTitle").val().trim();
        var currentItemId = $("#helpPageItemId").val();
        var result = true;
        if (currentItemId === "") {
            items.each(function () {
                if ($(this).text().trim() === inputItemTitle) {
                    result = false;
                }
            });
        } else {
            items.each(function () {
                var editbtn = $(this).find("a").first();
                if ($(this).text().trim() === inputItemTitle && editbtn.attr("id") !== currentItemId) {
                    result = false;
                }
            });
        }
        return result;
    }
});