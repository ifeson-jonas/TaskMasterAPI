import { useState, useEffect } from "react";
import "./App.css";

function App() {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("http://localhost:5000/api/tasks", {
      headers: {
        "Content-Type": "application/json",
        "Accept": "application/json"
      }
    })
    .then(response => {
      console.log("Status:", response.status);
      if (!response.ok) throw new Error("Erro: " + response.status);
      return response.json();
    })
    .then(data => setData(data))
    .catch(err => {
      console.error("Erro completo:", err);
      setError(err.message);
    });
  }, []);

  return (
    <div className="App">
      <h1>TaskMaster Debug</h1>
      {error ? (
        <div style={{ color: "red" }}>
          <h3>ERRO: {error}</h3>
          <p>Verifique:</p>
          <ul>
            <li>Back-end rodando em outro terminal</li>
            <li>Console do navegador (F12)</li>
          </ul>
        </div>
      ) : (
        <pre>{JSON.stringify(data, null, 2)}</pre>
      )}
    </div>
  );
}

export default App;
