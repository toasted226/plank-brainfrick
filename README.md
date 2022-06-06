# PLANK - Brainfuck

Plank is the Picture Language made for the esoteric programming language, Brainfuck.

The interpreter reads pixels from .PNG images row by row from top to bottom, left to right.
Each pixel will be converted to its corresponding Brainfuck symbol according to the chart below, by colour. 
Pixel colours that are not found in the chart will be ignored.

| Colour code | Symbol |
|-------------|--------|
| #000000     | .      |
| #888888     | ,      |
| #0000FF     | +      |
| #FF0000     | -      |
| #FF00FF     | <      |
| #00FF00     | >      |
| #00FFCC     | [      |
| #FF8800     | ]      |

