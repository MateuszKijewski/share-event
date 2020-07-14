import React from 'react'
import { connect } from 'react-redux'
import CreateEvent from './Event/CreateEvent'
import CreateTicketTypes from './Event/CreateTicketTypes'
import SharedLink from './Event/SharedLink'
import { addEvent, addTicketType, switchModal, deleteTicketType, apiCreateEvent } from '../redux/actions'

function ModalContainer({event, visibleModal, ticketTypes, addEvent, addTicketType, deleteTicketType, switchModal, apiCreateEvent, apiResponses}) {
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
                event={event}
                apiCreateEvent={apiCreateEvent}
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
        ticketTypes: state.ticketTypeReducer.ticketTypes,
        apiResponses: state.apiCreateEventReducer.apiResponses
    }
}

const mapDispatchToProps = (dispatch) => ({
    addEvent: (eventData) => {dispatch(addEvent(eventData))},
    addTicketType: (ticketTypeData) => {dispatch(addTicketType(ticketTypeData))},
    deleteTicketType: (id) => {dispatch(deleteTicketType(id))},
    switchModal: (modal) => {dispatch(switchModal(modal))},
    apiCreateEvent: (eventData, ticketTypeArray) => {dispatch(apiCreateEvent(eventData, ticketTypeArray))}
})

export default connect(mapStateToProps, mapDispatchToProps)(ModalContainer)
