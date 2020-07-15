import React, { useRef, useState } from 'react'

function ReservationTicketType({ticketType: {ticketTypeId, name, description, numberAvailable, price}, reservedTickets, addReservedAmount}) {
    const currentCardBody = useRef(null);

    // var currentTicketReservation = reservedTickets.filter((rt) => {
    //     return rt.ticketTypeId === ticketTypeId
    // })

    const [allValues, setAllValues] = useState({
        ticketTypeId: ticketTypeId,
        amount: ''
    })
    const changeHandler = (e) => {
        setAllValues({
            ...allValues,
            [e.target.name]: e.target.value            
        })        
    }

    function handleClick() {
        let element = currentCardBody.current.style
        let elementVisible = (element['display'] === '' || element['display'] === 'block')
        elementVisible ? element.display = 'none' : element.display = 'block'
    }
    return (
        <div className={'container w-90 mt-5'}>
            <div className={"card mb-2"}>
                <div className={'card-header'} >
                    <b>{name}</b>
                    <button className={'btn btn-primary expandButton'} onClick={handleClick}>v</button>
                </div>
                <div className={"card-body"} ref={currentCardBody} style={{display: 'block'}}>
                    <div className={'form-group'}>
                        <p>{description}</p>
                        <hr/>
                        <div>
                            <h4 style={{color: 'green'}} className={'d-inline'}>{price} PLN</h4>
                            <div className={'d-inline float-right'}>
                                Amount: <input name="amount" onChange={changeHandler} type="number"></input>
                                <button className={'btn btn-primary orderButton ml-2'} onClick={() => {addReservedAmount(allValues)}}><b>Order</b></button><br/>
                            </div>
                        </div>
                        <h5 className={'mt-2'}>{numberAvailable} available</h5>                     
                    </div>
                </div>
             </div>
        </div>        
    )
}

export default ReservationTicketType
