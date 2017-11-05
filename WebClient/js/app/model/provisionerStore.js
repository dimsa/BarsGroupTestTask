Ext.define('App.model.provisionerStore', {
    extend: 'Ext.data.Store',
    model: 'App.model.provisioner',
    proxy: {
        allowSingle: true,
        type: 'rest',
        url: 'http://localhost:5344/api/provisioners',
        success: function (r) { alert(r); },
        reader: {
            successProperty: 'success',
            type: 'json'
        },
        writer: {
            type: 'json'
        }
    },
    autoLoad: true,
    autoSync: true
});
