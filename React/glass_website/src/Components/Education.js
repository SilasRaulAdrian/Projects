import React from "react";
import Timeline from "./Timeline";

function Education() {
  return (
    <div>
      <div className="TimelineCon">
        <Timeline
          name={"October, 2024"}
          text={"UBB University, Cluj-Napoca"}
          qualification={"Computer Science Diploma Degree"}
        />
        <Timeline
          name={"September, 2020"}
          text={"Colegiul National Liviu Rebreanu, Bistrita"}
          qualification={"High School Diploma"}
        />
        <Timeline
          name={"September, 2012"}
          text={"Scoala Gimnaziala Avram Iancu, Bistrita"}
          qualification={"Primary School Diploma"}
        />
      </div>
    </div>
  );
}

export default Education;
