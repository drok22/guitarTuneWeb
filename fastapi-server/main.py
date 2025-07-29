from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware


app = FastAPI()
app.add_middleware(
    CORSMiddleware,
    allow_origins=["http://localhost:5173"],
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
    fretboard: list[list[str]] = [[]]
    scale: list[str] = []
    result: dict = {
        "fretboard": fretboard,
        "scale": scale
    }
    return result


@app.get("/greet/{name}")
def greet(name: str):
    return {"message": f"Hello, {name}!"}


@app.post("/echo")
def echo(data: dict):
    return {"received": data}
