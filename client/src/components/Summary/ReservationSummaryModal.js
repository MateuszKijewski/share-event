import React from 'react'
import ReservationEvent from '../Reservation/ReservationEvent'
import ContactInfoSummary from './ContactInfoSummary'
import TicketReservationSummary from './TicketReservationSummary'

function ReservationSummary({apiCreateReservations, event, contactInfo, ticketTypes, reservedTickets}) {

    const renderTicketTypes = () => {
        return reservedTickets.map((reservedTicket, index) => {
            var correctTicketType = ticketTypes.filter((tt) => {
                return tt.ticketTypeId == reservedTicket.ticketTypeId
            })
            let fullPrice = correctTicketType[0].price * reservedTicket.amount
            return <TicketReservationSummary
                key={index}
                name={correctTicketType.name}
                description={correctTicketType.description}
                price={fullPrice}
                reservedAmount={reservedTicket.amount}
            />
        })
    }

    return (
        <div className={'container w-100 mt-5'}>
            <ReservationEvent event={event} />            
            <div className={"card mb-2"}>
			<div className={"card-header text-center"}><b>Summary</b></div>
			<div className={'card-body text-center'}>
            <h1 className={'headerActionsSpan'}>Contact info</h1>
                <ContactInfoSummary contactInfo={contactInfo}/>
                <hr/>
                <h1 className={'headerActionsSpan'}>Reserved tickets</h1>
                <div>{renderTicketTypes()}</div>
                    <div className={'text-center mt-5'}>
                        <button className={'btn btn-primary proceedButton'} onClick={() => {apiCreateReservations(reservedTickets, contactInfo, event.eventId)}}><b>Finish</b></button>
                    </div>
                </div>
			</div>
            <div className={'card-footer text-muted text-center mt-n2 mb-5'}>2/2</div>
		    </div>
    )
}

export default ReservationSummary
