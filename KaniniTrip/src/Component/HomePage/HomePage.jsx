import React, { useEffect, useState } from 'react';
import axios from 'axios';
import HeaderComponent from './HeaderComponent/HeaderComponent';
import WhoComponent from './WhoComponent/WhoComponent';
import MapComponent from './MapComponent/MapComponent';
import styled from 'styled-components';
import './HomePage.css'
import Footer from './Footer';


const Container = styled.div`
height:115vh;
scroll-snap-type: y mandatory;
scroll-behaviour:smooth;
overflow-y:auto;
color:black;
scrollbar-width:none;
-ms-overflow-style: none; /* For Microsoft Edge */
&::-webkit-scrollbar{
  display:none;
}
`;


const HomePage = () => {

  const [carouselItems, setCarouselItems] = useState([]);

  // useEffect(() => {
  //   // Assuming you have an API endpoint that returns image data from the database
  //   axios.get('/api/images')
  //     .then(response => {
  //       // Assuming the API response contains an array of image objects
  //       setCarouselItems(response.data);
  //     })
  //     .catch(error => {
  //       console.error('Error fetching images:', error);
  //     });
  // }, []);

  return (
    <Container>
      {/* <MDBCarousel showIndicators showControls fade>
      {carouselItems.map((item, index) => (
        <MDBCarouselItem
          key={index}
          className='w-100 d-block'
          itemId={index + 1}
          src={item.imageUrl}
          alt='...'
        >
          <h5>{item.title}</h5>
          <p>{item.description}</p>
        </MDBCarouselItem>
      ))}
    </MDBCarousel> */}


      <HeaderComponent/>
      <WhoComponent />
      <MapComponent />
      {/* <Footer/> */}
    </Container>
  )
}

export default HomePage
