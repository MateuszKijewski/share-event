import React, { useRef } from 'react'

function ReservationTicketType() {
    const currentCardBody = useRef(null);

    function handleClick() {
        let element = currentCardBody.current.style
        let elementVisible = (element['display'] === '' || element['display'] === 'block')
        elementVisible ? element.display = 'none' : element.display = 'block'
    }
    return (
        <div className={'container w-90 mt-5'}>
            <div className={"card mb-2"}>
                <div className={'card-header'} >
                    <b>Name</b>
                    <button className={'btn btn-primary expandButton'} onClick={handleClick}>v</button>
                </div>
                <div className={"card-body"} ref={currentCardBody} style={{display: 'block'}}>
                    <div className={'form-group'}>
                        <p>descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription</p>
                        <hr/>
                        <div>
                            <h4 style={{color: 'green'}} className={'d-inline'}>100 PLN</h4>
                            <div className={'d-inline float-right'}>
                                Amount: <input type="number"></input>
                                <button className={'btn btn-primary orderButton ml-2'}><b>Order</b></button><br/>
                            </div>
                        </div>
                        <h5 className={'mt-2'}>25 available</h5>                     
                    </div>
                </div>
             </div>
        </div>        
    )
}

export default ReservationTicketType
