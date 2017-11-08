Ext.define('App.model.productStore', {
    extend: 'Ext.data.Store',
    model: 'App.model.product',
    pageSize: 10,
    proxy: {
        allowSingle: true,
        type: 'rest',
        url: 'http://localhost:5344/api/products',
       // success: function (r) { alert(r); },
        reader: {
            successProperty: 'success',
            type: 'json',
            root: 'Data',
            totalProperty: 'RecordTotal'
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
