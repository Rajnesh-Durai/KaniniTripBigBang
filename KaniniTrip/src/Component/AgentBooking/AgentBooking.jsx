import React, { useState, useEffect } from 'react';
import gallery from '../../Assets/low-angle-shot-mesmerizing-starry-sky.jpg';
import { MDBInput } from 'mdb-react-ui-kit';
import axios from 'axios';
import './AgentBooking.css'



const AgentBooking = () => {

    const [location, setLocation] = useState([]);
    const [selectedValue, setSelectedValue] = useState('');
    const [iselectedValue, setISelectedValue] = useState('');
    const [iselectedValue2, setISelectedValue2] = useState([]);
    const [numDays, setNumDays] = useState(1); // Initialize with 1 day
    const [spot, setSpot] = useState([]);
    const [hotel, setHotel] = useState([]);
    const [selectedSpots, setSelectedSpots] = useState(Array.from({ length: numDays }, () => ''));
    const [selectedHotels, setSelectedHotels] = useState(Array.from({ length: numDays }, () => ''));
    const [selectedHotel, setSelectedHotel] = useState('');
    const [selectedPack, setSelectedPack] = useState({
        userId:6,
        locationId: 0,
        packageName: '',
        packageImage:null,//file
        imageName: '',//file-name
        iternary: '',
        pricePerPerson: 0,
        numberOfDays: 0,
        personLimit: 0,
    });
    const [dayschedule, setDaySchedule] = useState({ packageId: 0, daywise: 1, hotelName: '', spotName: '', vehicleName: '' });

    const [isOpen, setIsOpen] = useState(false)


    useEffect(() => {
        const fetchCarouselData = async () => {
            try {
                const response = await axios.get('https://localhost:7026/UserSide/DisplayingAllLocations');
                console.log(response.data);
                setLocation(response.data); // Assuming the API response contains the data for carousel items
            } catch (error) {
                console.error(error);
            }
        };

        fetchCarouselData();
    }, []);

    const handleChange = (event) => {
        console.log(event.target.value);
        setISelectedValue(event.target.value)
        fetchLocationName(event.target.value);
        const uncheckedDeptName = location.find((dept) => dept.locationName === event.target.value).locationId;
        setSelectedPack({
            ...selectedPack,
            locationId: uncheckedDeptName,
          });
    };

    const handlePackageName = (event) => {
        console.log(event.target.value);
        setSelectedPack({
            ...selectedPack,
            packageName: event.target.value,
          });
    };

    const handlePrice = (event) => {
        console.log(event.target.value);
        const price = parseInt(event.target.value, 10);
        setSelectedPack({
            ...selectedPack,
            pricePerPerson: price,
          });
    };

    const handleIternary = (event) => {
        console.log(event.target.value);
        setSelectedPack({
            ...selectedPack,
            iternary: event.target.value,
          });
    };

    const handlePersonLimit = (event) => {
        console.log(event.target.value);
        const price = parseInt(event.target.value, 10);
        setSelectedPack({
            ...selectedPack,
            personLimit: price,
          });
    };
    
    const [getSpot, setSpotselect] = useState('')
// Getting spot name in array for each day
    const [spotArray,setSpotArray]=useState([])
    const [hotelArray,setHotelArray]=useState([])
    const [vehicleArray,setVehicleArray]=useState([])


    const handleChange2 = async (event, dayIndex) => {
        const spotN = event.target.value;
        // setSelectedSpots((prevSpots) => {
        //     const newSpots = [...prevSpots];
        //     newSpots[dayIndex] = spotName;
        //     return newSpots;
        // });
        // setDaySchedule((prevSchedule) => {
        //     const updatedSchedule = [...prevSchedule];
        //     updatedSchedule[dayIndex].spotName = spotName;
        //     return updatedSchedule;
        //   });
        setDaySchedule({
            ...dayschedule,
            spotName: spotN,
          });

          setSpotArray((prevSpot) => {
            const updatedSpotArray = [...prevSpot];
            updatedSpotArray[dayIndex] = spotN;
            return updatedSpotArray;
          });

        // setSpotselect((prevHotel) => [...prevHotel, ...event.target.value])
        fetchHotelName(spotN, dayIndex); // Pass the dayIndex to identify the selected day
    };
const [hotels,setHotels]=useState('')
const handleHotelChange = (event, dayIndex) => {
    const hotelNames = event.target.value;
    // setSelectedHotels((prevHotels) => {
    //   const newHotels = [...prevHotels];
    //   newHotels[dayIndex] = hotelNames;
    //   return newHotels;
    // });
    setDaySchedule({
        ...dayschedule,
        hotelName: event.target.value,
      });

      setHotelArray((prevSpot) => {
        const updatedSpotArray = [...prevSpot];
        updatedSpotArray[dayIndex] = event.target.value;
        return updatedSpotArray;
      });

    setHotels((prevHotels) => [...prevHotels, hotelNames]);
  };
    const [getvehicle, setVehicle] = useState('')
    const handleVehicleNameChange = (event, dayIndex) => {
        const vehicleNames = event.target.value;
        // setDaySchedule((prevSchedule) => {
        //   const updatedSchedule = [...prevSchedule];
        //   updatedSchedule[dayIndex].vehicleName = vehicleName;
        //   return updatedSchedule;
        // });
        setDaySchedule({
            ...dayschedule,
            vehicleName: vehicleNames,
          });

          setVehicleArray((prevSpot) => {
            const updatedSpotArray = [...prevSpot];
            updatedSpotArray[dayIndex] = vehicleNames;
            return updatedSpotArray;
          });

        setVehicle((prevHotel) => [...prevHotel, ...event.target.value])
    };

    useEffect(() => {
        setSelectedHotel(''); // Reset selected hotel whenever the selected spot changes
    }, [selectedSpots]);

    const fetchLocationName = async (placeName) => {

        // GetSpots in that Locations
        try {
            const uncheckedDeptName = location.find((dept) => dept.locationName === placeName).locationId;
            console.log(uncheckedDeptName);
            const response = await axios.get(`https://localhost:7026/AgentSide/GetSpotNameById?locationId=${uncheckedDeptName}`);
            console.log(response.data);
            setSpot(response.data); // Assuming the API response contains the data for carousel items
        } catch (error) {
            console.error(error);
        }
    };

    const fetchHotelName = async (spotName, dayIndex) => {
        try {
            const uncheckedDeptName = spot.find((dept) => dept.spotName === spotName).id;
            console.log(uncheckedDeptName);
            const response = await axios.get(`https://localhost:7026/AgentSide/GetHotelNameBySpotId?locationId=${uncheckedDeptName}`);
            console.log(response.data);
            // Get the array of hotels for the selected spot
            const hotelsForSpot = response.data.map((item) => item.hotelName);

            setSelectedHotels((prevHotels) => {
                const newHotels = [...prevHotels];
                newHotels[dayIndex] = hotelsForSpot[0] || ''; // Set the selected hotel for the specific day to the first hotel for the spot
                return newHotels;
            });
            // Update the hotel state with the fetched hotels
            setHotel((prevHotel) => [...prevHotel, ...response.data]);
        } catch (error) {
            console.error(error);
        }
    };

    const PostPackage = () => {

        // userId:6,
        // locationId: 0,
        // packageName: '',
        // packageImage:null,//file
        // imageName: '',//file-name
        // iternary: '',
        // pricePerPerson: 0,
        // numberOfDays: 0,
        // personLimit: 0,

        const formData = new FormData();
        formData.append('userId', selectedPack.userId);
        formData.append('packageName', selectedPack.packageName);
        formData.append('iternary', selectedPack.iternary);
        formData.append('imageName', selectedPack.imageName);
        formData.append('packageImage', selectedPack.packageImage);
        formData.append('locationId', selectedPack.locationId);
        formData.append('pricePerPerson', selectedPack.pricePerPerson);
        formData.append('numberOfDays', selectedPack.numberOfDays);
        formData.append('personLimit', selectedPack.personLimit);
        console.log(formData)
        // Do something with the selectedPack data, e.g., send it to the server
        console.log(selectedPack);
        axios.post('https://localhost:7026/UserSide/PostPackage', formData, {
            headers: {
            },
          })
            .then((response) => {
                // Handle successful response from the server
                console.log('Data successfully sent to the server:', response.data);
            })
            .catch((error) => {
                // Handle error
                console.error('Error while sending data to the server:', error);
            });
        setIsOpen(true)
    }

    const handlePost = async () => {
        try {
            const response = await axios.get('https://localhost:7026/UserSide/DisplayingAllLocations');
            const lengthItem = response.data.length;
    
            // Update the packageId property in daySchedule with the new lengthItem
            setDaySchedule((prevSchedule) => ({
                ...prevSchedule,
                packageId: lengthItem,
            }));

            for (let i = 0; i < numDays; i++) {
                // console.log(mail);
                // const id = mail[i];
                const dayschedule = {
                    packageId: 17,
                     daywise: i+1, 
                     hotelName: hotelArray[i], 
                     spotName: spotArray[i], 
                     vehicleName: vehicleArray[i]
                };
    
            console.log(dayschedule);
            console.log('spotarray',spotArray);
            console.log('hotelarray',hotelArray);
            console.log('vehicleArray',vehicleArray);
            // Send the POST request with the updated daySchedule
             const postResponse = await axios.post('https://localhost:7026/AgentSide/GetHotelNameBySpotId', dayschedule);
            console.log('Data successfully sent to the server:', postResponse.data);
            }
        } catch (error) {
            console.error('Error while fetching or sending data:', error);
        }
    }

    // const [numDays, setNumDays] = useState(1); // Initialize with 1 day

    const handleNumDaysChange = (event) => {
        setNumDays(parseInt(event.target.value, 10));
        const price = parseInt(event.target.value, 10);
        setSelectedPack({
            ...selectedPack,
            numberOfDays: price,
          });
    };

    const handleImageChange = (e) => {
        const file = e.target.files[0];
        const reader = new FileReader();
        setSelectedPack({
            ...selectedPack,
            packageImage: file,
            imageName: file.name
          });
        if (file) {
            reader.readAsDataURL(file);
            // setImageFileName(file.name);
            // Update formValues with the new data
            
          }
    };

    return (
        <div>
            <div>
                <img src={gallery} className='gallery-img' alt='Gallery' />
            </div>
            <div className='book-head'>ADD PACKAGE</div>

            <div className='container mt-5'>
                <div className='booknow-box'>
                    <h3 className='mt-3 text-center' >ADDING PACKAGE</h3>
                    <select className='increase-width mt-5 mb-3' value={iselectedValue} onChange={handleChange}>
                        <option value="">Select a Location</option>
                        {location.map((item) => (
                            <option key={item.id} value={item.locationName}>
                                {item.locationName}
                            </option>
                        ))}
                    </select>
                    <div>
                        <MDBInput className='mb-3' label='Package Name' id='typeText' type='text' onChange={handlePackageName} />
                    </div>

                    <div>
                        <MDBInput className='mb-3' label='' id='typeText' type='file' onChange={handleImageChange}  />
                    </div>
                    <div>
                        <MDBInput className='mb-3' label='Iternary' id='typeText' type='text'onChange={handleIternary} />
                    </div>
                    <div>
                        <MDBInput className='mb-3' label='Number of Days'
                            value={numDays}
                           
                            onChange={handleNumDaysChange} id='typeText' type='number' />
                    </div>
                    <div>
                        <MDBInput className='mb-3' label='Price Per Person' id='typeText' type='number' onChange={handlePrice}/>
                    </div>
                    <div>
                        <MDBInput className='mb-3' label='Person Limit' id='typeText' type='number' onChange={handlePersonLimit}/>
                    </div>

                    {/* Submit button */}
                    <button className='btn btn-primary mt-3 upload-cancel' onClick={PostPackage}>Submit</button>
                </div>
            </div>

            {/* Second Box */}
            {isOpen && (
                <div className='container mt-5'>
                    <div className='booknow-box'>
                        <h3 className='mt-3 text-center'>ADDING DAY SCHEDULES</h3>
                        {/* BELOW FORM SHOULD REPEAT BASED ON NUMBER OF DAYS CHOSEN */}
                        {Array.from({ length: numDays }).map((_, dayIndex) => (
                            <div key={dayIndex}>
                                <h3 className='mt-5 mb-3'>Day: {dayIndex + 1}</h3>
                                <select
                                    className='increase-width mb-3'
                                    onChange={(event) => handleChange2(event, dayIndex)}
                                >
                                    <option value=''>Select a Spot Name</option>
                                    {spot.map((item) => (
                                        <option key={item.id} value={item.spotName}>
                                            {item.spotName}
                                        </option>
                                    ))}
                                </select>

                                <div>
                                    <select
                                        className='increase-width mb-3'
                                        onChange={(event) => handleHotelChange(event, dayIndex)}
                                    >
                                        <option value=''>Select a Hotel</option>
                                        {hotel.map((item) => (
                                            <option key={item.id} value={item.hotelName}>
                                                {item.hotelName}
                                            </option>
                                        ))}
                                    </select>
                                </div>

                                <div>
                                    <MDBInput className='mb-3' label='Vehicle to Provide' id='typeText' type='text' onChange={(event) => handleVehicleNameChange(event, dayIndex)} />
                                </div>
                            </div>
                        ))}
                        {/* Submit button */}
                        <button className='btn btn-primary mt-3 upload-cancel' onClick={handlePost}>Submit</button>
                    </div>
                </div>
            )}

        </div>

    )
}

export default AgentBooking
