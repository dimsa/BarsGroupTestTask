Ext.define('App.model.productStore', {
    extend: 'Ext.data.Store',
    model: 'App.model.product',
    proxy: {
        allowSingle: true,
        type: 'rest',
        url: 'http://localhost:5344/api/products',
       // success: function (r) { alert(r); },
        reader: {
            successProperty: 'success',
            type: 'json'
        },
        writer: {
            type: 'json'
        },
        actionMethods:
        {
            create: "POST",
            read: "GET",
            update: "PUT",
            destroy: "DELETE"
        }
    },
    autoLoad: true,
    autoSync: true
});
