import React from 'react';
import styled from 'styled-components';
import './WhoComponent.css';
import image1 from '../../../Assets/image1.jpg';
import image2 from '../../../Assets/image2.jpg';
import image3 from '../../../Assets/image3.jpg';
import image4 from '../../../Assets/image4.jpg';

const Section = styled.div`
  height: 115vh;
  background-color:#d4e6fa;
  scroll-snap-align: center;
  overflow: hidden;
`;

const ParallaxContainer = styled.div`
  display: flex;
  flex-direction: column;
  height: 100vh;
  overflow-y: auto;
`;

const ParallaxImage = styled.div`
  height: 100vh;
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center;
  transition: transform 0.3s ease-out;
  background-color: pink;
`;

const TextOverlay = styled.div`
  position: absolute;
  top: 50%; /* Adjust to vertically center the text */
  left: 50%; /* Adjust to horizontally center the text */
  transform: translate(-50%, -50%);
  color: white;
  font-size: 32px;
  width:100%;
  text-align:center;
  font-weight: 800;
  font-family:'Manrope';
  transition: transform 0.3s ease-out;
  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5); /* Optional: Add a text shadow for better readability */

  &:hover {
    font-size:38px;
  }
`;

const WhoComponent = () => {
  const parallaxData = [
    {
      imageUrl: image1,
      parallaxSpeed: 1,
      text: `DISCOVER INDIA'S RICH HERITAGE AND CULTURE`,
    },
    {
      imageUrl: image2,
      parallaxSpeed: 2,
      text: 'CREATE MEMORIES OF A LIFETIME WITH A JOURNEY THROUGH INDIA',
    },
    {
      imageUrl: image3,
      parallaxSpeed: 3,
      text: 'PLACES THAT REALLY FANTASIZE YOU',
    },
    {
      imageUrl: image4,
      parallaxSpeed: 4,
      text: `IMMERSE YOURSELF IN INDIA'S COLORFUL FESTIVALS`,
    },
  ];

  return (
    <Section>
      <ParallaxContainer>
        {parallaxData.map((item, index) => (
          <ParallaxImage
            key={index}
            style={{
              backgroundImage: `url("${item.imageUrl}")`,
              transform: `translateY(${window.scrollY / item.parallaxSpeed}px)`,
            }}
          >
            <TextOverlay>{item.text}</TextOverlay>
          </ParallaxImage>
        ))}
      </ParallaxContainer>
    </Section>
  );
};

export default WhoComponent;
