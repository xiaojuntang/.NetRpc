var Zxxk = {

};
//1.1定义一个全局函数
jQuery.foo = function () {
    alert('添加一个新的全局函数');
}
//定义多个全局函数
jQuery.bar = function () {
    alert('再增加一个全局函数');
}
//1.2使用extend定义全局函数
jQuery.extend({
    foo1: function () {
        alert('extend 定义全局函数1');
    },
    bar1: function () {
        alert('extend 定义全局函数2');
    }
});
//1.3 使用命名空间定义函数
jQuery.plugin = {
    foo2: function () {
        alert('使用namespace定义函数');
    }
}

$(function () {
    $.foo();
    $.bar();
    $.foo1();
    $.bar1();
    $.plugin.foo2();
});

//---------------------------------------------------------------------------------------------------------------------------
//形式一
(function ($) {
    $.fn.extend({
        foo3: function () {
            alert('对象级别插件extend方式1');
        },
        bar3: function () {
            alert('对象级别插件extend方式2');
        }
    })
})(jQuery);

//形式二
(function ($) {
    $.fn.foo4 = function () {
        alert('对象级别插件fn方式');
    }
})(jQuery);

//接收参数来控制插件的行为
(function ($) {
    $.fn.bar4 = function (options) {
        var defaults = { aaa: '1', bbb: '2' };
        var opts = $.extend(defaults, options);
        alert('参数值:aaa:' + opts.aaa + ';bbb:' + opts.bbb);
    }
})(jQuery);

//提供公有方法访问插件的配置项值
(function ($) {
    $.fn.foo5 = function (options) {
        var opts = $.extend({}, $.fn.foo5.defaults, options);
        alert('参数值:aaa:' + opts.aaa + ';bbb:' + opts.bbb);
    }
    $.fn.foo5.defaults = { aaa: '1', bbb: '2' };
})(jQuery);

//提供公有方法来访问插件中其他的方法
(function ($) {
    $.fn.bar5 = function (options) {
        $.fn.bar5.alert(options);
    }
    $.fn.bar5.alert = function (params) {
        alert(params);
    }
})(jQuery);

$(function () {
    $('#test').foo3();
    $('#test').bar3();
    $('#test').foo4();
    $('#test').bar4();
    $('#test').bar4({ aaa: '3' });
    $('#test').bar4({ aaa: '3', bbb: '4' });
    $('#test').foo5();
    $('#test').foo5({ aaa: '5', bbb: '6' });
    $('#test').bar5('aaaa');
});

//----------------------------------------------------JS面向对象写法---------------------------------------------
//1.工厂方式

var Circle = function () {
    var obj = new Object();
    obj.PI = 3.14159;

    obj.area = function (r) {
        return this.PI * r * r;
    }
    return obj;
}

var c = new Circle();
alert(c.area(1.0));

//2.比较正规的写法


function Circle(r) {
    this.r = r;
}
Circle.PI = 3.14159;
Circle.prototype.area = function () {
    return Circle.PI * this.r * this.r;
}

var c = new Circle(1.0);
alert(c.area());

//3.json写法


var Circle = {
    "PI": 3.14159,
    "area": function (r) {
        return this.PI * r * r;
    }
};
alert(Circle.area(1.0));

//4.有点变化，但是实质和第一种一样


var Circle = function (r) {
    this.r = r;
}
Circle.PI = 3.14159;
Circle.prototype = {
    area: function () {
        return this.r * this.r * Circle.PI;
    }
}
var obj = new Circle(1.0);
alert(obj.area())




var show = {
    btn: $('.div1'),
    init: function () {
        var that = this;
        alert(this);
        this.btn.click(function () {
            that.change();
            alert(this);
        })

    },
    change: function () {
        this.btn.css({ 'background': 'green' });

    }
}
show.init();