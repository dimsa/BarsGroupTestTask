Ext.define('App.model.supplyStore', {
    extend: 'Ext.data.Store',
    model: 'App.model.supply',
    pageSize: 10,
    proxy: {
        allowSingle: true,
        type: 'rest',
        url: 'http://localhost:5344/api/supplies',        
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
    autoLoad: true
});
