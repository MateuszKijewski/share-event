import React from 'react'
import { connect } from 'react-redux'


function Header({visibleModal, id}) {
    const getActive = (stepName) => {
        if (stepName === visibleModal){
            return 'md-step active'
        }
        return 'md-step'
    }

    return (     
        <div>
                <div className={"text-center"} id={"changeText"}>
                    <img src={'https://www.freelogodesign.org/file/app/client/thumb/47e3ce42-318a-475e-ad46-581d80361e48_200x200.png?1592753436649'}></img>
                    <h2><span className={"headerActionsSpan"}>Create, define, spread, share </span> your events!</h2>
                </div>
                <div className={"md-stepper-horizontal orange"}>
                    <div className={getActive('event')}>
                        <div className={"md-step-circle"}><span>1</span></div>
                        <div className={"md-step-title"}>Event</div>
                        <div className={"md-step-bar-left"}></div>
                        <div className={"md-step-bar-right"}></div>
                    </div>
                    <div className={getActive('ticket_type')}>
                        <div className={"md-step-circle"}><span>2</span></div>
                        <div className={"md-step-title"}>Tickets</div>
                        <div className={"md-step-bar-left"}></div>
                        <div className={"md-step-bar-right"}></div>
                    </div>
                    <div className={getActive('event_link')}>
                        <div className={"md-step-circle"}><span>3</span></div>
                        <div className={"md-step-title"}>Share</div>
                        <div className={"md-step-bar-left"}></div>
                        <div className={"md-step-bar-right"}></div>
                    </div>
                </div>
                {id}
        </div>
    )
}

const mapStateToProps = (state) => {
    return {
        visibleModal: state.visibleModalReducer.visibleModal,
    }
}

export default connect(mapStateToProps, null)(Header)

