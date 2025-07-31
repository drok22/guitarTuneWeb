from objects.scale_patterns import find_next_chromatic


class GuitarString():
    def __init__(self, num_frets: int = 24):
        self.num_frets: int = num_frets
        self.frets: list[str] = []

    def tune_string(self, note: str):
        self.frets = []
        for _ in range(0, self.num_frets):
            self.frets.append(note)
            note = find_next_chromatic(note)
