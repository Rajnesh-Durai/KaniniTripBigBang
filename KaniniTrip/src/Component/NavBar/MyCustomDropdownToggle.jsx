import React from 'react';
import { MDBDropdownToggle } from 'mdb-react-ui-kit';

const MyCustomDropdownToggle = ({ children, className }) => (
  <MDBDropdownToggle className={`bg-signup ${className}`} style={{ textTransform: 'none' }}>
    {children}
  </MDBDropdownToggle>
);

export default MyCustomDropdownToggle;