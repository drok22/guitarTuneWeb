from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from constants import REACT_APP_URL
from objects.guitar_tuner import GuitarTuner
from objects.scale_patterns import get_scale_pattern

app = FastAPI()
app.add_middleware(
    CORSMiddleware,
    allow_origins=[REACT_APP_URL],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"])


@app.get("/")
def read_root():
    return {"message": "FastAPI is working!"}


@app.get("/testscale")
def test_scale() -> list[str]:
    return ["E", "F#", "G", "A", "B", "C", "D"]


@app.get("/scale")
def get_scale() -> dict:
    tuner: GuitarTuner = GuitarTuner("E", "Standard", 6)
    scale: list[str] = get_scale_pattern("E", "Pentatonic", False)
    tuner.tune_guitar()

    # FIXME: pydantic doesn't like using GuitarFretboard and GuitarString as objects here, we'll need
    # to find a way to convert these into simple objects like we did with the c# server.
    result: dict = {
        "fretboard": tuner.fretboard.strings,
        "scale": scale
    }
    return result
