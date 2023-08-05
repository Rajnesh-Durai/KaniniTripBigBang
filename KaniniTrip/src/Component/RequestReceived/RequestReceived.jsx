import { MDBIcon, MDBModal, MDBModalDialog, MDBModalContent, MDBModalBody, MDBTable, MDBTableHead, MDBTableBody } from 'mdb-react-ui-kit';
import React, { useEffect, useState } from 'react';
import gallery from '../../Assets/flower.jpg'
import axios from 'axios';
import './RequestReceived.css'
const RequestReceived = () => {
    const [request, setRequest] = useState([]);

    useEffect(() => {
        // Fetch request data using axios and update the state
        const fetchRequestData = async () => {
            try {
                const response = await axios.get('https://localhost:7026/AdminSide/GetAllRequest');
                console.log(response.data);
                setRequest(response.data); // Assuming the API response contains the data for requests
            } catch (error) {
                console.error(error);
            }
        };

        fetchRequestData();
    }, []);

    const handleAccept = async (id, name) => {
        try {
            console.log(name);
            const response = await axios.put(`https://localhost:7026/AdminSide/AgentAccepetance?userId=${id}`, { name: name,isActive:true });
            console.log(response.data);
            window.location.reload()
        } catch (error) {
            console.error(error);
        }
    };

    const handleReject = async (id) => {
        try {
            const response = await axios.delete(`https://localhost:7026/AdminSide/RejectAgentAccepetance?userId=${id}`);
            console.log(response.data);

            window.location.reload()
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div>
            <div>
                <img src={gallery} className='gallery-img' />
            </div>
            <div className='gallery-head3'>REQUEST RECEIVED</div>
            <div className="container">
            {request.length === 0 ? (
          // If request.length is 0, show the following div with a message
          <div className='no-requests'>
            No requests available.
          </div>
        ) : (
          // If requests are available, display the table
                <MDBTable align='middle'>
                    <MDBTableHead className='back-color'>
                        <tr>
                            <th scope='col'>Name</th>
                            <th scope='col'>Agency Name</th>
                            <th scope='col'>Age</th>
                            <th scope='col'>Experience</th>
                            <th scope='col'>Email-Id</th>
                            <th scope='col'>Phone Number</th>
                            <th scope='col'>Decision</th>
                        </tr>
                    </MDBTableHead>
                    <MDBTableBody>
                        {request.map((item, index) => (
                            <tr key={index}>
                                <td className='table-data'>{item.name}</td>
                                <td className='table-data'>{item.agencyName}</td>
                                <td className='table-data'>{item.age}</td>
                                <td className='table-data'>{item.yearsOfExperience}</td>
                                <td className='table-data'>{item.email}</td>
                                <td className='table-data'>{item.phoneNumber}</td>
                                <td>
                                    <div className='flex-table'>
                                        <div onClick={() => handleAccept(item.id, item.name)}><MDBIcon far icon="check-circle" className='move-right' color='success' size='2x' /></div>
                                        <div onClick={() => handleReject(item.id)}><MDBIcon far icon="times-circle" color='danger' size='2x' /></div>
                                    </div>
                                </td>
                            </tr>
                        ))}
                    </MDBTableBody>
                </MDBTable>)}
            </div>
           
        </div>
    );
};

export default RequestReceived;
