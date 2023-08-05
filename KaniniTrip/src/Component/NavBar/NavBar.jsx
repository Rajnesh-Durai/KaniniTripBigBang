import React from 'react';
import './NavBar.css';
import logo from '../../Assets/logo-s.png'

const NavBar = () => {
  return (
    <div className="sticky">
      <div className="img">
        <img alt="logo" src={logo} />
        <div className="curs">
          <p className='webName' to="/home">KANINI TRIP</p>
        </div>
      </div>
      <input type="checkbox" id="nav-check" hidden />
      <nav>
        <ul>
         
            <li>
              <p >About Us</p>
            </li>
          
          
            <li>
              <p >Our Doctors</p>
            </li>
       
         
            <li>
              <p >Admin</p>
            </li>
         
            <li>
              <p>Book Now</p>
            </li>
         
            <li>
              <p >
                <span>
                  <i className="fa fa-circle-user fa-xl" style={{ color: '#5993f7' }}></i>
                </span>
              </p>
            </li>
         
          {/* {role === 'Doctor' && (
            <li>
              <p to="/home/appointDetails">
                <span>
                  <i className="fa fa-envelope fa-shake fa-xl" style={{ color: '#5993f7' }}></i>
                </span>
                <span className="tot">{totalItem2}</span>
              </p>
            </li>
          )}
          {role === 'Admin' && (
            <li>
              <p to="/home/requestLogin" className="cbg">
                <span>
                  <i className="fa fa-bell fa-shake fa-xl" style={{ color: '#5993f7' }}></i>
                </span>
                <span className="tot">{totalItem}</span>
              </p>
            </li>
          )} */}
            <li>
              <p>Logout</p>
            </li>
        </ul>
      </nav>
      <label for='nav-check' className="toggles">
        <div></div>
        <div></div>
        <div></div>
      </label>
    </div>
  );
};

export default NavBar;
