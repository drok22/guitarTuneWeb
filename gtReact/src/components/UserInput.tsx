import { useEffect, useState } from "react";
import { Row, Col, Form, Button } from "react-bootstrap";

interface ScaleRequest {
  key: string;
  keyType: string;
  tuning: string;
  tuningType: string;
  scaleType: string;
  numStrings: number;
}

const UserInput = (props: {
  onUpdateScale: (updated_request: ScaleRequest) => void;
}) => {
  const [key, setKey] = useState("E");
  const [keyType, setKeyType] = useState("Minor");
  const [tuning, setTuning] = useState("E");
  const [tuningType, setTuningType] = useState("Standard");
  const [scaleType, setScaleType] = useState("Minor");
  const [numStrings, setNumStrings] = useState("6");
  const [scaleNotes, setScaleNotes] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("http://localhost:5073/testScale")
      .then((response) => {
        if (!response.ok) {
          throw new Error("HTTP Error: ${response.status}");
        }
        return response.json();
      })
      .then((data) => setScaleNotes(data))
      .catch((err) => setError(err.message));
  }, []);

  function onUpdateScale() {
    const updatedRequest: ScaleRequest = {
      key: key,
      keyType: keyType,
      tuning: tuning,
      tuningType: tuningType,
      scaleType: scaleType,
      numStrings: parseInt(numStrings),
    };
    props.onUpdateScale(updatedRequest);
  }

  return (
    <Form>
      <Row className="align-items-end g-3">
        {/* Key ComboBox with Label */}
        <Col>
          <Form.Group controlId="keySelect">
            <Form.Label>Key</Form.Label>
            <Form.Select
              value={key}
              onChange={(item) => {
                setKey(item.target.value);
                onUpdateScale();
              }}
            >
              <option value="A">A</option>
              <option value="A#">A#</option>
              <option value="B">B</option>
              <option value="C">C</option>
              <option value="C">C#</option>
              <option value="D">D</option>
              <option value="D#">D#</option>
              <option value="E">E</option>
              <option value="F">F</option>
              <option value="F#">F#</option>
              <option value="G">G</option>
              <option value="G#">G#</option>
            </Form.Select>
          </Form.Group>
        </Col>

        {/* Second ComboBox (no label) */}
        <Col>
          <Form.Select
            value={keyType}
            onChange={(item) => {
              setKeyType(item.target.value);
              onUpdateScale();
            }}
          >
            <option value="Major">Major</option>
            <option value="Minor">Minor</option>
          </Form.Select>
        </Col>
        {/* Tuning Low String Value ComboBox (no label) */}
        <Col>
          <Form.Label>Tuning</Form.Label>
          <Form.Select
            value={tuning}
            onChange={(item) => {
              setTuning(item.target.value);
              onUpdateScale();
            }}
          >
            <option value="A">A</option>
            <option value="A#">A#</option>
            <option value="B">B</option>
            <option value="C">C</option>
            <option value="C">C#</option>
            <option value="D">D</option>
            <option value="D#">D#</option>
            <option value="E">E</option>
            <option value="F">F</option>
            <option value="F#">F#</option>
            <option value="G">G</option>
            <option value="G#">G#</option>
          </Form.Select>
        </Col>
        {/* Tuning ComboBox with Label */}
        <Col>
          <Form.Group controlId="tuningSelect">
            <Form.Select
              value={tuningType}
              onChange={(item) => {
                setTuningType(item.target.value);
                onUpdateScale();
              }}
            >
              <option value="Standard">Standard</option>
              <option value="Drop">Drop</option>
              {/* Add more tunings as needed */}
            </Form.Select>
          </Form.Group>
          {/* FIXME: just adding invisible columns for now */}
        </Col>
        <Col></Col>
        <Col></Col>
      </Row>
      <Row className="align-items-end g-3">
        {/* Number of strings on instrument */}
        <Col>
          <Form.Group controlId="numStringsSelect">
            <Form.Label>Number of Strings</Form.Label>
            <Form.Select
              value={numStrings}
              onChange={(item) => {
                setNumStrings(item.target.value);
                onUpdateScale();
              }}
            >
              <option value="6">6</option>
              <option value="7">7</option>
            </Form.Select>
          </Form.Group>
        </Col>
        {/* Scale to display notes from */}
        <Col>
          <Form.Group controlId="scaleSelect">
            <Form.Label>Scale</Form.Label>
            <Form.Select
              value={scaleType}
              onChange={(item) => {
                setScaleType(item.target.value);
                onUpdateScale();
              }}
            >
              <option value="Minor">Minor</option>
              <option value="Major">Major</option>
              <option value="Pentatonic">Pentatonic</option>
              <option value="Blues">Blues</option>
            </Form.Select>
          </Form.Group>
        </Col>
        <Col>
          <Button variant="primary">Save</Button>
          <Button variant="danger">Reset</Button>
          {/* FIXME: just adding invisible columns for now */}
        </Col>
        <Col></Col>
        <Col></Col>
        <Col></Col>
      </Row>
      <Row>
        <h2>Scale: </h2>
        {error ? (
          <p style={{ color: "red" }}>Error: {error}</p>
        ) : (
          <h1>{scaleNotes}</h1>
        )}
      </Row>
    </Form>
  );
};

export default UserInput;
