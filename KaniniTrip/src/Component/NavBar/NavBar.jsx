import React, { useEffect, useState } from 'react';
import './NavBar.css';
import logo from '../../Assets/logo-s.png';
import { Link } from 'react-router-dom';
import { MDBDropdown, MDBDropdownMenu, MDBDropdownToggle, MDBDropdownItem } from 'mdb-react-ui-kit';
import MyCustomDropdownToggle from './MyCustomDropdownToggle';



const NavBar = () => {
  const [isDropdownOpen, setIsDropdownOpen] = useState(false);
  const [role, setRole] = useState(null);
  const [admin, setAdmin] = useState(false);
  const [userIn, setUser] = useState(false);
  const [agent, setAgent] = useState(false);
  const [nouser, setNoUser] = useState(false);
  useEffect(() => {
    // Retrieve the 'role' from sessionStorage
    const storedRole = sessionStorage.getItem('role');
    setRole(storedRole);
    if (storedRole === null) {
      setNoUser(true);
    }
    else if (storedRole === "Admin") {
      setAdmin(true);
    }
    else if (storedRole === "Agent") {
      setAgent(true);
    }
    else if (storedRole === "User") {
      setUser(true);
    }
  }, []);


  const handleDropdownClick = () => {
    setIsDropdownOpen((prevState) => !prevState);
  };

  const handleDropdownHover = (isOpen) => {
    console.log(isOpen)
    setIsDropdownOpen(isOpen);
  };

  const logoutFn = () => {
    // Remove all the stored data from sessionStorage
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('id');
    sessionStorage.removeItem('name');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('role');

    // Navigate to the home page ("/")
    window.location.href = "/";
  }

  return (
    <div className="sticky">
      <div className="img">
        <img alt="logo" src={logo} />
        <div className="curs">
          <Link className='webName' to="/">KANINI TRIP</Link>
        </div>
      </div>
      <input type="checkbox" id="nav-check" hidden />
      <nav>
        <ul>

          <>
            {
              (admin || userIn || nouser) && (
                <li>
                  <Link className='menu-items' to="/location">Holiday Package</Link>
                </li>
              )
            }{admin && (
              <li>
                <Link className='menu-items' to="/gallery">Gallery</Link>
              </li>
            )}

            {
              (admin || userIn || nouser) && (
                <li>
                  <Link className='menu-items' to="/contact">
                    Contact
                  </Link>
                </li>)}
          </>


          {admin && (
            <>
              <li>
                <Link className='menu-items' to="/request"><span className='faIcon-width'><i class="fa fa-envelope fa-bounce fa-lg" style={{ color: '#5993f7', width: '30px', textAlign: 'center' }}></i></span></Link>
              </li>
            </>
          )}


          {agent && (
            <>
              <li>
                <Link className='menu-items' to="/packageupload">Upload<span className='faIcon-width'><i class="fa fa-arrow-up" style={{ color: '#5993f7', width: '30px', textAlign: 'center' }}></i></span></Link>
              </li>
            </>
          )}



          {nouser && (
            <>
              <li>
                <Link className='menu-items' to="/login">Login</Link>
              </li>

              <li>
                <MDBDropdown className='menu-items'>
                  <MyCustomDropdownToggle className="bg-signup">SignUp</MyCustomDropdownToggle>
                  <MDBDropdownMenu>
                    <Link to={'/agentRegister'}> <MDBDropdownItem link>Agent Register</MDBDropdownItem></Link>
                    <Link to={'/userRegister'}><MDBDropdownItem link>User Register</MDBDropdownItem></Link>
                  </MDBDropdownMenu>
                </MDBDropdown>

              </li>
            </>
          )}

          {(agent || admin || userIn) && (
            <>
              <li>
                <Link className='menu-items' onClick={logoutFn}>Logout</Link>
              </li>

            </>
          )}

        </ul>
      </nav>
      <label htmlFor='nav-check' className="toggles">
        <div></div>
        <div></div>
        <div></div>
      </label>
    </div>
  );
};

export default NavBar;
