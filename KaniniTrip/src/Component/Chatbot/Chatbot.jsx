import React, { useState } from 'react';
import Kanini from '../../Assets/logo.png';
import './Chatbot.css';
import ChatMessage from './ChatMessage';
import { analyze } from './Utility';

const Chatbot = () => {
  const [message, setMessage] = useState([
    {
      message: 'Hi, May I have your name?',
    },
  ]);

  const [text, setText] = useState('');
  const [initialResponsesDisplayed, setInitialResponsesDisplayed] = useState(false);

  const onSend = () => {
    let list = [...message, { message: text, user: true }];
    if (!initialResponsesDisplayed) {
      // Display the initial responses first
      list = [
        ...list,
        {
          message: `Hi, ${text}`,
        },
        {
          message: `Hi, Which State you are looking for your Trip??`,
        },
      ];
      setInitialResponsesDisplayed(true);
    } else {
      // Handle user queries after initial responses are displayed
      const reply = analyze(text);
      list = [...list, { message: reply }];
    }

    setMessage(list);
    setText('');
  // Check if the element exists before scrolling
  const copyrightElement = document.querySelector('#copyright');
  if (copyrightElement) {
    setTimeout(() => {
      copyrightElement.scrollIntoView();
    },500);
  }
};

  return (
    <div className='chat'>
      <div className='align'>
        <img src={Kanini} className='kanini' alt='Kanini' />
      </div>
      <div className='chat-message'>
        {message.length > 0 && message.map((data, index) => <ChatMessage key={index} {...data} />)}
        <div className='send-container'>
          <input type='search' className='search' value={text} onChange={(e) => setText(e.target.value)} />
          <button className='send' onClick={onSend}>
            Send
          </button>
        </div>
      </div>
    </div>
  );
};

export default Chatbot;
