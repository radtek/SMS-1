$(function () {
    'use strict';

    $("[id$='PostcodeLookupComponent'").each(function (i, postcodeLookup) {
        console.log($(postcodeLookup).data('prefix'));
        var prefix = $(postcodeLookup).data('prefix');

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