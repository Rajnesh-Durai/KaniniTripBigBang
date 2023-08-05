import React from 'react'
import './ChatMessage.css'
import { MDBIcon } from 'mdb-react-ui-kit';

const ChatMessage = (props) => {
    return (
        <div>
            {
                props.user ? (
                    <span className='message-right'>
                        <span className='message-text'>{props.message}</span>
                        <MDBIcon fas icon="user-circle" />
                    </span>
                ) : (
                    <span className='message-left'>
                         <MDBIcon fas icon="robot" />
                        <span className='message-text'>{props.message}</span>
                       
                    </span>
                )
            }
        </div>
    )
}

export default ChatMessage
