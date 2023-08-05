import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { MDBCarousel, MDBCarouselItem } from 'mdb-react-ui-kit';
import Maldives from '../../../Assets/maldives-island.jpg';
import beach from '../../../Assets/beautiful-tropical-beach-sea.jpg'
import coast from '../../../Assets/coast-idyllic-sand-relax-vacation.jpg'


const Section=styled.div`
height:100vh;
scroll-snap-align:center;
`;

const HeaderComponent = () => {
 

  return (
    <Section>
      
      <MDBCarousel showIndicators showControls={false} dealy={10} fade className='CarousalWidth' dark  style={{ height: '100vh' }}>
        <MDBCarouselItem
          className='w-100 d-block'
          itemId={1}
          src={Maldives}
          alt='...'
          style={{height:'100vh',width:'100%'}}
        >
          <h2>First slide label</h2>
          <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
        </MDBCarouselItem>

        <MDBCarouselItem
          className='w-100 d-block '
          itemId={2}
          src={coast}
          alt='...'
          style={{height:'100vh',width:'100%'}}
        >
          <h5>Second slide label</h5>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        </MDBCarouselItem>

        <MDBCarouselItem
          className='w-100 d-block'
          itemId={3}
          src={beach}
          alt='...'
          style={{height:'100vh',width:'100%'}}
        >
          <h5>Third slide label</h5>
          <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
        </MDBCarouselItem>
      </MDBCarousel>

    </Section>
  )
}

export default HeaderComponent
