import React, {useRef} from 'react'

function TicketType({ticketType: {id, name, description, price, numberAvailable}, index, deleteTicketType}) {
    const currentCardBody = useRef(null);

    function handleClick() {
        let element = currentCardBody.current.style
        let elementVisible = (element['display'] === '' || element['display'] === 'block')
        elementVisible ? element.display = 'none' : element.display = 'block'
    }

    return (
        <div className={"card mb-2"}>
        <div className={'card-header'} >
            <b>{name}</b>
            <button className={'btn btn-primary expandButton'} onClick={handleClick}>v</button>
            <button className={'btn btn-danger deleteButton'} onClick={() => {deleteTicketType(id)}}>x</button>

        </div>
        <div className={"card-body"} ref={currentCardBody} style={{display: 'none'}}>
            <div className={'form-group'}>
                <p>{description}</p>
                <h4 style={{color: 'green'}}>{price} PLN</h4>
                <h5>{numberAvailable} available</h5>                     
            </div>
        </div>
        </div>
    )
}

export default TicketType
