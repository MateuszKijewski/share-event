import React from 'react'

function ReservationEvent({event: {eventId, name, description, location, date, numberOfTickets}}) {
    return (
        <div>
            <div className={"card mb-2"}>
			<div className={"card-header text-center"}><b>Event details</b></div>
			<div className={'card-body text-center'}>
                <h1 className={'headerActionsSpan'}>{name}</h1>
                <h2>{date} {location}</h2>
                <hr/>
                <p>{description}</p>
                <h4>{numberOfTickets} tickets</h4>
			</div>
		    </div>
        </div>
    )
}

export default ReservationEvent
