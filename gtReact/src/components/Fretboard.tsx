import { Row, Button, Col } from "react-bootstrap";

type FretboardProps = {
  fretboard: string[][];
  scale: string[];
};

function Fretboard({ fretboard, scale }: FretboardProps) {
  return (
    <div>
      {fretboard.map((stringNotes, stringIndex) => (
        <Row>
          {stringNotes.map((note, fretIndex) => (
            <Col>
              <Button variant="primary">{note}</Button>
            </Col>
          ))}
        </Row>
      ))}
    </div>
  );
}

export default Fretboard;
