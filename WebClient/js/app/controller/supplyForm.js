Ext.define('App.controller.supplyForm', {
    extend: 'Ext.app.Controller',

    views: ['App.view.supplyForm'],
    models: ['App.model.supply'],
    view: undefined,
    values: undefined,
    editingId: undefined,
    show: function (values) {
        var Form = this.getView('App.view.supplyForm');
        this.view = Ext.create(Form);

        if (values !== undefined && values.id !== undefined) {
            this.editingId = values.id;
        }

        this.view.updateStores();
        this.view.show();
        this.values = values;

        if (this.values) {
            this.getFormPanel().getForm().setValues(this.values);
        }

        this.view.on('close', this.onViewClose, this);

        this.getCancelButton().on('click', this.onCancelButtonClick, this);
        this.getSaveButton().on('click', this.onSaveButtonClick, this);
    },


    refs: [
   {
       ref: 'cancelButton',
       selector: 'button#cancelButton'
   },

   {
       ref: 'saveButton',
       selector: 'button#saveButton'
   },
   {
       ref: 'formPanel',
       selector: '#formPanel'
   }],

    onCancelButtonClick: function () {
        this.cancel();
    },

    onSaveButtonClick: function () {
        this.save();
    },

    cancel: function () {
        this.view.close();
    },

    save: function () {
        var formPanel = this.getFormPanel();
        if (!formPanel.getForm().isValid()) {
            Ext.MessageBox.alert('Ошибка', 'Заполните все поля, пожалуйста');
            return;
        }

        var values = formPanel.getValues();

        if (this.editingId !== undefined) {
            values.id = this.editingId;
        }

        this.application.fireEvent('FORM_CONTROLLER_APPLY', values);
        this.cancel();
    },

    onViewClose: function () {
        this.editingId = undefined;
        this.application.fireEvent('FORM_CONTROLLER_VIEW_CLOSED');
    }
});
