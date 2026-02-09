import React from "react";
import styled from "styled-components";
import { InnerLayout } from "../styles/Layouts";
import lines from "../img/lines.svg";
import questions from "../question";
import Questions from "./Questions";

function FAQSection() {
  return (
    <FaqStyled>
      <InnerLayout>
        <h3 className="small-heading">
          Frequently <span>asked questions</span>
        </h3>
        <p className="c-para">
          If you have any questions, please check our FAQ section. If you still
          need help, feel free to contact us.
        </p>
        <div className="lines">
          <img src={lines} alt="" />
        </div>
        <div className="questions-con">
          {questions.map((q) => {
            return <Questions key={q.id} {...q} />;
          })}
        </div>
      </InnerLayout>
    </FaqStyled>
  );
}

const FaqStyled = styled.section`
  .c-para {
    width: 60%;
    margin: 0 auto;
  }
  .questions-con {
    padding-top: 4rem;
  }
  .lines {
    position: absolute;
    left: 0;
    top: 300%;
    width: 100%;
    z-index: -1;
    img {
      width: 100%;
    }
  }
`;

export default FAQSection;
