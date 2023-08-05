import React, { useState } from 'react';
import { MDBBtn, MDBContainer } from 'mdb-react-ui-kit';
import LoginPage from './Component/LoginPage/LoginPage';
import AgencyRegister from './Component/RegisterPage/AgencyRegister/AgencyRegister';
import UserRegister from './Component/RegisterPage/UserRegister/UserRegister';
import HomePage from './Component/HomePage/HomePage'
import Chatbot from './Component/Chatbot/Chatbot'
import Logo from '../src/Assets/logo-s.png';
import Navbar from './Component/NavBar/NavBar'
import Footer from './Component/Footer/Footer';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import ImageGallery from './Component/ImageGallery/ImageGallery';
import Package from './Component/Package/Package';
import RequestReceived from './Component/RequestReceived/RequestReceived';
import PackageDescription from './Component/PackageDescription/PackageDescription';
import DaySchedule from './Component/DaySchedule/DaySchedule';
import BookNow from './Component/BookNow/BookNow';
import AgentBooking from './Component/AgentBooking/AgentBooking';
import ContactUs from './Component/ContactUs/ContactUs';



function App() {

  const [showChatbot, setShowChatbot] = useState(false);

  const toggleChatbot = () => {
    setShowChatbot((prevState) => !prevState);
  };
  return (
    <>
      <link href="https://fonts.googleapis.com/css2?family=Manrope:wght@200;300;400;500;600;700;800&display=swap" rel="stylesheet"></link>
      <Navbar />
      {/* <LoginPage/> */}
      {/* <AgencyRegister/> */}
      {/* <UserRegister/> */}
      {/* <HomePage/> */}
      {/* <ImageGallery/> */}
      {/* <Package/> */}
      {/* <RequestReceived /> */}
      {/* <DaySchedule/> */}
      {/* <BookNow/> */}
      {/* <PackageDescription/> */}
      {/* <AgentBooking/> */}
      <ContactUs/>
      <Footer />
      {/* <ToastContainer/> */}
      {/* ChatBot */}

      <div>

        <button className='chatbot-icon' onClick={toggleChatbot}>
          {/* Add your chatbot icon here (e.g., an icon or an image) */}
          <img src={Logo}></img>
        </button>

        {showChatbot && <Chatbot />}
      </div>
    </>
  );
}

export default App;
