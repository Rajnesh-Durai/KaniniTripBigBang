import React, { useState, useEffect } from 'react';
import axios from 'axios';
import gallery from '../../Assets/image4.jpg'
import './ImageGallery.css'
import { MDBRow, MDBCol } from 'mdb-react-ui-kit';
import {
    MDBBtn,
    MDBModal,
    MDBModalDialog,
    MDBModalContent,
    MDBModalHeader,
    MDBModalTitle,
    MDBModalBody,
    MDBModalFooter, MDBInput
} from 'mdb-react-ui-kit';

const ImageGallery = () => {

    const [carouselData, setCarouselData] = useState([]);
    const [staticModal, setStaticModal] = useState(false);
    // const [selectedImage, setSelectedImage] = useState(null);
    const [imageFileName, setImageFileName] = useState('');
    const [formValues, setFormValues] = useState({
        name: '',
        description: '',
        hotelImage: null,
        imageName:''
      });

  
    // const handleUpload = async () => {
    //   if (!selectedImage) {
    //     console.log('Please select an image first');
    //     return;
    //   }
  
    //   try {
    //     const formData = new FormData();
    //     formData.append('imageName', imageFileName);
  
    //     // Add the other form fields to the formData
    //     formData.append('name', imageName);
    //     formData.append('description', imageDescription);
    //     console.log(formData)
    //     // Replace 'https://localhost:7038/api/Package/image' with your actual API endpoint for image upload
    //     await axios.post('https://localhost:7026/AdminSide/UploadImage', formData, {
    //       headers: {
    //         'Content-Type': 'multipart/form-data',
    //       },
    //     });
  
    //     // The image is successfully uploaded, do something (e.g., close the modal, update the UI, etc.)
    //     console.log('Image uploaded successfully');
    //     toggleShow(); // Assuming you have a function called toggleShow to close the modal
    //   } catch (error) {
    //     console.error('Error uploading image:', error);
    //   }
    // };

    const handleUpload = async () => {
        if (!selectedImage) {
          console.log('Please select an image first');
          return;
        }
    
        try {
          const formData = new FormData();
          formData.append('name', formValues.name);
          formData.append('description', formValues.description);
          formData.append('hotelImage', formValues.hotelImage);
          formData.append('imageName', formValues.imageName);
          console.log(formValues)
    
          // Replace 'https://localhost:7026/AdminSide/UploadImage' with your actual API endpoint for image upload
          await axios.post('https://localhost:7026/AdminSide/UploadImage', formData, {
            headers: {
            },
          });
    
          // The image is successfully uploaded, do something (e.g., close the modal, update the UI, etc.)
          console.log('Image uploaded successfully');
          toggleShow(); // Assuming you have a function called toggleShow to close the modal
        window.location.reload()
        } catch (error) {
          console.error('Error uploading image:', error);
        }
      };
    


    const toggleShow = () => setStaticModal(!staticModal);


    useEffect(() => {
        // Fetch carousel data using axios and update the state
        const fetchCarouselData = async () => {
            try {
                const response = await axios.get('https://localhost:7026/UserSide/GetDashboardImage');
                console.log(response.data);
                setCarouselData(response.data); // Assuming the API response contains the data for carousel items
            } catch (error) {
                console.error(error);
            }
        };

        fetchCarouselData();
    }, []);

    const [selectedImage, setSelectedImage] = useState(null);

    const handleImageChange = (e) => {
        const file = e.target.files[0];
        const reader = new FileReader();

        reader.onloadend = () => {
            setSelectedImage(reader.result);
        };

        if (file) {
            reader.readAsDataURL(file);
            // setImageFileName(file.name);
            // Update formValues with the new data
            setFormValues({
              ...formValues,
              hotelImage: file,
              imageName: file.name
            });
          }
    };

    const handleInputChange = (e) => {
        const names = e.target.value;
        // Update formValues with the new data
        setFormValues({
          ...formValues,
          name: names,
        });
      };
      const handleDescChange = (e) => {
        const descriptiond = e.target.value;
        // Update formValues with the new data
        setFormValues({
          ...formValues,
          description: descriptiond,
        });
      };

    return (
        <div>
            <div>
                <img src={gallery} className='gallery-img' />
            </div>
            <div className='gallery-head'>IMAGE GALLERY</div>
            <div className='gallery-add' onClick={toggleShow}>
                ADD IMAGE
            </div>
            <div className='bg-image'>
                <div className='container'>
                    <br></br><br></br>
                    <MDBRow className='row-cols-1 row-cols-md-3 g-4'>
                        {carouselData.map((item, index) => (
                            <MDBCol key={index} className='colum'>
                                <img
                                    src={`data:image/jpeg;base64,${item.imageName}`}
                                    alt={`Image ${index + 1}`}
                                    style={{ width: '100%', height: 'auto', borderRadius: '25px' }}
                                />
                                <h2 className='image-name'>{item.name}</h2>
                                <p>{item.description}</p>
                            </MDBCol>
                        ))}
                    </MDBRow>
                    <br></br><br></br><br></br><br></br>
                </div>
            </div>
            {/* Popper */}
            <MDBModal className='modal3' staticBackdrop tabIndex='-1' show={staticModal} setShow={setStaticModal}>
                <MDBModalDialog>
                    <MDBModalContent className='adding-image'>
                        <MDBModalHeader>
                            <MDBModalTitle>Adding Image</MDBModalTitle>
                            <MDBBtn className='btn-close' color='none' onClick={toggleShow}></MDBBtn>
                        </MDBModalHeader>
                        <MDBModalBody>
                            <div className='modal-seperation'>
                                <div className='modal-part1'>
                                    <MDBInput label='Place Name' id='typeText' type='text' name='name' value={formValues.name} onChange={handleInputChange} /><br></br>
                                    <MDBInput label='Description' id='typeText' type='text' value={formValues.description} onChange={handleDescChange}/><br></br>
                                    <MDBInput label='' id='typeText' type='file' onChange={handleImageChange} /><br></br>
                                </div>
                                <div className='modal-part2'>
                                    {selectedImage && <img src={selectedImage} className='selected-image' alt='Selected' />}
                                </div>
                            </div>
                        </MDBModalBody>
                        <MDBModalFooter>
                            <MDBBtn className='upload-cancel' color='secondary' onClick={toggleShow}>
                                Close
                            </MDBBtn>
                            <MDBBtn className='upload-cancel' color='primary' onClick={handleUpload}>Upload</MDBBtn>
                        </MDBModalFooter>
                    </MDBModalContent>
                </MDBModalDialog>
            </MDBModal>
        </div>
    )
}

export default ImageGallery
