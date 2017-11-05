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
            selector: 'button#addButton'
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
        this.viewport.doLayout();
    },
    add: function (button) {
        alert(button);
              /*  var controller = this.application.getController('Keyhole.components.formController');
        controller.show();

        this.application.on('FORM_CONTROLLER_ADD', this.onFormControllerAdd, this);
        this.application.on('FORM_CONTROLLER_CLOSED', this.onFormControllerClosed, this);*/
    },
});
