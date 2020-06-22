import { ADD_EVENT, ADD_TICKET_TYPE, DELETE_TICKET_TYPE, SWITCH_MODAL } from './actionTypes'
import { EVENT } from './actionTypes'
import { ADD_RESERVED_AMOUNT, ADD_CONTACT_INFO, SWITCH_RESERVATION_MODAL} from './actionTypes'
import { RESERVATION } from './actionTypes'


/* Creating event */

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

/* Reservations */

const initialReservedAmountState = {
    reservedTickets: []
}

export const reservedTicketsReducer = (state = initialReservedAmountState, action) => {
    switch(action.type){
        case ADD_RESERVED_AMOUNT:
            return (
                {
                    ...state,
                    reservedTickets: [...state.reservedTickets, {
                        ticketTypeId: action.payload.ticketTypeId,
                        amount: action.payload.amount
                    }]
                }
            )
        default:
            return state
    }
}

const initialContactInfoState = {
    contactInfo: {
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: ''
    }
}

export const contactInfoReducer = (state = initialContactInfoState, action) => {
    switch(action.type){
        case ADD_CONTACT_INFO:
            return (
                {
                    ...state,
                    contactInfo: {
                        firstName: action.payload.firstName,
                        lastName: action.payload.lastName,
                        email: action.payload.email,
                        phoneNumber: action.payload.phoneNumber
                    }
                }
            )
        default:
            return state
    }
}

const initialReservationModalState = {
    visibleReservationModal: RESERVATION
}

export const visibleReservationModalReducer = (state = initialReservationModalState, action) => {
    switch(action.type){
        case SWITCH_RESERVATION_MODAL:
            return (
                {
                    visibleReservationModal: action.payload.visibleReservationModal
                }
            )
        default:
            return state;
    }
}