import React, { useState, useEffect } from 'react';
import gallery from '../../Assets/low-angle-shot-mesmerizing-starry-sky.jpg';
import './ContactUs.css';
import { MDBInput } from 'mdb-react-ui-kit';
import axios from 'axios';

const ContactUs = () => {
  return (
    <div>
      <div>
        <img src={gallery} className='gallery-img' alt='Gallery' />
      </div>
      <div className='book-head'>BOOK NOW</div>
    </div>
  )
}

export default ContactUs
