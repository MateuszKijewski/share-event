import React from 'react'
import ReservationEvent from './ReservationEvent'
import ReservationTicketTypeContainer from './ReservationEvent'
import ReservationContactInfo from './ReservationEvent'

function ReservingModal() {
    return (
        <div>
            <ReservationEvent event={event} />
            <ReservationTicketTypeContainer 
                ticketTypes={ticketTypes} 
                reservedTickets={reservedTickets}
                addReservedAmount={addReservedAmount}
            />
            <ReservationContactInfo 
                addContactInfo={addContactInfo}
                contactInfo={contactInfo}
            />
        </div>
    )
}

export default ReservingModal
