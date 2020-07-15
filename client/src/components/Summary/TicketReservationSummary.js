import React from 'react'

function ticketReservationSummary({name, description, price, reservedAmount}) {
    return (
        <div>
            <h3>{name}</h3>
            <h4 style={{color: 'green'}} className={'d-inline'}>{price} PLN</h4>
            <p>{description}</p>
            <b>{reservedAmount} tickets reserved</b>
        </div>
    )
}

export default ticketReservationSummary
