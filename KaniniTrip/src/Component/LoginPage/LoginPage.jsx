import React, { useState } from 'react'
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './LoginPage.css';
import LoginImage from '../../Assets/11235651_10862.jpg';
import axios from 'axios';
import { MDBIcon, MDBSpinner } from 'mdb-react-ui-kit';
import { MDBModal, MDBModalDialog, MDBModalContent, MDBModalBody } from 'mdb-react-ui-kit';



const LoginPage = () => {

    const [userDTO, setUserDTO] = useState({
        username: '',
        password: ''
    });
    const [errors, setErrors] = useState({});
    const [isValid, setIsValid] = useState(false);
    const [bottomModal, setBottomModal] = useState(false);
    // Handle password change and mask it with asterisks
    const handlePasswordChange = (event) => {
        let value = event.target.value;


        // Check if data is being pasted
        if (event.clipboardData && event.clipboardData.getData) {
            value = event.clipboardData.getData('Text');

        }

        setPassword(value);

        setIsValid(validatePassword(value));
    };

    const validatePassword = (value) => {
        const minLength = 8;
        let isValid = true;
        const newErrors = {};

        if (!value) {
            newErrors.password = 'Password is required';
            isValid = false;
        } else if (value.length < minLength) {
            newErrors.password = `Password must be at least ${minLength} characters long`;
            isValid = false;
        }
        setErrors(newErrors);
        return isValid;
    };

    const maskPassword = (value) => {
        return "*".repeat(value.length);
    };
    // Validate email and password
    const validateForm = () => {
        const newErrors = {};
        let isValid = true;
        //Password validation
        if (!password) {
            newErrors.password = 'Password is required';
            isValid = false;
        }
        setErrors(newErrors);
        return isValid;
    };
    // Handle form submission
    const handleSubmit = (e) => {
        e.preventDefault();
        if (validateForm()) {
            // Form submission logic goes here
        }
    };
    const logindata = async () => {


        console.log(userDTO)

        // fetch(`https://localhost:7190/api/Owner/authenticate`,{
        //   method:"POST",
        //   headers:{
        //     "Content-Type":"application/json",
        //   },
        //   body:JSON.stringify(loginuser),
        // })
        // .then(response => {
        //   if (response ===200) {
        //     console.log("Login Successfully"); 
        //   }
        //   return response.json();
        // })
        // .catch(error=>{
        //   console.error("login error in:",error);
        // })
        try {
            const response = await axios.post('https://localhost:7026/api/Auth/LogIN', userDTO);
            console.log('Response:', response.data); // You can handle the response data as needed
            // Perform any actions you need with the response data here
            setBottomModal(true)
            setTimeout(() => {
                setBottomModal(false);
              }, 3000);
              console.log('Moved to the next page');
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <>
            <div className='containers'>
                <div className='spliting'>
                    <div className='split2'>
                        <div>
                            <img src={LoginImage} className='image'></img>
                        </div>
                        <div className='member'>
                            Already not a member? Register Here
                        </div>
                    </div>
                    <div className='split1'>
                        <div className='heading'>
                            Sign In
                        </div>
                        <div>

                            {/* UserName */}
                            <div className='flex'>
                                <div><MDBIcon fas icon="user-circle" size='lg' /></div>
                                <div>
                                    <input
                                        type="text"
                                        className="input"
                                        placeholder='Your User Name'
                                        onChange={(event) => setUserDTO({ ...userDTO, username: event.target.value })} />
                                </div>
                            </div>
                            <hr></hr>
                            <br />
                            {/* Display email validation error if it exists */}
                            {errors.name && <span className="error">{errors.name}</span>}
                            {/* Password */}
                            <div className='flex'>
                                <div><MDBIcon fas icon="fingerprint" size='lg' /></div>
                                <div>
                                    <input
                                        type="password"
                                        className="input"
                                        placeholder='Your Password'
                                        onChange={(event) => setUserDTO({ ...userDTO, password: event.target.value })}
                                    />
                                </div>
                            </div>
                            <hr></hr>
                            <br />
                            {/* Display password validation error if it exists */}
                            {errors.password && <span className="error">{errors.password}</span>}
                            {isValid && <p>Password is valid</p>}
                            <br></br>
                            <div><button className='butn' onClick={logindata}>Login</button></div>
                        </div>
                    </div>

                </div>
            </div>

      {/* Displaying the loader inside the transparent modal when bottomModal is true */}
      <MDBModal className='position3' animationDirection='bottom' show={bottomModal} tabIndex='-1' setShow={setBottomModal}>
        <MDBModalDialog  frame>
          <MDBModalContent className='transparent-modal'>
            <MDBModalBody className='py-1'>
              <div className='d-flex justify-content-center align-items-center my-3'>
                <MDBSpinner className='mx-2' color='primary' show={bottomModal} setShow={setBottomModal}>
                  <span className='visually-hidden'>Loading...</span>
                </MDBSpinner>
              </div>
            </MDBModalBody>
          </MDBModalContent>
        </MDBModalDialog>
      </MDBModal>

        </>

    )
}

export default LoginPage
