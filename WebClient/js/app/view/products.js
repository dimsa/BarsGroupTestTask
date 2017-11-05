Ext.define('App.view.products', {
    extend: 'Ext.grid.Panel',
    title: 'Редактирование списка товаров',
    columns: [
        {
            text: 'Идентификатор',
            width: 150,
            sortable: true,
            hideable: false,
            dataIndex: 'Id'
        },
        {
            text: 'Наименование',
            width: 300,
            sortable: true,
            hideable: false,
            dataIndex: 'Name'
        },
        {
            text: 'Код',
            width: 300,
            sortable: true,
            hideable: false,
            dataIndex: 'Code'
        }
    ]
});
