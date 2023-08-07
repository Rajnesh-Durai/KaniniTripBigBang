// import React, { useEffect, useState } from 'react'
// import packageimg from '../../Assets/agrap2.jpg';
// import axios from 'axios';
// import './Package.css'
// import {
//     MDBCard,
//     MDBCardImage,
//     MDBCardBody,
//     MDBCardTitle,
//     MDBCardText,
//     MDBRow,
//     MDBCol
//   } from 'mdb-react-ui-kit';

// const Package = () => {
//     const [packages,setPackage]=useState([])
//     useEffect(() => {
//         // Fetch carousel data using axios and update the state
//         const fetchCarouselData = async () => {
//             try {
//                 const response = await axios.get('https://localhost:7026/UserSide/DisplayingAllLocations');
//                 console.log(response.data);
//                 setPackage(response.data); // Assuming the API response contains the data for carousel items
//             } catch (error) {
//                 console.error(error);
//             }
//         };

//         fetchCarouselData();
//     }, []);
//     return (
//         <>
//             <div>
//                 <div>
//                     <img src={packageimg} className='gallery-img' />
//                 </div>
//                 <div className='package-head'>PACKAGES</div>

//             </div>

//             <div className='container'>
//                 <br></br><br></br><br></br><br></br><br /><br />
//                 <div>
//                     <h3 className='package-heading'>Best Offered Packages</h3>
//                 </div>
//                 <div>
//                 <MDBRow className='row-cols-1 row-cols-md-3 g-4'>
//             {packages.map((packageData,index) => (
//               <MDBCol key={packageData.id}>
//                 <MDBCard className='h-100 card-location'>
//                   <MDBCardImage
//                     src={`data:image/jpeg;base64,${packageData.imageName}`} // Replace with the actual image source from the API response
//                     alt={`Image ${index + 1}`}
//                     position='top'
//                     className='card-image'
//                   />
//                   <MDBCardBody className='location-body'>
//                     <MDBCardTitle className='location-name'>{packageData.locationName}</MDBCardTitle>
//                     <MDBCardText>Starts at Rs.<span className='location-price'>{packageData.packStarts}</span>/ Person</MDBCardText>
//                   </MDBCardBody>
//                 </MDBCard>
//               </MDBCol>
//             ))}
//           </MDBRow>
//                     <br></br><br></br><br></br><br></br>
//                 </div>
//             </div>
//         </>

//     )
// }

// export default Package
import React, { useEffect, useState } from 'react';
import packageimg from '../../Assets/agrap2.jpg';
import axios from 'axios';
import './Package.css';
import {
  MDBCard,
  MDBCardImage,
  MDBCardBody,
  MDBCardTitle,
  MDBCardText,
  MDBRow,
  MDBCol,
} from 'mdb-react-ui-kit';
import { Link } from 'react-router-dom';

const Package = () => {
  const [packages, setPackages] = useState([]);
  const [searchQuery, setSearchQuery] = useState('');

  useEffect(() => {
  
    // Fetch carousel data using axios and update the state
    const fetchCarouselData = async () => {
      try {
        const response = await axios.get('https://localhost:7026/UserSide/DisplayingAllLocations');
        console.log(response.data);
        setPackages(response.data); // Assuming the API response contains the data for carousel items
      } catch (error) {
        console.error(error);
      }
    };

    fetchCarouselData();
  }, []);

  const handleSearchChange = (e) => {
    setSearchQuery(e.target.value);
  };

  // Filter the packages based on the search query
  const filteredPackages = packages.filter((packageData) =>
    packageData.locationName.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <>
      <div>
        <div>
          <img src={packageimg} className='gallery-img' alt='Gallery' />
        </div>
        <div className='package-head'>PACKAGES</div>
      </div>
      <div className='search-box'>
        {/* Search bar */}
        <input
          type='text'
          placeholder='Search by location name...'
          value={searchQuery}
          onChange={handleSearchChange}
          className='search-bar'
        />
      </div>

      <div className='container'>
        <br /><br /><br /><br /><br /><br /><br />
        <div>
          <h3 className='package-heading'>Best Offered Packages</h3>
        </div>
        <div>
        
          <MDBRow className='row-cols-1 row-cols-md-3 g-4'>
            {filteredPackages.map((packageData, index) => (
              <MDBCol key={packageData.id}>
                <Link to={`/location/package/${packageData.locationId}`}>
                <MDBCard className='h-100 card-location'>
                  <MDBCardImage
                    src={`data:image/jpeg;base64,${packageData.imageName}`} // Replace with the actual image source from the API response
                    alt={`Image ${index + 1}`}
                    position='top'
                    className='card-image'
                  />
                  <MDBCardBody className='location-body'>
                    <MDBCardTitle className='location-name'>{packageData.locationName}</MDBCardTitle>
                    <MDBCardText>Starts at Rs.<span className='location-price'>{packageData.packStarts}</span>/ Person</MDBCardText>
                  </MDBCardBody>
                </MDBCard>
                </Link>
              </MDBCol>
            ))}
          </MDBRow>
          <br /><br /><br /><br />
        </div>
      </div>
    </>
  );
};

export default Package;
