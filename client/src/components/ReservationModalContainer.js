import React, { useEffect } from 'react'
import { connect } from 'react-redux'
import ReservationEvent from './Reservation/ReservationEvent'
import ReservationTicketType from './Reservation/ReservationTicketType'
import ReservationContactInfo from './Reservation/ReservationContactInfo'
import { apiRetrieveEvent } from '../redux/actions'

function ReservationModalContainer({eventId, apiResponses, apiRetrieveEvent}) {    

    useEffect(() => { apiRetrieveEvent(eventId) }, [])

    return (
        <div className={'container w-75 mt-5'}>
            <ReservationEvent />
            <ReservationTicketType />
            <ReservationContactInfo />            
        </div>
    )
}

const mapStateToProps = (state) => {
    return {
        apiResponses: state.apiRetrieveEventReducer.apiResponses
    }
}

const mapDispatchToProps = (dispatch) => ({
    apiRetrieveEvent: (eventId) => {dispatch(apiRetrieveEvent(eventId))}
})


export default connect(mapStateToProps, mapDispatchToProps)(ReservationModalContainer)
