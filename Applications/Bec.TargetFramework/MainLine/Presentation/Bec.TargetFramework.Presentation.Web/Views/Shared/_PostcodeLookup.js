bec = {};
bec.postcodeLookup = bec.postcodeLookup || {};

bec.isFirstLoad = function (namesp, jsFile) {
    var isFirst = namesp.firstLoad === undefined;
    namesp.firstLoad = false;
    if (!isFirst) {
        console.log("Warning: Javascript file is included twice: " + jsFile);
    }
    return isFirst;
};

$(function () {
    'use strict';

    if (!bec.isFirstLoad(bec.postcodeLookup, "_PostcodeLookup.js")) {
        return;
    }

    $("[id$='PostcodeLookupComponent']").each(function (i, postcodeLookup) {
        var prefix = $(postcodeLookup).data('prefix');
        console.log(prefix);
        new findAddress({
            postcodelookup: '#' + prefix + 'PostcodeLookup',
            line1: '#' + prefix + 'Line1',
            line2: '#' + prefix + 'Line2',
            town: '#' + prefix + 'Town',
            county: '#' + prefix + 'County',
            postcode: '#' + prefix + 'PostalCode',
            manualAddress: '#' + prefix + 'ManualAddress',
            resList: '#' + prefix + 'AddressResults',
            manAddRow: '#' + prefix + 'ManAddRow',
            noMatch: '#' + prefix + 'NoMatch',
            findAddressButton: '#' + prefix + 'FindAddressButton'
        }).setup();
    });
});