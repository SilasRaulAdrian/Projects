import React from "react";
import { InnerLayout } from "../styles/Layouts";
import styled from "styled-components";
import Title from "./Title";
import ServicesCard from "./ServiceCard";
import design from "../img/design.svg";
import intelligence from "../img/intelligence.svg";
import gamedev from "../img/game-dev.svg";

function ServicesSection() {
  return (
    <InnerLayout>
      <ServicesSectionStyled>
        <Title title={"Services"} span={"services"} />
        <div className="services">
          <ServicesCard
            image={design}
            title={"Web Design"}
            paragraph={
              "Web design combines aesthetics and functionality to create user-friendly, visually appealing, and responsive websites across all devices."
            }
          />
          <div className="mid-card">
            <ServicesCard
              image={intelligence}
              title={"Artificial Intelligence"}
              paragraph={
                "AI enables machines to mimic human intelligence, enhancing automation, decision-making, and problem-solving across various industries."
              }
            />
          </div>
          <ServicesCard
            image={gamedev}
            title={"Game Development"}
            paragraph={
              "Game development combines art, coding, and storytelling to create interactive digital experiences for entertainment or education."
            }
          />
        </div>
      </ServicesSectionStyled>
    </InnerLayout>
  );
}

const ServicesSectionStyled = styled.section`
  .services {
    margin-top: 5rem;
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-gap: 1.5rem;
    @media screen and (max-width: 1000px) {
      flex-direction: column;
    }
    @media screen and (max-width: 950px) {
      grid-template-columns: repeat(2, 1fr);
    }
    @media screen and (max-width: 650px) {
      grid-template-columns: repeat(1, 1fr);
    }
  }
`;

export default ServicesSection;
