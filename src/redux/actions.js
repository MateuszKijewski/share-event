import { ADD_EVENT, ADD_TICKET_TYPE, DELETE_TICKET_TYPE,SWITCH_MODAL } from './actionTypes'
import { v4 as uuidv4 } from 'uuid';

export const addEvent = (eventData) => (    
    {
        type: ADD_EVENT,
        payload: {
            id: uuidv4(),
            name: eventData.name,
            description: eventData.description,
            location: eventData.location,
            date: eventData.date,
            numberOfTickets: eventData.numberOfTickets
        }
    }
)

export const addTicketType = (ticketTypeData) => (
    {
        type: ADD_TICKET_TYPE,
        payload: {
            id: uuidv4(),
            name: ticketTypeData.name,
            description: ticketTypeData.description,
            price: ticketTypeData.price,
            numberAvailable: ticketTypeData.numberAvailable,
            eventId: ticketTypeData.eventId,
        }
    }
)

export const deleteTicketType = (id) => (
    {
        type: DELETE_TICKET_TYPE,
        payload: {
            id
        }
    }
)

export const switchModal = (modal) => (
    {
        type: SWITCH_MODAL,
        payload: {
            modal
        }
    }
)