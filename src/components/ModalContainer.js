import React from 'react'
import { connect } from 'react-redux'
import CreateEvent from './CreateEvent'
import CreateTicketTypes from './CreateTicketTypes'
import { addEvent, addTicketType, switchModal } from '../redux/actions'

function ModalContainer({event, visibleModal, addEvent, addTicketType, switchModal}) {
    const renderModal = () => {
        switch(visibleModal){
          case 'event':
            return <CreateEvent addEvent={addEvent} switchModal={switchModal} />
          
          case 'ticket_type':
            return <CreateTicketTypes eventId={event.id} addTicketType={addTicketType} switchModal={switchModal} />
          
          case 'event_link':
            return 'event_link'
          
          default:
            return <CreateEvent addEvent={addEvent} switchModal={switchModal} />
        }
      }
    return (
        <div>
            {renderModal()}
        </div>
    )
}

const mapStateToProps = (state) => {
    return {
        visibleModal: state.visibleModalReducer.visibleModal,
        event: state.eventReducer.event,
        ticketTypes: state.ticketTypeReducer.ticketTypes
    }
}

const mapDispatchToProps = (dispatch) => ({
    addEvent: (eventData) => {dispatch(addEvent(eventData))},
    addTicketType: (ticketTypeData) => {dispatch(addTicketType(ticketTypeData))},
    switchModal: (modal) => {dispatch(switchModal(modal))}
})

export default connect(mapStateToProps, mapDispatchToProps)(ModalContainer)
