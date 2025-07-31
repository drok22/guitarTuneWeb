from objects.guitar_string import GuitarString


class GuitarFretboard():
    def __init__(self, num_strings: int):
        self.num_strings: int = num_strings
        self.strings: list[GuitarString] = []

        self.string_guitar()

    def string_guitar(self):
        self.strings = []
        for index in range(0, self.num_strings):
            self.strings.append(GuitarString())
