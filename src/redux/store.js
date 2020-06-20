import {createStore, combineReducers} from 'redux'
import {eventReducer, ticketTypeReducer, visibleModalReducer} from './reducers'

export default createStore(combineReducers({eventReducer, ticketTypeReducer, visibleModalReducer}), 
window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__())