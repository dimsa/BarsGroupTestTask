Ext.define('App.model.provisionerStore', {
    extend: 'Ext.data.Store',
    model: 'App.model.provisioner',
    proxy: {
        allowSingle: true,
        type: 'rest',
        url: 'http://localhost:5344/api/provisioners',
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
