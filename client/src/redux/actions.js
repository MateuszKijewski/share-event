import { ADD_EVENT, ADD_TICKET_TYPE, DELETE_TICKET_TYPE,SWITCH_MODAL } from './actionTypes'
import { ADD_RESERVED_AMOUNT, ADD_CONTACT_INFO, SWITCH_RESERVATION_MODAL} from './actionTypes'
import { API_CREATE_EVENT, API_RETRIEVE_EVENT } from './actionTypes'
import { v4 as uuidv4 } from 'uuid';
import axios from 'axios'

/* API calls */
const api = axios.create({
    baseURL: `https://localhost:44336/api/`
    //baseURL: `https://localhost:44336/`
})

export const apiCreateEvent = (eventData, ticketTypeArray) => {   
    let ticketTypesObjects = []
    ticketTypeArray.forEach((ticketTypeData) => {
        ticketTypesObjects.push({
            ticketTypeId: ticketTypeData.id,
            name: ticketTypeData.name,
            price: ticketTypeData.price,
            numberAvailable: ticketTypeData.numberAvailable,
            eventId: ticketTypeData.eventId
        })
    }) 
    const createEvent = async (eventData) => {
        let res = await api.post('/event', {
            
            addEventDto: {
                eventId: eventData.id,
                name: eventData.name,
                description: eventData.description,
                location: eventData.location,
                numberOfTickets: eventData.numberOfTickets                
            },
            addTicketTypeDtos: ticketTypesObjects 
        })
        return res
    }
    
    return (dispatch) => {
        createEvent(eventData).then(res => {
            dispatch({
                type: API_CREATE_EVENT,
                payload: {
                    createEventResponse: res.data
                }
            })
        })
    }
}

export const apiRetrieveEvent = (eventId) => {
    const retrieveEvent = async (eventId) => {
        let res = await api.get(`/event/${eventId}`, {
            eventId: eventId
        })

        return res
    }
    return (dispatch) => {
        retrieveEvent(eventId).then(res => {
            dispatch({
                type: API_RETRIEVE_EVENT,
                payload: {
                    retrieveEventResponse: res.data
                }
            })
        })
    }
    
    
    
}

/* Creating event */

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

/* Reservations */

export const addReservedAmount = (reservedAmountData) => (
    {
        type: ADD_RESERVED_AMOUNT,
        payload: {
            ticketTypeId: reservedAmountData.ticketTypeId,
            amount: reservedAmountData.amount            
        }
    }
)

export const addContactInfo = (contactInfoData) => (
    {
        type: ADD_CONTACT_INFO,
        payload: {
            firstName: contactInfoData.firstName,
            lastName: contactInfoData.lastName,
            email: contactInfoData.email,
            phoneNumber: contactInfoData.phoneNumber
        }
    }
)

export const switchReservationModal = (visibleReservationModal) => (
    {
        type: SWITCH_RESERVATION_MODAL,
        payload: {
            visibleReservationModal
        }
    }
)