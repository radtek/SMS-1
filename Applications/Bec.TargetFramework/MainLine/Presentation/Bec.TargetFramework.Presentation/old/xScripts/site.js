//init of the options

//--------Require.js base configuration
var require = {
    urlArgs: "no-cache=" + (new Date()).getTime(),
    paths: {
        'Layout': '/Scripts/Layout/ViewModels',
        'Login': '/Scripts/Login',
        'HomeVM':'/Scripts/Home/ViewModels',
        //'jquery': '/Scripts/Libs/Vendor/jQuery/jquery-1.10.2.min',
        'Fields': '/Scripts/Common/ViewModels/Fields',
        'PagePartials': '/Scripts/Common/ViewModels/PagePartials',
        'FieldTemplates': '',
        'jquery': '/Scripts/Libs/Vendor/jQuery/jquery-1.10.2.min',
        'Company': '/Scripts/Company'
    },
    shim: {
        //"jquery": { exports: "$" }
    },

    
};
//--------/Require.js base configuration------------

//--------knockout.validation  configuration
ko.validation.init({
    errorElementClass: 'red-glow',
    decorateInputElement: true,
    insertMessages: false
});
//--------/knockout.validation  configuration