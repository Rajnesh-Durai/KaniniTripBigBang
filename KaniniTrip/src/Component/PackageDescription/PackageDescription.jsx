import React, { useEffect, useState } from 'react';
import gallery from '../../Assets/10064337_48470.jpg'
import axios from 'axios';
import {
    MDBCard,
    MDBCardImage,
    MDBCardBody,
    MDBCardTitle,
    MDBCardText,
    MDBRow,
    MDBCol,
    MDBIcon
  } from 'mdb-react-ui-kit';
import './PackageDescription.css'


const PackageDescription = () => {
    const [packagesdesc,setPackageDesc]=useState([])
    useEffect(() => {
        // Fetch carousel data using axios and update the state
        const fetchCarouselData = async () => {
            try {
                const response = await axios.get('https://localhost:7026/UserSide/GetPackage?locationId=1');
                console.log(response.data);
                setPackageDesc(response.data); // Assuming the API response contains the data for carousel items
            } catch (error) {
                console.error(error);
            }
        };

        fetchCarouselData();
    }, []);
    return (
        <div>
            <div>
                <img src={gallery} className='gallery-img' />
            </div>
            <div className='gallery-head3'>PACKAGE DETAILS</div>

            <div className='container'>
                <br></br><br></br><br></br><br></br><br /><br />
                <div>
                    <h3 className='package-heading'>Best Offered Packages</h3>
                </div>
                <div>
                <MDBRow className='row-cols-1 row-cols-md-3 g-4'>
            {packagesdesc.map((packageData,index) => (
              <MDBCol key={packageData.id}>
                <MDBCard className='h-100 card-location'>
                  <MDBCardImage
                    src={`data:image/jpeg;base64,${packageData.imageName}`} // Replace with the actual image source from the API response
                    alt={`Image ${index + 1}`}
                    position='top'
                    className='card-image'
                  />
                  <MDBCardBody className='location-body'>
                   
                    <MDBCardTitle className='package-name'>{packageData.packageName}</MDBCardTitle>
                    <MDBCardText><span className='location-price'>{packageData.iternary}</span></MDBCardText>
                    <div className='flex-packageDetails'>
                        <div className='mb-3'>
                            <div className='position-center'><MDBIcon fas icon="hotel" /></div>
                            <div>{packageData.noOfHotel} Hotels</div>
                        </div>
                        <div>
                            <div className='position-center'><MDBIcon fas icon="skiing" /></div>
                            <div>{packageData.noOfSpot} Activities</div>
                        </div>
                        <div>
                            <div className='position-center'><MDBIcon fas icon="car-side" /></div>
                            <div>{packageData.noOfVehicle} Vehicles</div>
                        </div>
                    </div>
                    <div className='price-flex'>
                        <div>No of days: &nbsp;<span className='location-price'>{packageData.totalDays}</span></div>
                        <div>
                            Rs.<span className='location-price'>{packageData.pricePerPerson}</span>/ Person
                        </div>
                    </div>
                  </MDBCardBody>
                </MDBCard>
              </MDBCol>
            ))}
          </MDBRow>
                    <br></br><br></br><br></br><br></br>
                </div>
            </div>
        </div>
    )
}

export default PackageDescription
