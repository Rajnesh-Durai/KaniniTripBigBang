import React, { useState, useEffect } from 'react';
import gallery from '../../Assets/low-angle-shot-mesmerizing-starry-sky.jpg';
import './BookNow.css';
import { MDBInput } from 'mdb-react-ui-kit';
import axios from 'axios';



const BookNow = () => {
  const [totalNumber, setTotalNumber] = useState(1); // Default to 1 person
  const [totalAmount, setTotalAmount] = useState(30000);
  const [startDate, setStartDate] = useState('');
  const [endDate, setEndDate] = useState('');
  const [selectedPack, setSelectedPack] = useState({
    packageId: 1,
    userEmail: '',
    startDate: '',
    endDate: '',
    totalCount: '',
    totalPrice: '',
    status: true,
  });

  const handleTotalNumberChange = (event) => {
    const inputNumber = event.target.value;
    const amount = 30000 * parseInt(inputNumber, 10);
    setTotalNumber(inputNumber);
    setTotalAmount(isNaN(amount) ? '' : amount);

    // Fill selectedPack state
    setSelectedPack({
      ...selectedPack,
      startDate: startDate,
      endDate: endDate,
      totalCount: inputNumber,
      totalPrice: amount,
    });
  };

  const handleEmailChange = (event) => {
    const email = event.target.value;
    // Fill selectedPack state with the email value
    setSelectedPack({
      ...selectedPack,
      userEmail: email,
    });
  };


  useEffect(() => {
    // Calculate and update the end date based on the start date and total number of days
    if (startDate) {
      const numberOfDays = parseInt(3, 10);
      const newEndDate = new Date(startDate);
      newEndDate.setDate(newEndDate.getDate() + numberOfDays);
      setEndDate(newEndDate.toISOString().slice(0, 10));

      // Fill selectedPack state
      setSelectedPack({
        ...selectedPack,
        startDate: startDate,
        endDate: newEndDate.toISOString().slice(0, 10),
      });
    } else {
      setEndDate('');

      // Clear selectedPack state
      setSelectedPack({
        packageId: 1,
        userEmail: '',
        startDate: '',
        endDate: '',
        totalCount: '',
        totalPrice: '',
        status: true,
      });
    }
  }, [startDate, totalNumber]);

  // Function to handle form submission
  const handleSubmit = () => {
    // Do something with the selectedPack data, e.g., send it to the server
    console.log(selectedPack);
    axios.post('https://localhost:7026/UserSide/BookingAPackage', selectedPack)
    .then((response) => {
      // Handle successful response from the server
      console.log('Data successfully sent to the server:', response.data);
    })
    .catch((error) => {
      // Handle error
      console.error('Error while sending data to the server:', error);
    });
  };

  return (
    <div>
      <div>
        <img src={gallery} className='gallery-img' alt='Gallery' />
      </div>
      <div className='book-head'>BOOK NOW</div>
      <div className='container mt-5'>
        <div className='booknow-box'>
          <MDBInput label='Email' id='typeText' type='text' className='mt-3 mb-4' onChange={handleEmailChange}/>
          <div>
            <div>
              <h5>Start Date</h5>
              <input type='date' className='mb-4 date-input' value={startDate} onChange={(e) => setStartDate(e.target.value)}></input>
            </div>
            <div>
              <h5>End Date</h5>
              <input type='date' className='mb-4 date-input' value={endDate} disabled></input>
            </div>
          </div>
          <div>
            <MDBInput label='Total Number of Person' id='typeText' type='number' onChange={handleTotalNumberChange} />
          </div>
          <br /><br />
          {typeof totalAmount === 'number' && (
            <div>
              Total Amount: <span className='location-name'>Rs.{totalAmount}</span>/ package
            </div>
          )}
          {/* Submit button */}
          <button className='btn btn-primary mt-3 upload-cancel' onClick={handleSubmit}>Submit</button>
        </div>
      </div>
    </div>
  );
};

export default BookNow;
