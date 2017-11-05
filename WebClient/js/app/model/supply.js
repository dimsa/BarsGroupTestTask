Ext.define('App.model.supply', {
    extend: 'Ext.data.Model',
    fields: [
        { name: 'Id', type: 'int' },
        { name: 'TimeStamp', type: 'date' },
        { name: 'Product', type: 'auto' },
        { name: 'Provisioner', type: 'auto' }
    ]
});
