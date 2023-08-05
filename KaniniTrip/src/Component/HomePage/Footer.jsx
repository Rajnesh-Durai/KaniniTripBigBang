import React from 'react'
import { MDBFooter, MDBContainer, MDBRow, MDBCol, MDBIcon,  MDBBtn } from 'mdb-react-ui-kit';

const Footer = () => {
    return (
        <div>
            <MDBFooter bgColor='light' className='text-center text-lg-start text-muted'>
                <section className='d-flex justify-content-center justify-content-lg-between p-4 border-bottom'>
                    <div className='me-5 d-none d-lg-block'>
                        <span>Get connected with us on social networks:</span>
                    </div>

                    <div>
                        <a href='https://www.facebook.com/KANINIans/' target='_blank' className='me-4 text-reset'>
                            <MDBBtn
                                floating
                                className='m-1'
                                style={{ backgroundColor: '#3b5998' }}
                                href='https://www.facebook.com/KANINIans/'
                                target='_blank'
                                role='button'
                            >
                                <MDBIcon fab icon='facebook-f' />
                            </MDBBtn>
                        </a>
                        <a href='https://twitter.com/kanini_com?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor' target='_blank' className='me-4 text-reset'>
                            <MDBBtn
                                floating
                                className='m-1'
                                style={{ backgroundColor: '#55acee' }}
                                target='_blank'
                                href='https://twitter.com/kanini_com?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor'
                                role='button'
                            >
                                <MDBIcon fab icon='twitter' />
                            </MDBBtn>
                        </a>
                        <a href='https://kanini.com/' target='_blank' className='me-4 text-reset'>
                            <MDBBtn
                                floating
                                className='m-1'
                                style={{ backgroundColor: '#dd4b39' }}
                                href='https://kanini.com/'
                                target='_blank'
                                role='button'
                            >
                                <MDBIcon fab icon='google' />
                            </MDBBtn>
                        </a>
                        <a href='https://www.instagram.com/kanini_com/?hl=en' target='_blank'  className='me-4 text-reset'>
                            <MDBBtn
                                floating
                                className='m-1'
                                style={{ backgroundColor: '#ac2bac' }}
                                href='https://www.instagram.com/kanini_com/?hl=en'
                                target='_blank'
                                role='button'
                            >
                                <MDBIcon fab icon='instagram' />
                            </MDBBtn>
                        </a>
                        <a href='https://in.linkedin.com/company/kanini' target='_blank'  className='me-4 text-reset'>
                            <MDBBtn
                                floating
                                className='m-1'
                                style={{ backgroundColor: '#0082ca' }}
                                href='https://in.linkedin.com/company/kanini'
                                target='_blank'
                                role='button'
                            >
                                <MDBIcon fab icon='linkedin-in' />
                            </MDBBtn>
                        </a>
                        <a href='https://github.com/kanini' target='_blank'  className='me-4 text-reset'>
                            <MDBBtn
                                floating
                                className='m-1'
                                style={{ backgroundColor: '#333333' }}
                                href='https://github.com/kanini'
                                target='_blank'
                                role='button'
                            >
                                <MDBIcon fab icon='github' />
                            </MDBBtn>
                        </a>
                    </div>
                </section>

                <section className=''>
                    <MDBContainer className='text-center text-md-start mt-5'>
                        <MDBRow className='mt-3'>
                            <MDBCol md='3' lg='4' xl='3' className='mx-auto mb-4'>
                                <h6 className='text-uppercase fw-bold mb-4'>
                                    <MDBIcon color='secondary' icon='gem' className='me-3' />
                                    Kanini Trip
                                </h6>
                                <p>
                                Best Tours & Travels in Tamil Nadu. We provide best Tour packages & Travel Packages.
                                </p>
                            </MDBCol>

                            <MDBCol md='2' lg='2' xl='2' className='mx-auto mb-4'>
                                <h6 className='text-uppercase fw-bold mb-4'>Best Locations</h6>
                                <p>
                                    <a href='#!' className='text-reset'>
                                        Kerala
                                    </a>
                                </p>
                                <p>
                                    <a href='#!' className='text-reset'>
                                        Goa
                                    </a>
                                </p>
                                <p>
                                    <a href='#!' className='text-reset'>
                                        Agra
                                    </a>
                                </p>
                                <p>
                                    <a href='#!' className='text-reset'>
                                        Ladakh
                                    </a>
                                </p>
                            </MDBCol>

                            <MDBCol md='3' lg='2' xl='2' className='mx-auto mb-4'>
                                <h6 className='text-uppercase fw-bold mb-4'>impressive spots</h6>
                                <p>
                                    <a href='#!' className='text-reset'>
                                    Khajjiar
                                    </a>
                                </p>
                                <p>
                                    <a href='#!' className='text-reset'>
                                    Valley of Flowers
                                    </a>
                                </p>
                                <p>
                                    <a href='#!' className='text-reset'>
                                    Dal Lake
                                    </a>
                                </p>
                                <p>
                                    <a href='#!' className='text-reset'>
                                    Dawki
                                    </a>
                                </p>
                            </MDBCol>

                            <MDBCol md='4' lg='3' xl='3' className='mx-auto mb-md-0 mb-4'>
                                <h6 className='text-uppercase fw-bold mb-4'>Contact</h6>
                                <p>
                                    <MDBIcon color='secondary' icon='home' className='me-2' />
                                    Tamil Nadu, IND
                                </p>
                                <p>
                                    <MDBIcon color='secondary' icon='envelope' className='me-3' />
                                    kanini@gmail.com
                                </p>
                                <p>
                                    <MDBIcon color='secondary' icon='phone' className='me-3' /> +91-5613213452
                                </p>
                                <p>
                                    <MDBIcon color='secondary' icon='print' className='me-3' /> +91-5613213475
                                </p>
                            </MDBCol>
                        </MDBRow>
                    </MDBContainer>
                </section>

                <div className='text-center p-4' style={{ backgroundColor: 'rgba(0, 0, 0, 0.05)' }}>
                    © 2023 Copyright:
                    <a className='text-reset fw-bold' >
                        KANINI TRIP
                    </a>
                </div>
            </MDBFooter>
        </div>
    )
}

export default Footer
