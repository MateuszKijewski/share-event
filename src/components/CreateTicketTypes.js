import React, { useState } from 'react'
import TicketTypesContainer from './TicketTypesContainer'

function CreateTicketTypes({eventId, addTicketType, deleteTicketType, switchModal, ticketTypes, event, apiCreateEvent}) {
    const [allValues, setAllValues] = useState({
        name: '',
        description: '',
        price: 0,
        numberAvailable: 0,
        eventId: eventId
    })
    const changeHandler = (e) => {
        setAllValues({
            ...allValues,
            [e.target.name]: e.target.value            
        })        
    }
    
    return (
        <React.StrictMode>
        <TicketTypesContainer ticketTypes={ticketTypes} deleteTicketType={deleteTicketType} />
        <div className={'container w-75 mt-5'}>
            <div className={"card mb-2"}>
			<div className={"card-header text-center"}><b>Define ticket types</b></div>
			<div className={'card-body'}>
                <div className={'form-group'}>
                    <label>Name</label>
                    <input type='text' name="name" className={'form-control'} onChange={changeHandler} />
                    <label className={'mt-2'}>Description</label>
                    <textarea name="description" className={'form-control'} onChange={changeHandler}/>
                    <label className={'mt-2'}>Price</label>
                    <input name="price" type='number' className={'form-control'} onChange={changeHandler}/>
                    <label className={'mt-2'}>Number available</label>
                    <input type='number' name="numberAvailable" className={'form-control'} onChange={changeHandler}/>
                    <div className={'text-center mt-5'}>
                        <button className={'btn btn-primary addButton'} onClick={() => {addTicketType(allValues)}}><b>Add ticket type</b></button><br/>
                        <button className={'btn btn-primary proceedButton mt-3'} onClick={() => {apiCreateEvent(event, ticketTypes); switchModal('event_link')}}><b>Proceed</b></button>
                    </div>
                </div>
			</div>
            <div className={'card-footer text-muted text-center'}>2/3</div>
		    </div>
        </div>
        </React.StrictMode>
    )
}

export default CreateTicketTypes
