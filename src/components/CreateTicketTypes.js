import React, { useState } from 'react'

function CreateTicketTypes({eventId, addTicketType, switchModal}) {
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
        <div className={'container w-75 mt-5'}>
            <div className={"card mb-2"}>
			<div className={"card-header"}><b>Create your event</b></div>
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
                        <button className={'btn btn-primary proceedButton mt-3'} onClick={() => {addTicketType(allValues)}}><b>Proceed</b></button>
                    </div>
                </div>
			</div>
            <div className={'card-footer text-muted'}>first step</div>
		    </div>
        </div>
    )
}

export default CreateTicketTypes
