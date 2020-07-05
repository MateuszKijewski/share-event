import {createStore, combineReducers} from 'redux'
import {eventReducer, ticketTypeReducer, visibleModalReducer, apiCreateEventReducer} from './reducers'

export default createStore(combineReducers({eventReducer, ticketTypeReducer, visibleModalReducer, apiCreateEventReducer}), 
window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__())