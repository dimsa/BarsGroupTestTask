Ext.define('App.model.supply', {
    extend: 'Ext.data.Model',
    idProperty: 'Id',
    idgen: {
        isGenerator: true,
        type: 'default',
        generate: function () {
            return this;
        },
        getRecId: function (rec) {
            return rec.internalId;
        }
    },
    fields: [
        { name: 'Id', type: 'int' },
        { name: 'TimeStamp', type: 'date' },
        { name: 'Product', type: 'auto' },
        { name: 'Provisioner', type: 'auto' }
    ]
});
