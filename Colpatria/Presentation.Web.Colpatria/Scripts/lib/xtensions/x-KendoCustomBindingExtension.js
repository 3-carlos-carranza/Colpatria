kendo.data.binders.integer = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        //call the base constructor
        kendo.data.Binder.fn.init.call(this, element, bindings, options);

        var that = this;
        //listen for the change event of the element
        $(that.element).on("change", function () {
            that.change(); //call the change function
        });
    },
    refresh: function () {
        var that = this,
            value = that.bindings["integer"].get();
        $(that.element).val(kendo.parseInt(value));
    },
    change: function () {
        var value = this.element.value;
        var integer = kendo.parseInt(value);
        if (!isNaN(integer)) {
            this.bindings["integer"].set(integer);
        }

    }
});



kendo.data.binders.keyPress = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        kendo.data.Binder.fn.init.call(this, element, bindings, options);
        
        var that = this;
  
        $(that.element).on("keypress", function (e) {
            if (e.which == 13) {
                var value = $(that.element).val();
                that.bindings["value"].set(value);
                that.bindings["keyPress"].get();
                
               // that.change();
                
            }
        });
    },
    refresh: function() {
    }
});


kendo.data.binders.decimal = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        //call the base constructor
        kendo.data.Binder.fn.init.call(this, element, bindings, options);

        var that = this;
        //listen for the change event of the element
        $(that.element).on("change", function () {
            that.change(); //call the change function
        });
    },
    refresh: function () {
        var that = this,
            value = that.bindings["decimal"].get();
        $(that.element).val(kendo.parseFloat(value));
    },
    change: function () {
        var value = this.element.value;
        var decimal = kendo.parseFloat(value);
        if (!isNaN(decimal)) {
            this.bindings["decimal"].set(decimal);
        }

    }
});

kendo.data.binders.date = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        //call the base constructor
        kendo.data.Binder.fn.init.call(this, element, bindings, options);

        var that = this;
        //listen for the change event of the element
        $(that.element).on("change", function () {
            that.change(); //call the change function
        });
    },
    refresh: function () {
        var that = this,
            value = that.bindings["date"].get();
        $(that.element).val(kendo.format(new Date(value), "dd/MM/yyyy"));
    },
    change: function () {
        var value = this.element.value;
        this.bindings["date"].set(value);

    }
});