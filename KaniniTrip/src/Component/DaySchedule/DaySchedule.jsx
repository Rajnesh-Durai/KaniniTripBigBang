import React, { useState, useEffect } from 'react';
import axios from 'axios';
import gallery from '../../Assets/beautiful-scenery-summit-mount-everest-covered-with-snow-white-clouds.jpg';
import {
    MDBCard,
    MDBCardTitle,
    MDBCardText,
    MDBCardBody,
    MDBCardImage,
    MDBRow,
    MDBCol, MDBBtn
} from 'mdb-react-ui-kit';
import './DaySchedule.css';
import StarRating from '../StarRating/StarRating';

const DaySchedule = () => {
    const [daywise, setDayWise] = useState([]);
    const [isSidebarOpen, setSidebarOpen] = useState(false);
    const [selectedHotel, setSelectedHotel] = useState({
        hotelName: '',
        hotelImage: '',
        bedType: '',
        hotelFeatures: '',
        mealsName: '',
    });
    useEffect(() => {
        // Fetch daywise schedule data using axios and update the state
        const fetchDaywiseData = async () => {
            try {
                const response = await axios.get('https://localhost:7026/UserSide/GetParticularPackageDetails?packageId=1');
                setDayWise(response.data); // Assuming the API response contains the data for day schedules
            } catch (error) {
                console.error(error);
            }
        };

        fetchDaywiseData();
    }, []);



    const handleSidebarToggle = (hotelName, hotelImage, bedType, hotelFeatures, mealsName) => {
        setSelectedHotel({ hotelName, hotelImage, bedType, hotelFeatures, mealsName });
        setSidebarOpen(true);
    };

    const closeSidebar = () => {
        setSidebarOpen(false);
    };

    return (
        <div>
            <div>
                <img src={gallery} className='gallery-img' alt='Gallery' />
            </div>
            <div className='gallery-head'>DAY SCHEDULE</div>
            <div className='gallery-add' >
                BOOK NOW
            </div>
            <div className="container mt-5">
                {daywise.map((item, index) => (
                    <MDBCard key={index} className='mt-5 move-up' style={{ maxWidth: '1040px' }}>
                        <MDBRow className='g-0'>
                            <MDBCol md='4'>
                                <MDBCardImage
                                    src={`data:image/jpeg;base64,${item.spotImage}`}
                                    alt={`Image ${index + 1}`}
                                    style={{ width: '200%', height: '100%', borderRadius: '0px' }}
                                    fluid
                                />
                            </MDBCol>
                            <MDBCol md='8'>
                                <MDBCardBody>
                                    <MDBCardTitle className='location-price'>Day: {item.day}</MDBCardTitle>
                                    <MDBCardText>Spot Name: {item.spotName}</MDBCardText>
                                    <MDBCardText>Spot Address: {item.spotAddress}</MDBCardText>
                                    {/* Pass item.rating to StarRating component */}
                                    <StarRating initialRatingFromApi={item.rating} />
                                    <MDBCardText>Duration :<span className='location-price'> {item.spotDuration}</span> Hrs</MDBCardText>
                                    <div className='view-hotel mb-3'>
                                        <MDBBtn className='upload-cancel' color='primary' onClick={() => handleSidebarToggle(item.hotelName, item.hotelImage, item.bedType, item.hotelFeatures, item.mealsName)}>VIEW HOTEL</MDBBtn>
                                    </div>
                                </MDBCardBody>
                            </MDBCol>
                        </MDBRow>
                    </MDBCard>
                ))}
                {isSidebarOpen && (
                    <div className={`sidenav sidenav-primary ps ps--active-y`}>
                        <>
                            <br />
                            <br />
                            <br />
                            <h1>Hotels For the Particular Day</h1>
                            <br />
                            <br />
                            <MDBCard style={{ width: '23rem' }}>
                                <MDBCardImage
                                    src={`data:image/jpeg;base64,${selectedHotel.hotelImage}`}
                                    alt={`Image`}
                                    style={{ width: '100%', height: 'auto', borderRadius: '5px' }}
                                />
                                <MDBCardBody>
                                    <MDBCardTitle>{selectedHotel.hotelName}</MDBCardTitle>
                                    <MDBCardText>Bed Type: {selectedHotel.bedType}</MDBCardText>
                                    <MDBCardText>Features: {selectedHotel.hotelFeatures}</MDBCardText>
                                    <MDBCardText>Meals: {selectedHotel.mealsName}</MDBCardText>
                                    <MDBBtn className='upload-cancel' color='secondary' onClick={closeSidebar}>
                                        Close
                                    </MDBBtn>
                                </MDBCardBody>
                            </MDBCard>
                            <br />
                            <br />
                            <br />
                            <br />
                        </>
                    </div>
                )}
            </div>

        </div>
    );
};

export default DaySchedule;
