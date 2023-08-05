import React, { useState } from 'react';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './AgencyRegister.css';
import { MDBIcon } from 'mdb-react-ui-kit';
import { MDBModal, MDBModalDialog, MDBModalContent, MDBModalBody } from 'mdb-react-ui-kit';


const AgencyRegister = () => {
  const [userDTO, setUserDTO] = useState({
    name: '',
    username: '',
    agencyName:'',
    userPassword: '',
    isActive: false,
    email: '',
    role: 'Agent',
    phoneNumber: 0,
    age:0,
    yearsOfExperience: 0
});
  const [success, setSuccess] = useState(false);
  const [errors, setErrors] = useState({
    name: '',
    userPassword: '',
    email: '',
    phoneNumber: '',
  });

  const [bottomModal, setBottomModal] = useState(false);


  const validateEmail = (email) => {
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
  };

  const validatePassword = (password) => {
    // Password regex pattern: At least one uppercase, one lowercase, one number, and one special character
    const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return passwordRegex.test(password);
  };

  const validatePhoneNumber = (phoneNumber) => {
    return /^\d{0,10}$/.test(phoneNumber);
  };

  const register = () => {
    const newErrors = {
      name:
        userDTO.name.trim() === ''
          ? 'Name is required'
          : userDTO.name.trim().length < 5 || userDTO.name.trim().length > 20
            ? 'Name must be between 5 and 20 characters'
            : '',
      email: userDTO.email.trim() === '' ? 'Email is required' : validateEmail(userDTO.email) ? '' : 'Invalid email',
      phoneNumber:
        userDTO.phoneNumber.trim() === ''
          ? 'Phone number is required'
          : !validatePhoneNumber(userDTO.phoneNumber)
            ? 'Invalid phone number (only numbers allowed, max 14 digits)'
            : '',
      userPassword:
        userDTO.userPassword.trim() === ''
          ? 'Password is required'
          : validatePassword(userDTO.userPassword)
            ? ''
            : 'Password must contain at least one uppercase, one lowercase, one number, and one special character',
    };

    setErrors(newErrors);

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
          toast.error('Registration failed!');
        });
    }
  };


  return (
    <div className="bgImage">
      <div className='containers2'>
        <div className='split'>
          <div className='spliter1'>
            <div className='head'>Sign Up</div>
            <div>
              {/* 1st Row */}
              <div className='flex justify-content-between'>
                <div className='width'>
                  <div className='flex'>
                    <div>
                      <MDBIcon fas icon="user" size='lg' />
                    </div>
                    <div>
                      <input
                        type='text'
                        className='input'
                        onChange={(event) => setUserDTO({ ...userDTO, name: event.target.value })}
                        placeholder='Your Name'
                      />
                      {errors.name && <span className='error'>{errors.name}</span>}
                    </div>
                  </div>
                  <hr></hr>
                </div>

                <div className='width'>
                  <div className='flex'>
                    <div>
                      <MDBIcon fas icon="user-circle" size='lg' />
                    </div>
                    <div>
                      <input
                        type='text'
                        className='input'
                        onChange={(event) => setUserDTO({ ...userDTO, username: event.target.value })}
                        placeholder='Your User Name'
                      />
                      {errors.username && <span className='error'>{errors.username}</span>}
                    </div>
                  </div>
                  <hr></hr>
                </div>
              </div>

              <div className='flex justify-content-between'>
                <div className='width'>
                  <div className='flex'>
                    <div>
                      <MDBIcon fas icon="building" size='lg' />
                    </div>
                    <div>
                      <input
                        type='email'
                        className='input'
                        placeholder='Your Agency Name'
                        onChange={(event) => setUserDTO({ ...userDTO, agencyName: event.target.value })}
                      />
                      {errors.agencyName && <span className='error'>{errors.agencyName}</span>}
                    </div>
                  </div>
                  <hr></hr>
                </div>
                <div className='width'>
                  <div className='flex'>
                    <div>
                      <MDBIcon fas icon="envelope" size='lg' />
                    </div>
                    <div>
                      <input
                        type='email'
                        className='input'
                        placeholder='Your Email'
                        onChange={(event) => setUserDTO({ ...userDTO, email: event.target.value })}
                      />
                      {errors.email && <span className='error'>{errors.email}</span>}
                    </div>
                  </div>
                  <hr></hr>
                </div>
              </div>

              <div className='flex justify-content-between'>
                <div className='width'>
                  <div className='flex'>
                    <div>
                      <MDBIcon fas icon="phone-alt" size='lg' />
                    </div>
                    <div>
                      <input
                        type='tel'
                        className='input'
                        placeholder='Your Phone Number'
                        onChange={(event) => setUserDTO({ ...userDTO, phoneNumber: event.target.value })}
                      />
                      {errors.phoneNumber && <span className='error'>{errors.phoneNumber}</span>}
                    </div>
                  </div>
                  <hr></hr>
                </div>
                <div className='width'>
                  <div className='flex'>
                    <div>
                      <MDBIcon fas icon="address-card" size='lg' />
                    </div>
                    <div>
                      <input
                        type='tel'
                        className='input'
                        placeholder='Your Age'
                        onChange={(event) => setUserDTO({ ...userDTO, age: event.target.value })}
                      />
                      {errors.age && <span className='error'>{errors.age}</span>}
                    </div>
                  </div>
                  <hr></hr>
                </div>
              </div>

              <div className='flex justify-content-between'>
                <div className='width'>
                  <div className='flex'>
                    <div>
                      <MDBIcon fas icon="award" size='lg' />
                    </div>
                    <div>
                      <input
                        type='tel'
                        className='input'
                        placeholder='Your Experience'
                        onChange={(event) => setUserDTO({ ...userDTO, yearsOfExperience: event.target.value })}
                      />
                      {errors.yearsOfExperience && <span className='error'>{errors.yearsOfExperience}</span>}
                    </div>
                  </div>
                  <hr></hr>

                </div>
                <div className='width'>
                  <div className='flex'>
                    <div>
                      <MDBIcon fas icon="fingerprint" size='lg' />
                    </div>
                    <div>
                      <input
                        type='password'
                        className='input'
                        placeholder='Your Password'
                        onChange={(event) => setUserDTO({ ...userDTO, userPassword: event.target.value })}
                      />
                      {errors.userPassword && <span className='error'>{errors.userPassword}</span>}
                    </div>
                  </div>
                  <hr></hr>

                </div>
              </div>

              <div className='flex justify-content-between mt-5'>
                <div >
                  <div className='member'>Already a member? Sign In Here</div>
                </div>
                <div >
                  <div>
                    <button className='butn' onClick={register}>
                      Register
                    </button>
                    <br></br>
                    <br></br>
                  </div>

                </div>
              </div>

            </div>
          </div>
        </div>
      </div>
      <br></br>
      {/* Displaying the MDBModal when bottomModal is true */}
      <MDBModal className='position2' animationDirection='bottom' show={bottomModal} tabIndex='-1' setShow={setBottomModal}>
        <MDBModalDialog position='bottom' frame>
          <MDBModalContent className='success-modal2'>
            <MDBModalBody className='py-1'>
              <div className='d-flex justify-content-center align-items-center my-3'>
                <p className='mb-0'>Registered Successfully &nbsp;<MDBIcon far icon="smile-beam" />!! &nbsp; Wait for Admin Approval</p>
              </div>
            </MDBModalBody>
          </MDBModalContent>
        </MDBModalDialog>
      </MDBModal>
    </div>

  );
};

export default AgencyRegister;
