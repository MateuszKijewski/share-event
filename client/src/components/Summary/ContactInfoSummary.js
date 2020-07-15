import React from 'react'

function contactInfoSummary({contactInfo: {firstName, lastName, email, phoneNumber}}) {
    return (
        <div>
            <h4>{firstName}</h4>
            <h4 className={'mt-2'}>{lastName}</h4>
            <h4 className={'mt-2'}>{email}</h4>
            <h4 className={'mt-2'}>{phoneNumber}</h4>
        </div>        
    )
}

export default contactInfoSummary
