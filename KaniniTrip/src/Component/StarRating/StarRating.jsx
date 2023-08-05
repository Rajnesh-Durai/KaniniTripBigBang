import React, { useState, useEffect } from 'react';
import { MDBIcon } from 'mdb-react-ui-kit';
import './StarRating.css'
const StarRating = ({ initialRatingFromApi }) => {
  const [rating, setRating] = useState(initialRatingFromApi);

  const handleRating = (value) => {
    setRating(value);
  };

  return (
    <>
      {[...Array(5)].map((_, index) => (
        <MDBIcon
          key={index}
          icon={index < rating ? 'star' : 'star-o'}
          size='1x'
          className='star-icon'
          onClick={() => handleRating(index + 1)}
        />
      ))}
    </>
  );
};

export default StarRating;
