

import React, {useReducer, useState} from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';

const initialState ={
  message: "hi"
};

function reducer(state, action){
  switch(action.type) {
    case "yell":
      return {
        message: `HEY I JUST SAID ${state.message}`
      };
    case "whisper:":
      return { 
        message: `excuse me, i just daid ${state.message}`}
      };
  }





function App() {
  
  const [state, dispatch] = useReducer(
    reducer,
    initialState
  );
  
  return (
    <div>
      <p>Message: {state.message}</p>
      <button onClick={()=> dispatch({type: "yell"})}>
        YELL</button>
        <button onClick={()=> dispatch({type: "whisper"})}>whisper</button>

    </div>
  );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode> 
    <App />
  </React.StrictMode>,
  document.getElementById("root")
);


