$(function () {
    function getItemsOnPage() {
        var items = itemListContainer.children("li");
        var newOrder = [];
        items.each(function () {
            var order = $(this).data("item-order");
            if (order !== null && order !== undefined) {
                newOrder.push(order);
            }
        });
        ajaxWrapper({
            url: '/Admin/Help/GetHelpItems',
            data: {
                pageId: $('#HelpPageID').val()
            },
            type: 'GET'
        }).done(function (response) {
            if (response !== null || response !== undefined) {
                if (!response.IsEmpty) {
                    loadItemsForList(response.Items);
                }
            }
        });
    }
    var btnEditItem = $("#submitEditItem");
    var itemListContainer = $("#helpItemListContainer");

    function ignore(e) {
        if (e) {
            e.preventDefault();
        }
    }

    // submit from when Save button clicked
    btnEditItem.click(function () {
        $("#editItem-form").submit();
    });

    $("#cancelEditItem").click(function () {
        clearText();
    });

    $("#editItem-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            Title: {
                required: true
            },
            Selector: {
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
        if (item.Status !== 3) {
            var itemHtml = '<li class="ui-state-default" data-item-id="" data-item-order="' + item.DisplayOrder + '">' +
                            '<span class="ui-icon ui-icon-arrowthick-2-n-s"></span>' +
                            '<span class="help-item-title">' + item.Title + '</span>' +
                            ' <span class="help-item-btn">' +
                             ' <a  id="' + item.HelpItemID + '" class="btn btn-primary btn-sm help-item-element-delete"><i class="fa fa-times"></i></a>' +
                             ' <a  id="' + item.HelpItemID + '" class="btn btn-primary btn-sm help-item-element"><i class="fa fa-edit"></i></a> ' +
                            '</span>' +
                          ' </li>';
            return itemHtml;
        } else {
            return '';
        }
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
            if (response !== null || response !== undefined) {
                if (response.Item != null) {
                    $('#helpItemId').val(itemId);
                    btnEditItem.text("Save");
                    $('#helpItemTitle').val(response.Item.Title);
                    $('#helpItemSelector').val(response.Item.Selector);
                    $('#helpItemDescription').val(response.Item.Description);
                    $('#helpItemPosition').val(response.Item.Position);
                    $('#helpItemTabContainerId').val(response.Item.TabContainerId);
                }
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
            if (response !== null || response !== undefined) {
                if (response.result) {
                    loadItemsForList(response.Items);
                    clearText();
                }
            }
        });
    });

    function loadItemsForList(items) {
        itemListContainer.html("");
        btnEditItem.prop('disabled', false);
        if (items != null && items.length >= 1) {
            for (var i = 0; i < items.length; i++) {
                itemListContainer.append(createItem(items[i]));
            }
        }
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
            if (response !== null || response !== undefined) {
                if (response.result) {
                    loadItemsForList(response.Items);
                }
            }
        });
    }

    function validateSubmit(form) {
        btnEditItem.prop('disabled', true);
        ajaxWrapper({
            url: $(form).attr('action'),
            data: $(form).serializeArray(),
            type: 'POST'
        })
                .done(function (response) {
                    if (response !== null || response !== undefined) {
                        if (response.result) {
                            loadItemsForList(response.Items);
                            clearText();
                        }
                    }
                });
    }

    function clearText() {
        $("#editItem-form input[type=text]").val('');
        $("#editItem-form select").prop('selectedIndex', '0');
        $("#editItem-form textarea").val('');
        $("#editItem-form input[type=text]").first().focus();
        btnEditItem.text("Add");
        $("#helpItemId").val("");
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
            if (response !== null || response !== undefined) {
                if (response.result) {
                    loadItemsForList(response.Items);
                }
            }
        });
    }


    $(document).ready(function () {
        getItemsOnPage();
    });

    itemListContainer.sortable({
        containment: 'parent',
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
});