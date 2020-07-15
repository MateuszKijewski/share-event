import React, {useState} from 'react'

function ReservationContactInfo({addContactInfo, switchReservationModal}) {
    const [allValues, setAllValues] = useState({
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: ''
    })
    const changeHandler = (e) => {
        setAllValues({
            ...allValues,
            [e.target.name]: e.target.value            
        })        
    }
    
    return (
        <div className={'container w-90 mt-5'}>
            <div className={"card mb-2"}>
			<div className={"card-header"}><b>Contact info</b></div>
			<div className={'card-body'}>
                <div className={'form-group'}>
                    <label>First name</label>
                    <input type='text' name="firstName" className={'form-control'} onChange={changeHandler} />
                    <label className={'mt-2'}>Last name</label>
                    <input name="lastName" className={'form-control'} onChange={changeHandler}/>
                    <label className={'mt-2'}>Email</label>
                    <input name="email" type='text' className={'form-control'} onChange={changeHandler}/>
                    <label className={'mt-2'}>Phone number</label>
                    <input type='text' name="phoneNumber" className={'form-control'} onChange={changeHandler}/>
                    <div className={'text-center mt-5'}>
                        <button className={'btn btn-primary proceedButton'} onClick={() => {addContactInfo(allValues); switchReservationModal('summary')}}><b>Proceed</b></button>
                    </div>
                </div>
			</div>
            <div className={'card-footer text-muted text-center'}>1/2</div>
		    </div>
        </div>
    )
}

export default ReservationContactInfo
