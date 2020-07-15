import React from 'react'
import ReservationTicketType from './ReservationTicketType'

function ReservationTicketTypeContainer({ticketTypes, reservedTickets, addReservedAmount}) {
    const renderTicketTypes = () => {
        return ticketTypes.map((ticketType, index) => {
            return <ReservationTicketType 
            key={index} 
            ticketType={ticketType} 
            reservedTickets={reservedTickets}
            addReservedAmount={addReservedAmount}
            />
        })
    }

    return (
        <div>
            {renderTicketTypes()}            
        </div>
    )
}

export default ReservationTicketTypeContainer
