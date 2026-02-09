import React from "react";
import styled from "styled-components";
import { InnerLayout } from "../styles/Layouts";
import card from "../img/creditcard.svg";

function CardSection() {
  return (
    <CardSectionStyled>
      <InnerLayout>
        <div className="card-container">
          <div className="card-left">
            <h2 className="secondary-heading">
              One card for all your payments
            </h2>
            <p>
              Get 3% back on everything you buy with the Draft card. Register
              today and enjoy every aspect of your business.
            </p>
          </div>
          <div className="card-right">
            <img src={card} alt="" />
          </div>
        </div>
      </InnerLayout>
    </CardSectionStyled>
  );
}

const CardSectionStyled = styled.section`
  .card-container {
    display: grid;
    grid-template-columns: repeat(2, 1fr);
    @media screen and (max-width: 1409px) {
      grid-template-columns: 1fr;
      gap: 3rem;
      text-align: center;
      .card-right {
        justify-content: center;
      }
      .card-left {
        padding: 0 1rem;
      }
    }
    .card-right {
      display: flex;
      justify-content: flex-end;
      img {
        filter: drop-shadow(0px 50px 100px rgba(22, 25, 79, 0.15));
      }
    }
    .card-left {
      p {
        padding: 1rem 0;
      }
    }
  }
`;

export default CardSection;
