import React from "react";
//import ParticleComponent from "react-tsparticles";
import styled from "styled-components";
import Particle from "../Components/Particle";
import FacebookIcon from "@mui/icons-material/Facebook";
import GitHubIcon from "@mui/icons-material/GitHub";
import YouTubeIcon from "@mui/icons-material/YouTube";

function HomePage() {
  return (
    <HomePageStyled>
      <div className="particle-con">
        <Particle />
      </div>
      <div className="typography">
        <h1>
          Hi, I'm <span>Raul</span>
        </h1>
        <p>
          I am a web developer with a passion for creating beautiful and
          functional websites. Welcome to my portfolio!
        </p>
        <div className="icons">
          <a href="https://www.facebook.com/" className="icon i-facebook">
            <FacebookIcon />
          </a>
          <a
            href="https://github.com/Vlad112003/UBB-INFO/tree/main"
            className="icon i-github"
          >
            <GitHubIcon />
          </a>
          <a href="https://www.youtube.com/" className="icon i-youtube">
            <YouTubeIcon />
          </a>
        </div>
      </div>
    </HomePageStyled>
  );
}

const HomePageStyled = styled.header`
  width: 100%;
  height: 100vh;
  position: relative;

  .particles {
    position: absolute;
    top: 0;
    left: 0;
  }

  .typography {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
    width: 80%;

    .icons {
      display: flex;
      justify-content: center;
      margin-top: 1rem;
      .icon {
        display: flex;
        border: 2px solid var(--border-color);
        justify-content: center;
        align-items: center;
        border-radius: 50%;
        transition: all 0.4s ease-in-out;
        cursor: pointer;
        &:hover {
          border: 2px solid var(--primary-color);
          color: var(--primary-color);
        }
        &:not(:last-child) {
          margin-right: 1rem;
        }
        svg {
          margin: 0.5rem;
        }
      }
      .i-youtube {
        &:hover {
          border: 2px solid red;
          color: red;
        }
      }
      .i-github {
        &:hover {
          border: 2px solid #5f4687;
          color: #5f4687;
        }
      }
    }
  }
`;

export default HomePage;
