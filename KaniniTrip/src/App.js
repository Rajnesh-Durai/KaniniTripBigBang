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
import Error from './Component/Error/Error';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { useParams } from 'react-router-dom';



function App() {

  const [showChatbot, setShowChatbot] = useState(false);

  const toggleChatbot = () => {
    setShowChatbot((prevState) => !prevState);
  };

  // Retrieve the 'role' from sessionStorage
  const userRole = sessionStorage.getItem('role');

  return (
    <>
      <link href="https://fonts.googleapis.com/css2?family=Manrope:wght@200;300;400;500;600;700;800&display=swap" rel="stylesheet"></link>
      <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.1/css/all.css" crossorigin="anonymous"></link>
      {/* <!-- Add this link to your HTML file --> */}
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />


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
      {/* <ContactUs/> */}

      {/* <ToastContainer/> */}
      {/* ChatBot */}

      <div>

        <button className='chatbot-icon' onClick={toggleChatbot}>
          {/* Add your chatbot icon here (e.g., an icon or an image) */}
          <img src={Logo}></img>
        </button>

        {showChatbot && <Chatbot />}
      </div>



      <BrowserRouter>
        <Navbar />
        <Routes>
          {/* <Route exact path='/' element={<HomePage />} />
          <Route path='login' element={<LoginPage />} />
          <Route path='userRegister' element={<UserRegister />} />
          <Route path='agentRegister' element={<AgencyRegister />} />
          <Route path='contact' element={<ContactUs />} />
          <Route path='location' element={<Package />} >
            <Route path='package/:id/*' element={<PackageDescription />} >
              <Route path='dayschedule' element={<DaySchedule />} >
                <Route path='book' element={<BookNow />} />
              </Route>
            </Route>
          </Route>
          <Route path='request' element={<RequestReceived />} />
          <Route path='packageupload' element={<AgentBooking />} />
          <Route path='gallery' element={<ImageGallery />} /> */}
          <Route exact path='/' element={<HomePage />} />
          <Route path='/login' element={(userRole !== 'Admin' && userRole !=='Agent' && userRole !=='User') ?<LoginPage />:<Error/>} />
          <Route path='/userRegister' element={(userRole !== 'Admin' && userRole !=='Agent' && userRole !=='User') ?<UserRegister />:<Error/>} />
          <Route path='/agentRegister' element={(userRole !== 'Admin' && userRole !=='Agent' && userRole !=='User') ?<AgencyRegister />:<Error/>} />
          <Route path='/contact' element={(userRole === 'Admin' || userRole ==='User'|| userRole===null) ?<ContactUs />:<Error/>} />
          {/* <Route path='/location' element={<Package />} />
          <Route path='/package/:locationId' element={<PackageDescription />} />
          <Route path='/dayschedule/:packageId' element={<DaySchedule />} />
          <Route path='/book' element={<BookNow />} /> */}

          {/* Nested route for /location */}
          <Route path='/location/*' element={(userRole === 'Admin' || userRole ==='User' || userRole===null) ?<LocationPage />:<Error/>} />

          <Route path='/request' element={( userRole==='Admin') ?<RequestReceived />:<Error/>} />
          <Route path='/packageupload' element={(userRole ==='Agent') ?<AgentBooking />:<Error/>} />
          <Route path='/gallery' element={( userRole==='Admin') ?<ImageGallery />:<Error/>} />
          <Route path='*' element={<Error />} />
        </Routes>
        <Footer />
      </BrowserRouter>

    </>
  );
}

export default App;


// The parent component for the /location route
const LocationPage = () => {
  const { locationId } = useParams();//passed value from previous component
  return (
    <>
      <Routes>
        <Route index element={<Package />} />

        <Route path='package/:locationId/*' element={<PackageDescription />}/>
          {/* /location/package/:locationId will render PackageDescription */}
          
          <Route path='package/:locationId/dayschedule/:packageId/*' element={<DaySchedule />} />
          {/* /location/package/:locationId/dayschedule/:packageId will render DaySchedule */}
          
          <Route path='package/:locationId/dayschedule/:packageId/book' element={<BookNow />} />
          
      </Routes>
      {/* Your component for /location */}

    </>
  );
};