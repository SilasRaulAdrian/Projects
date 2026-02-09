import React from "react";
import styled from "styled-components";
import avatar from "../img/avatar.svg";
import age from "../img/age.svg";
import location from "../img/location.svg";
import github from "../img/github.svg";
import contact from "../img/contact.svg";
import email from "../img/email.svg";

function PersonalInfo() {
  return (
    <PersonalInfoStyled>
      <div className="personal-info-con">
        <div className="avatar-con">
          <div className="avatar">
            <img src={avatar} alt="" />
          </div>
          <div className="right-avatar">
            <h4>Silas Raul</h4>
            <p>Web Developer - Software Engineer - Lead Designer</p>
            <div className="contact-btn">Contact</div>
          </div>
        </div>
        <p className="about-text">
          I am a passionate web developer with a keen interest in creating
          dynamic and responsive web applications. My expertise lies in
          front-end development, where I enjoy bringing designs to life using
          modern technologies. I am always eager to learn new skills and stay
          updated with the latest trends in web development. I believe in the
          power of collaboration and enjoy working in teams to build innovative
          solutions. In my free time, I like to explore new programming
          languages and contribute to open-source projects. I am committed to
          delivering high-quality work and continuously improving my skills to
          meet the evolving demands of the tech industry. I am excited about the
          opportunities that lie ahead and look forward to making a positive
          impact in the world of web development.
        </p>
        <div className="icon-text">
          <div className="icons">
            <div className="icon">
              <img src={location} alt="" />
              <p>Cluj-Napoca, Romania</p>
            </div>
            <div className="icon">
              <img src={age} alt="" />
              <p>20 Years Old</p>
            </div>
            <div className="icon">
              <img src={contact} alt="" />
              <p>0756488678</p>
            </div>
            <div className="icon">
              <img src={email} alt="" />
              <p>rauladriansilas@gmail.com</p>
            </div>
          </div>
        </div>
      </div>
    </PersonalInfoStyled>
  );
}

const PersonalInfoStyled = styled.div`
  grid-column: 1 / 4;
  background: linear-gradient(
    117.76deg,
    rgba(255, 255, 255, 0.7) -7.21%,
    rgba(255, 255, 255, 0.5) 118.08%
  );
  backdrop-filter: blur(9px);
  border-radius: 8px;
  margin-bottom: 30px;
  border: 2px solid #fff;
  box-shadow: 0 10px 20px 0 rgba(0, 0, 0, 0.02);

  // Personal info
  .personal-info-con {
    padding: 2.5rem 2rem;
    .avatar-con {
      display: grid;
      grid-template-columns: repeat(2, 1fr);
      .avatar {
        width: 100%;
        border-radius: 10px;
        margin-right: 2rem;
        padding-right: 3rem;
        display: flex;
        align-items: center;
        img {
          width: 100%;
          border-radius: 10px;
        }
      }
      .right-avatar {
        display: flex;
        justify-content: space-between;
        flex-direction: column;
        p {
          padding: 1rem 0;
        }
      }

      .contact-btn {
        background-color: #6bbe92;
        color: #fff;
        padding: 0.6rem 0.9rem;
        text-align: center;
        border-radius: 7px;
      }
    }
    .about-text {
      padding: 1.5rem 0;
    }
    .icon-text {
      .icons {
        .icon {
          display: flex;
          align-items: center;
          padding: 0.5rem 0;
          p {
            padding-left: 1rem;
          }
        }
      }
    }
  }
`;

export default PersonalInfo;
