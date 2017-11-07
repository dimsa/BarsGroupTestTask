Ext.require([
    'Ext.grid.*',
    'Ext.data.*',
    'Ext.util.*',
    'Ext.state.*'
]);

Ext.Loader.setPath('App', 'js/app');
Ext.Loader.setConfig({
    enabled: true,
    path: { 'App': 'js/app' }
});


Ext.onReady(function () {
    Ext.QuickTips.init();

    // sample static data for the store 

    /**
     * Custom function used for column renderer
     * @param {Object} val
     */
    function change(val) {
        if (val > 0) {
            return '<span style="color:green;">' + val + '</span>';
        } else if (val < 0) {
            return '<span style="color:red;">' + val + '</span>';
        }
        return val;
    }

    /**
     * Custom function used for column renderer
     * @param {Object} val
     */
    function pctChange(val) {
        if (val > 0) {
            return '<span style="color:green;">' + val + '%</span>';
        } else if (val < 0) {
            return '<span style="color:red;">' + val + '%</span>';
        }
        return val;
    }

    var storeFactory = Ext.create('App.Data.DataStoreFactory');
    var store = storeFactory.getStore();

    console.log(store);

    Ext.application({
        appFolder: 'js/app',
        name: 'App',
        autoCreateViewport: true,
        requires: ['App.view.Viewport'],
        controllers: ['App.controller.products', 'App.controller.provisioners', 'App.controller.supplies'],
        stores: ['App.model.productStore', 'App.model.provisionerStore', 'App.model.supplyStore'],


        launch: function () {
            var tabs = Ext.create('App.view.tabs');
            var vp = Ext.ComponentQuery.query('viewport')[0];
            vp.add(tabs);

            var controller = this.getController('App.controller.products');
            controller.renderTo(tabs.items.items[0]);
                       
            var controller = this.getController('App.controller.provisioners');
            controller.renderTo(tabs.items.items[1]);

            var controller = this.getController('App.controller.supplies');
            controller.renderTo(tabs.items.items[2]);
          
        }
    });
});
