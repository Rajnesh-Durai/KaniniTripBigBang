import React, { useEffect, useState } from 'react'
import styled from 'styled-components';
import { ComposableMap, Geographies, Geography, Marker, Annotation } from "react-simple-maps";
import "./MapComponent.css";
import { MDBIcon } from 'mdb-react-ui-kit';
import Footer from '../Footer';

const Section = styled.div`
height:115vh;
display: flex;
flex-direction:column;
align-items: center;
justify-content: center;
scroll-snap-align:center;
background-color:#fff;
`;

const MapContainer = styled.div`

`;

const Section2 = styled.div`
  height: 0vh;
  scroll-snap-align:center;
`;



const MapComponent = () => {
  const [showPopup, setShowPopup] = useState(false);
  const locations = [
    {
      name: "Kerala",
      coordinates: [76.2711, 10.8505],
      markerOffset: -15,
    },
    {
      name: "Goa",
      coordinates: [74.124, 15.2993],
      markerOffset: -15,
    },
    {
      name: "Delhi",
      coordinates: [77.2090, 28.6139],
      markerOffset: 25,
    },
    {
      name: "Kolkata",
      coordinates: [88.3639, 22.5726],
      markerOffset: 25,
    },
    // Add more locations here
  ];


  return (
    <>

      <Section className='sectmap'>
        <h1 className='travelhead' >Travel Across India</h1><br></br><br></br>
        <h3 className='travelbody'>We have Agents across India to accompany with your safe travels.</h3><br></br><br></br>
        <h3 className='travelbody2'>Cherish and Enjoy your travel with us</h3>
        <div className="map" id="map-section" >
          <MapContainer className='mapCon'>
            <ComposableMap
              projection="geoMercator"
              projectionConfig={{
                scale: 800,
                center: [82, 22], // Adjust center coordinates to focus on India
              }}
              className='compMap'
              // style={{ height: '452px', width: '725px' }}
            >

              <Geographies geography="india.json">
                {({ geographies }) =>
                  geographies.map((geo) => (
                    <Geography key={geo.rsmKey} geography={geo}  stroke="black"
                    fill={geo.properties.CONTINENT === 'Asia' ? '#fff' : '#C0C0C0'}
                     />
                  ))
                }
              </Geographies>
              {locations.map((location, index) => (
                <Marker key={index} coordinates={location.coordinates}>
                  <g
                    fill="blue"
                    stroke="#ff5533"
                    strokeWidth="0"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    transform="translate(-13, 0)"
                    fontSize="2" // Adjust font size
                    color="blue" // Change color
                    outline="none"
                    className='marker'
                  >
                    {/* <PlaceIcon/> */}
                    <MDBIcon fas icon="map-marker-alt" />
                    <circle cx="7.5" cy="6" r="1.5"  /> 
                    <path d="M12 2C6.48 2 2 6.48 2 12a9.957 9.957 0 0 0 7.2 9.54c.65.133 1.04-.283 1.24-.54.2-.267.05-.64-.233-.89-.65-.52-1.04-1.25-1.04-2.1 0-1.54 1.11-2.79 2.5-2.79 1.65 0 2.5 1.54 2.5 2.79 0 .85-.39 1.58-1.03 2.1-.28.25-.44.62-.24.91.2.27.62.66 1.22.54A9.957 9.957 0 0 0 22 12c0-5.52-4.48-10-10-10z" /> 
                  </g>
                  <text
                    textAnchor="middle"
                    y={location.markerOffset}
                    style={{ fontFamily: 'Manrope', fill: 'black', fontSize: '14px' }}
                  >
                    {location.name}
                  </text>
                </Marker>
              ))}
            </ComposableMap>

            {/* <p className='service'>Services we are into: </p> */}
          </MapContainer>

        </div>
        <div className='ipad'>
          <MDBIcon fas icon="stop-circle" />
        </div>

      </Section>
      <Section2>
        <Footer/>
      </Section2>
    </>

  )
}

export default MapComponent
