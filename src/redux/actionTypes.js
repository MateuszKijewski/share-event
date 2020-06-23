export const ADD_EVENT = 'ADD_EVENT'
export const ADD_TICKET_TYPE = 'ADD_TICKET_TYPE'
export const DELETE_TICKET_TYPE = 'DELETE_TICKET_TYPE'
export const GENERATE_LINK = 'GENERATE_LINK'
export const SWITCH_MODAL = 'SWITCH_MODAL'

export const API_CREATE_EVENT = 'API_CREATE_EVENT'

export const ADD_RESERVED_AMOUNT = 'ADD_RESERVED_AMOUNT'
export const ADD_CONTACT_INFO = 'ADD_CONTACT_INFO'
export const SWITCH_RESERVATION_MODAL = 'SWITCH_RESERVATION_MODAL'


export const EVENT = 'event'
export const TICKET_TYPE = 'ticket_type'
export const EVENT_LINK = 'event_link'
export const modalTypes = [EVENT, TICKET_TYPE, EVENT_LINK]

export const RESERVATION = 'reservation'
export const SUMMARY = 'summary'
export const reservationModalTypes = [RESERVATION, SUMMARY]


// EVENT CREATE
// {
//     "id": "447f14ef-5b1e-4b35-9615-2fca7af24e77",
//     "name": "Test name",
//     "description": "Test description",
//     "location": "Test location",
//     "date": "2020-03-20",
//     "numberOfReservations": 50
// }
// TICKET_TYPE CREATE
// {
//     "id": "447f14ef-5b1e-4b35-9615-2fca7af44e77",
//     "name": "Test name",
//     "price": 100,
//     "numberAvailable": 10,
//     "eventId": "447f14ef-5b1e-4b35-9615-2fca7af24e77"
// }