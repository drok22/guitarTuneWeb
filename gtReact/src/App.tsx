import { useState } from "react";
import Fretboard from "./components/Fretboard";
import UserInput from "./components/UserInput";

type ScaleRequest = {
  key: string;
  keyType: string;
  tuning: string;
  tuningType: string;
  scaleType: string;
  numStrings: number;
};

function App() {
  const defaultRequest: ScaleRequest = {
    key: "E",
    keyType: "Minor",
    tuning: "E",
    tuningType: "Standard",
    scaleType: "Minor",
    numStrings: 6,
  };
  const [request, setRequest] = useState<ScaleRequest>(defaultRequest);
  const [err, setError] = useState<Error | string | null>(null);
  const [result, setResult] = useState(null);
  const [fretboard, setFretboard] = useState<[][]>([]);
  const [scale, setScale] = useState<[]>([]);

  const updateRequest = async (updatedRequest: ScaleRequest) => {
    setRequest(updatedRequest);
    const query = new URLSearchParams({
      key: updatedRequest.key,
      keyType: updatedRequest.keyType,
      tuning: updatedRequest.tuning,
      tuningType: updatedRequest.tuningType,
      scaleType: updatedRequest.scaleType,
      numStrings: updatedRequest.numStrings.toString(),
    })
    try {
      const response = await fetch(`http://localhost:5073/scale?${query.toString()}`, {
        method: "GET",
      });
      if (!response.ok) {
        throw new Error("HTTP Error: " + response.status);
      }
      const data = await response.json();

      console.log("fretboard:", fretboard)
      console.log("scale", scale)
      setFretboard(data.fretboard)
      setScale(data.scale);
      setResult(data);
      setError(null);
    } catch (err) {
      setError(err instanceof Error ? err.message: String(err));
      setResult(null);
    }
  };

  return (
    <div className="bg-dark text-light min-vh-100">
      <UserInput onUpdateScale={updateRequest} />
      <Fretboard fretboard={fretboard} scale={scale}/>
    </div>
  );
}

export default App;
