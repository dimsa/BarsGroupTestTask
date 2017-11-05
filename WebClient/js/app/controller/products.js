Ext.define('App.controller.products', {
    extend: 'Ext.app.Controller',
    stores: [
        'App.model.productStore'
    ],
    views: [
        'App.view.products'
    ],
    grid: undefined,
    viewport: undefined,
    init: function (app) {
        console.log('productsControllerInit');
    },
    renderTo: function (viewport) {
        var store = this.getStore('App.model.productStore');
        var gr = this.getView('App.view.products');
        this.grid = Ext.create(gr);
        this.grid.bindStore(store);
        this.viewport = viewport;
        this.addComponent(this.grid);
    },
    addComponent: function (component) {
        this.viewport.add(component);
        this.viewport.doLayout();
    }
});
