import React, {useState} from 'react'

function CreateEvent({addEvent, switchModal}) {
    const [allValues, setAllValues] = useState({
        name: '',
        description: '',
        location: '',
        date: '',
        numberOfTickets: 0
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
			<div className={"card-header text-center"}><b>Create your event</b></div>
			<div className={'card-body'}>
                <div className={'form-group'}>
                    <label>Name</label>
                    <input type='text' name="name" className={'form-control'} onChange={changeHandler} />
                    <label className={'mt-2'}>Description</label>
                    <textarea name="description" className={'form-control'} onChange={changeHandler}/>
                    <label className={'mt-2'}>Location</label>
                    <input name="location" type='text' className={'form-control'} onChange={changeHandler}/>
                    <label className={'mt-2'}>Date</label>
                    <input type='date' name="date" className={'form-control'} onChange={changeHandler}/>
                    <label className={'mt-2'}>Number of tickets</label>
                    <input type='number' name="numberOfTickets" className={'form-control'} onChange={changeHandler}/>
                    <div className={'text-center mt-5'}>
                        <button className={'btn btn-primary proceedButton'} onClick={() => {addEvent(allValues); switchModal('ticket_type')}}><b>Proceed</b></button>
                    </div>
                </div>
			</div>
            <div className={'card-footer text-muted text-center'}>1/3</div>
		    </div>
        </div>
    )
}

export default CreateEvent
