Ext.define('App.Ui.PagingTool', {
        config: {
        },
        constructor: function () {
            this.initConfig();
        },
        
        getPagingTool: function (store) {
            return Ext.create('Ext.PagingToolbar',
                {
                    store: store,
                    displayInfo: true,
                    displayMsg: 'Displaying topics {0} - {1} of {2}',
                    emptyMsg: "No topics to display",
                    items: [
                        '-', {
                            text: 'Show Preview',
                            pressed: true,
                            enableToggle: true,
                            toggleHandler: function(btn, pressed) {
                                var preview = Ext.getCmp('gv').getPlugin('preview');
                                preview.toggleExpanded(pressed);
                            }
                        }
                    ]
                });
        }
    });
