import React from "react";
import styled from "styled-components";

function PrimaryButton({ name }) {
  return <ButtonStyled>{name}</ButtonStyled>;
}

const ButtonStyled = styled.button`
  background-color: var(--accent-pink);
  padding: 0.6rem 1.8rem;
  font-family: inherit;
  font-size: inherit;
  color: inherit;
  border-radius: 20px;
  outline: none;
  border: none;
  cursor: pointer;
`;

export default PrimaryButton;
