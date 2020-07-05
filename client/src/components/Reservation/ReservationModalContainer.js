import React from 'react'
import ReservationEvent from './ReservationEvent'
import ReservationTicketType from './ReservationTicketType'
import ReservationContactInfo from './ReservationContactInfo'

function ReservationModalContainer() {
    return (
        <div className={'container w-75 mt-5'}>
            <ReservationEvent />
            <ReservationTicketType />
            <ReservationContactInfo />
        </div>
    )
}

export default ReservationModalContainer
