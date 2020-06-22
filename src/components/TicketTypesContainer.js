import React from 'react'
import TicketType from './TicketType'

function TicketTypesContainer({ticketTypes, deleteTicketType}) {
    const renderTicketTypes = () => {
        return ticketTypes.map((ticketType, index) => {
            return <TicketType key={index} ticketType={ticketType} deleteTicketType={deleteTicketType} index={index}/>
        })
    }
    return (
        <div>
            <div className={'container w-75 mt-5'}>
                {renderTicketTypes()}
            </div>
        </div>
    )
}

export default TicketTypesContainer
