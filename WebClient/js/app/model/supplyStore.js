Ext.define('App.model.supplyStore', {
    extend: 'Ext.data.Store',
    model: 'App.model.supply',
    proxy: {
        allowSingle: true,
        type: 'rest',
        url: 'http://localhost:5344/api/supplies',
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
