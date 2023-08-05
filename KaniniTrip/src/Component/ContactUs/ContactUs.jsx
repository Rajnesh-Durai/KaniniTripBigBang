import React, { useState, useEffect } from 'react';
import gallery from '../../Assets/9135878_45239.jpg';
import userImage from '../../Assets/user.png'
import './ContactUs.css';
import { MDBInput } from 'mdb-react-ui-kit';
import axios from 'axios';
import {
  MDBCard,
  MDBCardImage,
  MDBCardBody,
  MDBCardTitle,
  MDBCardText, MDBTextArea, MDBIcon
} from 'mdb-react-ui-kit';


const ContactUs = () => {
  const [admin, setAdmin] = useState([])
  useEffect(() => {
    // Fetch carousel data using axios and update the state
    const fetchCarouselData = async () => {
      try {
        const response = await axios.get('https://localhost:7026/UserSide/GetAdmin');
        console.log(response.data);
        setAdmin(response.data); // Assuming the API response contains the data for carousel items
      } catch (error) {
        console.error(error);
      }
    };

    fetchCarouselData();
  }, []);
  return (
    <div>
      <div>
        <img src={gallery} className='gallery-img' alt='Gallery' />
      </div>
      <div className='book-head'>CONTACT US</div>
      <div className='container mt-5 margin-auto'>
        <br /><br /><br />
        <h2 className='textalign-cnter'>Contact Details</h2><br /><br />
        <MDBCard className='h-100 widthof-card'>
          <MDBCardImage
            src={userImage} // Replace with the actual image source from the API response
            position='top'
            className='cardof-image'
          />
          <MDBCardBody className='location-body'>
            <MDBCardTitle className='location-name'>{admin.name}</MDBCardTitle>
            <MDBCardText><span className='location-price'>Email: <b>{admin.email}</b></span></MDBCardText>
            <MDBCardText><span className='location-price'>Phone Number: <b>{admin.phoneNumber}</b></span></MDBCardText>
          </MDBCardBody>
        </MDBCard>
        <br /><br /><br />
        <div>
          <h3 className='mt-2 mb-5 textFeed'>FeedBack Form</h3>
          <MDBCard className='h-100 widthof-feed mb-5'>

            <MDBCardBody className='location-body'>

              <MDBCardText>Comments</MDBCardText>
              <MDBTextArea label='Comment' id='textAreaExample' rows={4} />
              {/* Add star rating here */}
              <MDBCardText>Rate Our Service</MDBCardText>
              <select className='increase-width  mb-3' >
                <option value="">Select a Value</option>
                <option value="5">Awesome &nbsp;<span><MDBIcon far icon="grin-hearts" size="1x" /></span></option>
                <option value="4">Very Good &nbsp;<MDBIcon far icon="grin-beam" size="1x" /></option>
                <option value="3">Good &nbsp;<MDBIcon far icon="grin-alt" size="1x" /></option>
                <option value="2">Fair &nbsp;<MDBIcon far icon="grin-beam-sweat" size="1x" /></option>
                <option value="1">Poor &nbsp;<MDBIcon far icon="smile" size="1x" /></option>
              </select>
              <button className='btn btn-primary mt-3 upload-cancel' >Submit</button>

            </MDBCardBody>
          </MDBCard>
        </div>
      </div>
    </div>
  )
}

export default ContactUs
