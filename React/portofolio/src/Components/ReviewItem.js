import React from "react";
import styled from "styled-components";

function ReviewItem({ text, name }) {
  return (
    <ReviewItemStyled>
      <p className="text">"{text}"</p>
      <p className="name">{name}</p>
    </ReviewItemStyled>
  );
}

const ReviewItemStyled = styled.div`
  padding: 2rem 1rem;
  border-left: 6px solid var(--border-color);
  background-color: var(--background-dark-grey);
  position: relative;
  width: 100%;
  &:not(:first-child) {
  }
  &::after {
    content: "";
    position: absolute;
    left: 2rem;
    border-width: 0.8rem;
    top: 100%;
    border-style: solid;
    border-color: var(--background-dark-grey) transparent transparent
      var(--background-dark-grey);
  }
  p {
    padding: 1rem 0;
  }
  .text {
    padding: 1rem 0;
    color: var(--font-light-color);
  }
  .name {
    position: absolute;
    bottom: -5rem;
    // left: 2.1rem;
    font-size: 1.5rem;
    font-weight: bold;
    color: var(--white-color);
  }
`;

export default ReviewItem;
