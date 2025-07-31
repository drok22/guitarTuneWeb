CHROMATIC_SCALE = ['A', 'A#', 'B', 'C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#']


def minor_scale_pattern(key: str) -> list:
    '''Minor Scale Pattern - whole, half, whole, whole, half, whole, whole'''
    scale_pattern = []
    next_step = key

    # add the root note
    scale_pattern.append(next_step)

    for step in range(1, 7):
        if step == 2 or step == 5:
            next_step = find_next_chromatic(next_step)
        else:
            next_step = find_second(next_step)
        scale_pattern.append(next_step)

    return scale_pattern


def major_scale_pattern(key: str) -> list:
    '''Major Scale Pattern - whole, whole, half, whole, whole, whole, half'''
    scale_pattern = []
    next_step = key

    # add the root note
    scale_pattern.append(next_step)

    for step in range(1, 7):
        if step == 3 or step == 7:
            next_step = find_next_chromatic(next_step)
        else:
            next_step = find_second(next_step)
        scale_pattern.append(next_step)

    return scale_pattern


def pentatonic_pattern(key: str, major_minor: str) -> list:
    '''Creates a pentatonic scale for a given key'''
    if major_minor == 'Major':
        return major_pentatonic_pattern(key)
    else:
        return minor_pentatonic_pattern(key)


def minor_pentatonic_pattern(key: str) -> list:
    '''Minor Pentatonic Pattern - 3,2,2,3 (semitones)'''
    scale_pattern = []
    next_step = key

    # add the root note
    scale_pattern.append(next_step)

    for step in range(1, 5):
        if step == 2 or step == 3:
            next_step = find_second(next_step)
        else:
            next_step = find_third(next_step)

        scale_pattern.append(next_step)

    return scale_pattern


def major_pentatonic_pattern(key: str) -> list:
    '''Major Pentatonic Pattern - 2,2,3,2 (semitones)'''
    scale_pattern = []
    next_step = key

    # add the root note
    scale_pattern.append(next_step)

    for step in range(1, 5):
        if step == 3:
            next_step = find_third(next_step)
        else:
            next_step = find_second(next_step)

        scale_pattern.append(next_step)

    return scale_pattern


def blues_pattern(key: str, major_minor: str) -> list:
    '''Creates a blues scale for a given key'''
    if major_minor == 'Major':
        return major_blues_pattern(key)
    else:
        return minor_blues_pattern(key)


def minor_blues_pattern(key: str) -> list:
    '''Minor Blues Pattern - 3,2,1,1,3 (semitones)'''
    scale_pattern = []
    next_step = key

    # add the root note
    scale_pattern.append(next_step)

    for step in range(1, 6):
        if step == 3 or step == 4:
            next_step = find_next_chromatic(next_step)
        elif step == 2:
            next_step = find_second(next_step)
        else:
            next_step = find_third(next_step)

        scale_pattern.append(next_step)

    return scale_pattern


def major_blues_pattern(key: str) -> list:
    '''Major Blues Pattern - 2,1,1,3,2 (semitones)'''
    scale_pattern = []
    next_step = key

    # add the root note
    scale_pattern.append(next_step)

    for step in range(1, 6):
        if step == 2 or step == 3:
            next_step = find_next_chromatic(next_step)
        elif step == 1 or step == 5:
            next_step = find_second(next_step)
        else:
            next_step = find_third(next_step)

        scale_pattern.append(next_step)

    return scale_pattern


def find_next_interval(interval: int, note: str) -> str:
    '''Find the next indicated interval in the chromatic scale, starting with the input note
        Args:
            interval{int}: the number of notes to count to find the next interval
            note{str}: the note to begin counting with (counting starts at 0)
        Returns:
            next_step{str}: the note that was indicated as the next interval
    '''
    index = CHROMATIC_SCALE.index(note) + interval

    # Check the bounds of the scale and restart from the first note in the chromatic scale if needed
    while index >= 12:
        index -= 12

    next_step = CHROMATIC_SCALE[index]

    return next_step


def find_next_chromatic(note: str) -> str:
    '''Find the next note in the chromatic scale
    Args:
        note{str}: the note to start counting from
    Returns
        find_next_interval(){str}: the the result of the next interval calculation
    '''
    return find_next_interval(1, note)


def find_second(note: str) -> str:
    '''Find the second note in the chromatic scale by starting at 0 with the current note
    Args:
        note{str}: the note to start counting from
    Returns
        find_next_interval(){str}: the the result of the next interval calculation
    '''
    return find_next_interval(2, note)


def find_third(note: str) -> str:
    '''Find the third note in the chromatic scale by starting at 0 with the current note
    Args:
        note{str}: the note to start counting from
    Returns
        find_next_interval(){str}: the the result of the next interval calculation
    '''
    return find_next_interval(3, note)


def find_fourth(note: str) -> str:
    '''Find the fourth note in the chromatic scale by starting at 0 with the current note
    Args:
        note{str}: the note to start counting from
    Returns
        find_next_interval(){str}: the the result of the next interval calculation
    '''
    return find_next_interval(4, note)


def find_fifth(note: str) -> str:
    '''Find the fifth note in the chromatic scale by starting at 0 with the current note
    Args:
        note{str}: the note to start counting from
    Returns
        find_next_interval(){str}: the the result of the next interval calculation
    '''
    return find_next_interval(5, note)


def find_sixth(note: str) -> str:
    '''Find the sixth note in the chromatic scale by starting at 0 with the current note

    Args:
        note{str}: the note to start counting from
    Returns
        find_next_interval(){str}: the the result of the next interval calculation
    '''
    return find_next_interval(6, note)


def find_seventh(note: str) -> str:
    '''Find the seventh note in the chromatic scale by starting at 0 with the current note

    Args:
        note{str}: the note to start counting from
    Returns
        find_next_interval(){str}: the the result of the next interval calculation
    '''
    return find_next_interval(7, note)


def get_scale_pattern(key: str, scale: str, major_minor: str) -> list:
    '''Take key and scale information and return a scale pattern
    Args:
        key{str}: the root note of the scale
        scale{str}: the type of scale
        major_minor{str}: major/minor scale 'mode'
    Return:
        scale_pattern{list}: pattern generated by one of the called functions
    '''
    scale_pattern = []

    match scale:
        case 'Pentatonic':
            scale_pattern = pentatonic_pattern(key, major_minor)
        case 'Minor':
            scale_pattern = minor_scale_pattern(key)
        case 'Major':
            scale_pattern = major_scale_pattern(key)
        case 'Blues':
            scale_pattern = blues_pattern(key, major_minor)
        case _:
            pass

    return scale_pattern
