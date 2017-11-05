Ext.define('App.model.productStore', {
    extend: 'Ext.data.Store',
    model: 'App.model.product',
    proxy: {
        type: 'ajax',
        url: 'http://localhost:5344/api/products',
        success: function (r) { alert(r); },
        reader: {
            successProperty: 'success',
            type: 'json'
        }
    },
    autoLoad: true
});
