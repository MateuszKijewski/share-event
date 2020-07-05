import React from 'react'
import { GENERATE_LINK } from '../redux/actionTypes'

function SharedLink({eventId}) {
    const getLink = () => (
        `${window.location.origin}/${eventId}`
    )

    return (
        <div className={'container w-75 mt-5'}>
            <div className={"card mb-2"}>
			<div className={"card-header text-center"}><b>Spread the word!</b></div>
			<div className={'card-body'}>
                <h2 className={'text-center'} style={{color: '#207bd6'}}>{getLink()}</h2>
			</div>
            <div className={'card-footer text-muted text-center'}>3/3</div>
		    </div>
        </div>
    )
}

export default SharedLink
