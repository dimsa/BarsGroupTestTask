Ext.define('App.controller.provisioners', {
    extend: 'Ext.app.Controller',
    stores: [
        'App.model.provisionerStore'
    ],
    views: [
        'App.view.provisioners'
    ],
    refs: [
        {
            ref: 'addButton',
            selector: 'button#addProvisionerButton'
        }
    ],
    grid: undefined,
    viewport: undefined,
    init: function (app) {
        console.log('provisionerControllerInit');
    },
    renderTo: function (viewport) {
        var store = this.getStore('App.model.provisionerStore');
        var gr = this.getView('App.view.provisioners');
        this.grid = Ext.create(gr);
        this.grid.bindStore(store);
        this.viewport = viewport;
        this.addComponent(this.grid);
        this.getAddButton().on('click', this.add, this);
    },
    addComponent: function (component) {
        this.viewport.add(component);
    },
    add: function (button) {
        alert('hello');
        var store = this.getStore('App.model.provisionerStore');
        var pr = Ext.create('App.model.provisioner', { Id: 0, Name: "Новый поставщик" });
        // Поле должно автоматически ставится в true, но этого не происходит.
        pr.phantom = true;
        store.add(pr);
    },
});
