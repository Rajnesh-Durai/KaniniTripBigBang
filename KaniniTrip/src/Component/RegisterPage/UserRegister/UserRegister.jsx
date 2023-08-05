import React, { useState } from 'react';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './UserRegister.css';
import LoginImage from '../../../Assets/10606146_9800.jpg';
import { MDBIcon } from 'mdb-react-ui-kit';
import { MDBModal, MDBModalDialog, MDBModalContent, MDBModalBody } from 'mdb-react-ui-kit';

const UserRegister = () => {
    const [userDTO, setUserDTO] = useState({
        name: '',
        username: '',
        userPassword: '',
        isActive: true,
        email: '',
        role: 'User',
        phoneNumber: 0
    });
    const [success, setSuccess] = useState(false);
    const [errors, setErrors] = useState({
        name: '',
        email: '',
        username: '',
        phoneNumber: '',
        userPassword: ''
    });
    const [bottomModal, setBottomModal] = useState(false);
    const [bottomModal2, setBottomModal2] = useState(false);
    const validateEmail = (email) => {
        // Very basic email validation
        return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
    };

    const validatePassword = (userPassword) => {
        // Password regex pattern: At least one uppercase, one lowercase, one number, and one special character
        const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
        return passwordRegex.test(userPassword);
    };

    const validatePhoneNumber = (phoneNumber) => {
        return /^\d{0,10}$/.test(phoneNumber);
    };

    const register = () => {
        const newErrors = {
            firstName:
                userDTO.name.trim() === ''
                    ? 'First name is required'
                    : userDTO.name.trim().length < 5 || userDTO.name.trim().length > 20
                        ? 'First name must be between 5 and 20 characters'
                        : '',
            email: userDTO.email.trim() === '' ? 'Email is required' : validateEmail(userDTO.email) ? '' : 'Invalid email',
            phoneNumber:
                userDTO.phoneNumber.trim() === ''
                    ? 'Phone number is required'
                    : !validatePhoneNumber(userDTO.phoneNumber)
                        ? 'Invalid phone number (only numbers allowed, max 10 digits)'
                        : '',
            password:
                userDTO.userPassword.trim() === ''
                    ? 'Password is required'
                    : validatePassword(userDTO.userPassword)
                        ? ''
                        : 'Password must contain at least one uppercase, one lowercase, one number, and one special character',
        };

        setErrors(newErrors);

        console.log(userDTO);

        if (Object.values(newErrors).every((error) => error === '')) {
            console.log(userDTO);
            fetch('https://localhost:7026/api/Auth/Register', {
                method: 'POST',
                headers: {
                    accept: 'text/plain',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(userDTO),
            })
                .then(async (data) => {
                    if (data.status === 201) {
                        var user = await data.json();
                        setSuccess(true);
                        console.log('Registered successfully!');
                        setBottomModal(true);
                        console.log(bottomModal)
                    }
                })
                .catch((error) => {
                    console.error('Error:', error);
                    setBottomModal2(true);
                    toast.error('Registration failed!');
                });
        }
    };

    return (
        <>
            <div className='containers'>
                <div className='splituser'>
                    <div className='split11'>
                        <div className='head'>Sign Up</div>
                        <div>
                            {/* Name */}
                            <div className='flex'>
                                <div>
                                    <MDBIcon fas icon="user" size='lg' />
                                </div>
                                <div>
                                    <input
                                        type='text'
                                        className='input1'
                                        onChange={(event) => setUserDTO({ ...userDTO, name: event.target.value })}
                                        placeholder='Your Name'
                                    />
                                </div>
                            </div>
                            <hr></hr>
                            {errors.name && <span className='error'>{errors.name}</span>}

                            {/* UserName */}
                            <div className='flex'>
                                <div>
                                    <MDBIcon fas icon="user-circle" size='lg' />
                                </div>
                                <div>
                                    <input
                                        type='text'
                                        className='input1'
                                        placeholder='Your User Name'
                                        onChange={(event) => setUserDTO({ ...userDTO, username: event.target.value })}
                                    />
                                </div>
                            </div>
                            <hr></hr>
                            {errors.username && <span className='error'>{errors.username}</span>}

                            {/* Email */}
                            <div className='flex'>
                                <div>
                                    <MDBIcon fas icon="envelope" size='lg' />
                                </div>
                                <div>
                                    <input
                                        type='email'
                                        className='input1'
                                        placeholder='Your Email'
                                        onChange={(event) => setUserDTO({ ...userDTO, email: event.target.value })}
                                    />
                                </div>
                            </div>
                            <hr></hr>
                            {errors.email && <span className='error'>{errors.email}</span>}

                            {/* Phone Number */}
                            <div className='flex'>
                                <div>
                                    <MDBIcon fas icon="phone-alt" size='lg' />
                                </div>
                                <div>
                                    <input
                                        type='number'
                                        className='input1'
                                        placeholder='Your Phone Number'
                                        onChange={(event) => setUserDTO({ ...userDTO, phoneNumber: event.target.value })}
                                    />
                                </div>
                            </div>
                            <hr></hr>
                            {errors.phoneNumber && <span className='error'>{errors.phoneNumber}</span>}

                            {/* Password */}
                            <div className='flex'>
                                <div>
                                    <MDBIcon fas icon="fingerprint" size='lg' />
                                </div>
                                <div>
                                    <input
                                        type='password'
                                        className='input1'
                                        placeholder='Your Password'
                                        onChange={(event) => setUserDTO({ ...userDTO, userPassword: event.target.value })}
                                    />

                                </div>
                            </div>
                            <hr></hr>
                            {errors.userPassword && <span className='error'>{errors.userPassword}</span>}
                            <br></br>
                            <div>
                                <button className='butn' onClick={register}>
                                    Register
                                </button>
                            </div>
                            {/* Displaying the MDBModal when bottomModal is true */}

                        </div>
                    </div>
                    <div className='split12'>
                        <div>
                            <img src={LoginImage} className='image3' alt='Login' />
                        </div>
                        <div className='member11'>Already a member? Sign In Here</div>
                    </div>
                </div>

            </div>


            {/* Displaying the MDBModal when bottomModal is true */}
            <MDBModal className='position' animationDirection='bottom' show={bottomModal} tabIndex='-1' setShow={setBottomModal}>
                <MDBModalDialog position='bottom' frame>
                    <MDBModalContent className='success-modal'>
                        <MDBModalBody className='py-1'>
                            <div className='d-flex justify-content-center align-items-center my-3'>
                                <p className='mb-0'>Registered Successfully &nbsp;<MDBIcon far icon="smile-beam" /></p>
                            </div>
                        </MDBModalBody>
                    </MDBModalContent>
                </MDBModalDialog>
            </MDBModal>

                        {/* Displaying the MDBModal when bottomModal is true */}
                        <MDBModal className='position' animationDirection='bottom' show={bottomModal2} tabIndex='-1' setShow={setBottomModal2}>
                <MDBModalDialog position='bottom' frame>
                    <MDBModalContent className='failure-modal'>
                        <MDBModalBody className='py-1'>
                            <div className='d-flex justify-content-center align-items-center my-3'>
                                <p className='mb-0'>Registered UnSuccessfully</p>
                            </div>
                        </MDBModalBody>
                    </MDBModalContent>
                </MDBModalDialog>
            </MDBModal>

        </>

    );
};

export default UserRegister;
