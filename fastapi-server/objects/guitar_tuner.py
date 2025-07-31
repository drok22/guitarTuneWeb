from objects.guitar_fretboard import GuitarFretboard
from objects.scale_patterns import find_fifth, find_fourth, find_seventh, find_sixth, find_third


class GuitarTuner:
    def __init__(self, tuning: str, tuning_type: str, num_strings: int):
        self.tuning: str = tuning
        self.tuning_type: str = tuning_type
        self.fretboard = GuitarFretboard(num_strings)

    def tune_guitar(self):
        '''
        '''
        bass_string = self.tuning
        fifth_string = self.get_fifth_string_tuning(bass_string)
        fourth_string = self.get_fourth_string_tuning(fifth_string)
        third_string = self.get_third_string_tuning(fourth_string)
        second_string = self.get_second_string_tuning(third_string)
        first_string = self.get_first_string_tuning(second_string)

        self.fretboard.strings[5].tune_string(bass_string)
        self.fretboard.strings[4].tune_string(fifth_string)
        self.fretboard.strings[3].tune_string(fourth_string)
        self.fretboard.strings[2].tune_string(third_string)
        self.fretboard.strings[1].tune_string(second_string)
        self.fretboard.strings[0].tune_string(first_string)

    def get_fifth_string_tuning(self, note: str) -> str:
        match self.tuning_type:
            case 'Standard':  # (E) 5th (A) 5th(D) 5th (G) 4th (B) 5th(E)
                note = find_fifth(note)
            case 'Drop':  # (D) 7th (A) 5th (D) 5th (G) 4th (B) 5th (E)
                note = find_seventh(note)
            case 'Open':  # (E) 6th (B) 5th (E) 4th (G#) 3rd (B) 5th (E)
                note = find_sixth(note)
            case _:
                pass
        return note

    def get_fourth_string_tuning(self, note: str) -> str:
        note = find_fifth(note)
        return note

    def get_third_string_tuning(self, note: str) -> str:
        match self.tuning_type:
            case 'Open':
                note = find_fourth(note)
            case _:
                note = find_fifth(note)
        return note

    def get_second_string_tuning(self, note: str) -> str:
        match self.tuning_type:
            case 'Open':
                note = find_third(note)
            case _:
                note = find_fourth(note)
        return note

    def get_first_string_tuning(self, note: str) -> str:
        note = find_fifth(note)
        return note
