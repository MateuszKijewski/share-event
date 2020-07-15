import {createStore, combineReducers, applyMiddleware} from 'redux'
import { composeWithDevTools } from 'redux-devtools-extension'
import {eventReducer, ticketTypeReducer, visibleModalReducer,
     apiCreateEventReducer, apiRetrieveEventReducer,
     contactInfoReducer, reservedTicketsReducer, visibleReservationModalReducer, apiCreateReservationsReducer} from './reducers'
import thunk from 'redux-thunk'

export default createStore(combineReducers({
    eventReducer, ticketTypeReducer, visibleModalReducer,
     apiCreateEventReducer, apiRetrieveEventReducer,
     contactInfoReducer, reservedTicketsReducer, visibleReservationModalReducer, apiCreateReservationsReducer
    }
    ),composeWithDevTools(applyMiddleware(thunk))) 
//window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__(applyMiddleware(thunk)))