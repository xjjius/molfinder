import EventEmitter from 'events'
const emit = new EventEmitter();
emit.setMaxListeners(500);
export { emit };
