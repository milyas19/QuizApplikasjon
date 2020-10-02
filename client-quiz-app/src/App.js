import React, { useEffect, useCallback, useState } from "react";
import "./App.css";

function App() {
  const [viewQuiz, setViewQuiz] = useState([]);
  const [viewQuestion, setViewQuestion] = useState([]);
  const [answers, setAnswers] = useState([]);
  const [result, setResult] = useState("");

  const getLogs = useCallback(async () => {
    const response = await fetch("http://localhost:51506/api/Quiz/9");
    const dataQuiz = await response.json();
    const dataQuestions = dataQuiz.questions;
    setViewQuiz(dataQuiz);
    setViewQuestion(dataQuestions);
    console.log(dataQuestions);
  }, [setViewQuiz, setViewQuestion]);

  const putMethod = {
    method: "PUT",
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
    body: JSON.stringify({
      quizId: viewQuiz.quizId,
      answers: answers,
    }),
  };
  z;
  const SubmitFinalAnswers = useCallback(async () => {
    await fetch("http://localhost:51506/api/Quiz/", putMethod)
      .then((response) => response.json())
      .then((data) => {
        setResult(data);
        console.log(data);
      })
      .catch((err) => console.log(err));
  }, [putMethod]);

  useEffect(() => {
    getLogs();
    // eslint-disable-next-line no-use-before-define
  }, [getLogs]);

  const SubmitAnswers = () => {
    return (
      <>
        <input
          type="submit"
          value="Send"
          onClick={() => {
            SubmitFinalAnswers();
            alert(JSON.stringify(answers, null, 2));
          }}
        />
      </>
    );
  };

  return (
    <>
      <h1>Quiz Application</h1>
      <div>
        <div>QuizId: {viewQuiz && viewQuiz.quizId}</div>
        <div>Score: {result}</div>
        {viewQuestion?.length &&
          viewQuestion.map((item, i) => (
            <ul key={i}>
              <li>{item.questionText}</li>

              {item?.choices.length &&
                item.choices.map((options, j) => (
                  <ul key={j}>
                    <div className="questionOptions">
                      <div className="optionInput">
                        <input
                          type="radio"
                          id={options.choiceId}
                          name={item.questionId}
                          value={options.choiceId}
                          onChange={() => {
                            let newAnswers = [];
                            var radios = document.getElementsByTagName("input");
                            for (i = 0; i < radios.length; i++) {
                              if (
                                radios[i].type === "radio" &&
                                radios[i].checked
                              ) {
                                newAnswers.push({
                                  questionId: parseInt(radios[i].name),
                                  choiceId: parseInt(radios[i].value),
                                });
                              }
                            }
                            setAnswers(newAnswers);
                          }}
                        />
                      </div>
                      <div className="optionText">{options.choiceText}</div>
                    </div>
                  </ul>
                ))}
            </ul>
          ))}
        <SubmitAnswers />
        {/* <pre>{JSON.stringify(answers, null, 2)}</pre> */}
      </div>
    </>
  );
}

export default App;
