

import React, {useEffect, useRef, useState} from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';


function App() {

  const [data, setData] = useState([]);

  useEffect(() => {
    fetch('https://api.github.com/users')
    .then(response => response.json())
    .then(setData);
  },[])

  //const [status, setStatus] = useState("Not delivered");
 //const [checked, setChecked] = useState(false);

//  const [name, setName] = useState("Jan");
//  const [admin, setAdmin] = useState(false);

//  useEffect(() => {
//     document.title = `Celebrate ${name}`
//  }, [name]); // empty array, it means effect will only fires once on first render

// useEffect(() => {
//     console.log(`the user is: ${admin ? "admin" : "not admin"}`)
// }, [admin])

if(data) {


  return (
//     // <div>
//     //   <h1>The package is:{status}</h1>
//     //   <button onClick={() => setStatus("delivered")}>Deliver</button>

      
    // </div>
    //  <div>
    //   <input 
    //   type="checkbox" 
    //   value={checked}
    //   onChange={() => setChecked((checked) => !checked)}
    //   ></input>
    //   <p>{checked ? "checked" : "not checked"}</p>
    //  </div>

    // <section>
    //   <p>Congratulations! {name}!</p>
    //   <button onClick={() => setName("Will")}>
    //     Change Winner
    //   </button>
    //   <p>{admin ? "logged in" : "not logged in"}</p>
    //   <button onClick={() => setAdmin(true)}>
        
    //     Log in
    //     </button>
    // </section>
    <div>
    <ul>
      {data.map((user) => (
        <li key={user.id}>{user.login}</li>
      ))}
    </ul>
    <button onClick={() => setData([])}>Remove data </button>
    </div>
  
  );
}
}
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode> 
    <App />
  </React.StrictMode>,
  document.getElementById("root")
);


