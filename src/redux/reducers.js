import { ADD_EVENT, ADD_TICKET_TYPE, DELETE_TICKET_TYPE, SWITCH_MODAL } from './actionTypes'
import { EVENT, TICKET_TYPE, EVENT_LINK} from './actionTypes'

const initialEventState = {
    event: {
        id: '',
        name: '',
        description: '',
        location: '',
        date: Date.now(),
        numberOfTickets: 0
    }
}

export const eventReducer = (state = initialEventState, action) => {
    switch(action.type){
        case ADD_EVENT:
            console.log('test')
            return (
                {
                    ...state,
                    eventFormActive: false,
                    event: {
                        id: action.payload.id,
                        name: action.payload.name,
                        description: action.payload.description,
                        location: action.payload.location,
                        date: action.payload.date,
                        numberOfTickets: action.payload.numberOfTickets
                    }
                }
            )
        default:
            return state;
    }
}

const initialTicketTypesState = {
    ticketTypes: []
}

export const ticketTypeReducer = (state = initialTicketTypesState, action) => {
    switch(action.type){
        case ADD_TICKET_TYPE:
            let newTicketType = {
                id: action.payload.id,
                description: action.payload.description,
                name: action.payload.name,
                price: action.payload.price,
                numberAvailable: action.payload.numberAvailable,
                eventId: action.payload.eventId
            }
            return (
                {
                    ...state,
                    ticketTypes: [...state.ticketTypes, newTicketType]                   
                }
            )
        
        case DELETE_TICKET_TYPE:
            return (
                {
                    ...state,
                    ticketTypes: state.ticketTypes.filter((ticketType) => ticketType.id !== action.payload.id )
                }
            )

        default:
            return state;
    }
}

const initialModalState = {
    visibleModal: EVENT
}

export const visibleModalReducer = (state = initialModalState, action) => {
    switch(action.type){
        case SWITCH_MODAL:
            return (
                {
                    visibleModal: action.payload.modal
                }
            )
        default:
            return state;
    }
}