import React, { useEffect } from 'react'
import { connect } from 'react-redux'
import ReservationEvent from './Reservation/ReservationEvent'
import ReservationTicketTypeContainer from './Reservation/ReservationTicketTypeContainer'
import ReservationContactInfo from './Reservation/ReservationContactInfo'
import { apiRetrieveEvent, addContactInfo, addReservedAmount, switchReservationModal, apiCreateReservations } from '../redux/actions'
import ReservationSummaryModal from './Summary/ReservationSummaryModal'

function ReservationModalContainer({apiCreateReservations, visibleReservationModal, switchReservationModal, eventId, apiResponses, apiRetrieveEvent, addContactInfo, contactInfo, reservedTickets, addReservedAmount}) {    

    useEffect(() => { apiRetrieveEvent(eventId) }, [])
    let event = {}
    let ticketTypes = []
    if (apiResponses !== undefined){        
        event = apiResponses.retrieveEventResponse.getEventDto
        ticketTypes = apiResponses.retrieveEventResponse.getEventDto.ticketTypes
    }
    
    const renderModal = () => {
        switch(visibleReservationModal){
            case 'reservation':
                return (
                    <div className={'container w-75 mt-5'}>
                    <ReservationEvent event={event} />
                    <ReservationTicketTypeContainer 
                        ticketTypes={ticketTypes} 
                        reservedTickets={reservedTickets}
                        addReservedAmount={addReservedAmount}
                    />
                    <ReservationContactInfo 
                        addContactInfo={addContactInfo}
                        contactInfo={contactInfo}
                        switchReservationModal={switchReservationModal}
                    />            
                </div>
                )
            case 'summary':
                return (
                    <ReservationSummaryModal 
                    event={event}
                    contactInfo={contactInfo}
                    ticketTypes={ticketTypes}
                    reservedTickets={reservedTickets}
                    apiCreateReservations={apiCreateReservations}
                    />
                )
        }
    }

    return (
        renderModal()
    )
}

const mapStateToProps = (state) => {
    return {
        apiResponses: state.apiRetrieveEventReducer.apiResponses,
        contactInfo: state.contactInfoReducer.contactInfo,
        reservedTickets: state.reservedTicketsReducer.reservedTickets,
        visibleReservationModal: state.visibleReservationModalReducer.visibleReservationModal
    }
}

const mapDispatchToProps = (dispatch) => ({
    apiRetrieveEvent: (eventId) => {dispatch(apiRetrieveEvent(eventId))},
    apiCreateReservations: (reservationsArray, contactInfo, eventId) => {dispatch(apiCreateReservations(reservationsArray, contactInfo, eventId))},
    addContactInfo: (contactInfoData) => {dispatch(addContactInfo(contactInfoData))},
    addReservedAmount: (reservedAmountData) => {dispatch(addReservedAmount(reservedAmountData))},
    switchReservationModal: (visibleReservationModal) => {dispatch(switchReservationModal(visibleReservationModal))}
})


export default connect(mapStateToProps, mapDispatchToProps)(ReservationModalContainer)
