import React from 'react'
import { connect } from 'react-redux'
import CreateEvent from './CreateEvent'
import CreateTicketTypes from './CreateTicketTypes'
import SharedLink from './SharedLink'
import { addEvent, addTicketType, switchModal, deleteTicketType } from '../redux/actions'

function ModalContainer({event, visibleModal, ticketTypes, addEvent, addTicketType, deleteTicketType, switchModal}) {
    const renderModal = () => {
        switch(visibleModal){
          case 'event':
            return <CreateEvent
                addEvent={addEvent}
                switchModal={switchModal}
              />
          
          case 'ticket_type':
            return <CreateTicketTypes 
                eventId={event.id} 
                addTicketType={addTicketType}
                deleteTicketType={deleteTicketType}
                switchModal={switchModal}
                ticketTypes={ticketTypes}
              />
          
          case 'event_link':
            return <SharedLink eventId={event.id} />
          
          default:
            return <CreateEvent
            addEvent={addEvent}
            switchModal={switchModal}
          />
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
    deleteTicketType: (id) => {dispatch(deleteTicketType(id))},
    switchModal: (modal) => {dispatch(switchModal(modal))}
})

export default connect(mapStateToProps, mapDispatchToProps)(ModalContainer)
