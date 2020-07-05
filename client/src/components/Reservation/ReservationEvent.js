import React from 'react'

function ReservationEvent() {
    return (
        <div>
            <div className={"card mb-2"}>
			<div className={"card-header text-center"}><b>Event details</b></div>
			<div className={'card-body text-center'}>
                <h1 className={'headerActionsSpan'}>Title</h1>
                <h2>15.07.2020 location</h2>
                <hr/>
                <p>description description description description description description description description description </p>
                <h4>50 tickets</h4>
			</div>
		    </div>
        </div>
    )
}

export default ReservationEvent
