﻿$(function () {
    var btnAddItem = $("#submitAddItem");
    var itemListContainer = $("#helpItemListContainer");

    function ignore(e) {
        if (e) e.preventDefault();
    }
    // submit from when Save button clicked
    btnAddItem.click(function () {
        $("#addItem-form").submit();
    });

    $("#cancelAddItem").click(function () {
        clearText();
    });

    $("#addItem-form").validate({
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
        var itemHtml = '<li class="ui-state-default" data-item-id="" data-item-order="' + item.DisplayOrder + '">' +
                        '<span class="ui-icon ui-icon-arrowthick-2-n-s"></span>' +
                        '<span class="help-item-title">' + item.Title + '</span>' +
                        ' <span class="help-item-btn">' +
                         ' <a class="btn btn-primary btn-sm" data-modallink="true" data-url=""><i class="fa fa-times"></i></a>' +
                         ' <a class="btn btn-primary btn-sm" data-modallink="true" data-url=""><i class="fa fa-edit"></i></a> ' +
                        '</span>' +
                      ' </li>';
        return itemHtml
    }

    function validateSubmit(form) {
        btnAddItem.prop('disabled', true);
        ajaxWrapper({
            url: $(form).attr('action'),
            data: $(form).serializeArray(),
            type: 'POST'
        }).done(function (response) {
            if (response != null || response != undefined) {
                loadItemsForList(response.Items);
                clearText();
            }
        });
    }

    function clearText() {
        $("#addItem-form input[type=text]").val('');
        $("#addItem-form select").prop('selectedIndex', '0');
        $("#addItem-form textarea").val('');
        $("#addItem-form input[type=text]").first().focus();
    }

    function updateItemOrder() {
        var items = itemListContainer.children("li");
        var newOrder = [];
        items.each(function () {
            var order = $(this).data("item-order");
            if (order != null && order != undefined) {
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
            if (response != null || response != undefined) {
                if (response.result) {
                    loadItemsForList(response.Items);
                }
            }
        });
    }

    function loadItemsForList(items) {
        itemListContainer.html("");
        btnAddItem.prop('disabled', false);
        if (items != null && items.length >= 1) {
            for (var i = 0; i < items.length; i++) {
                itemListContainer.append(createItem(items[i]));
            }
        }
    }

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
            console.log(inst);
            console.log(inst.input);
            console.log(inst.input.data("val"));
        }
    });
})