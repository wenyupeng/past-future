var events = require('events');
var eventEmitter  = new events.EventEmitter;

var listener1 = function listener1() {
    console.log('监听器 Listener1 执行');
}

var listener2 = function listener2() {
    console.log('监听器 Listener2 执行')
}

// 绑定 connection 事件，处理函数为 listener1
eventEmitter.addListener('connection', listener1);
// 绑定 connection 事件，处理函数为 listener2
eventEmitter.on('connection', listener2);

// 处理 connection 事件
eventEmitter.emit('connection');

eventEmitter.removeListener('connection', listener1);
console.log('listener1 不再受监听.');

eventEmitter.emit('connection');

eventListeners = eventEmitter.listenerCount('connection');
console.log(eventListeners+' 个监听器监听连接事件.');
