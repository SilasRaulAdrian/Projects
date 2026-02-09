import React from "react";
import { MainLayout, InnerLayout } from "../styles/Layouts";
import styled from "styled-components";
import Title from "../Components/Title";
import SmallTitle from "./SmallTitle";
import BusinessCenterIcon from "@mui/icons-material/BusinessCenter";
import SchoolIcon from "@mui/icons-material/School";
import ResumeItem from "./ResumeItem";

function Resume() {
  const briefcase = <BusinessCenterIcon />;
  const school = <SchoolIcon />;
  return (
    <ResumeStyled>
      <Title title={"Resume"} span={"Resume"} />
      <InnerLayout>
        <div className="small-title">
          <SmallTitle icon={briefcase} title={"Work Experience"} />
        </div>
        <div className="resume-content">
          <ResumeItem
            year={"none"}
            title={"none"}
            subTitle={"none"}
            text={"none"}
          />
        </div>
        <div className="small-title u-small-title-margin">
          <SmallTitle icon={school} title={"Educational Qualifications"} />
        </div>
        <div className="resume-content">
          <ResumeItem
            year={"2012 - 2020"}
            title={"Primary School"}
            subTitle={"Avram Iancu, Bistrita"}
            text={
              "Completed primary education with a focus on foundational skills."
            }
          />
          <ResumeItem
            year={"2020 - 2024"}
            title={"High School"}
            subTitle={"Colegiul National Liviu Rebreanu, Bistrita"}
            text={
              "Graduated with a focus on sciences, achieving high academic standards."
            }
          />
          <ResumeItem
            year={"2024 - Present"}
            title={"Student at University"}
            subTitle={"UBB University, Cluj-Napoca"}
            text={
              "Currently pursuing a degree in Computer Science, focusing on software development and data analysis."
            }
          />
        </div>
      </InnerLayout>
    </ResumeStyled>
  );
}

const ResumeStyled = styled.section`
  .small-title {
    padding-bottom: 3rem;
  }
  .u-small-title-margin {
    margin-top: 4rem;
  }
  .resume-content {
    border-left: 2px solid var(--border-color);
  }
`;

export default Resume;
