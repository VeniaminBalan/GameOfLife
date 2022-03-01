Game of Life 

It is my version of the "game of life" from British mathematician John Horton Conway.
It is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input.
However i implemented some features that can extend user's controls (see below)

Rules: 
The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells(in my version the grid it's looped),
each of which is in one of two possible states, live or dead (or populated and unpopulated, respectively).
Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. 
At each step in time, the following transitions occur:

- Any live cell with fewer than two live neighbours dies, as if by underpopulation.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any live cell with more than three live neighbours dies, as if by overpopulation.
- Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

These rules, which compare the behavior of the automaton to real life, can be condensed into the following:

- Any live cell with two or three live neighbours survives.
- Any dead cell with three live neighbours becomes a live cell.
- All other live cells die in the next generation. Similarly, all other dead cells stay dead.

For more information check: 
https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

In my project i used .NET framework - Windows forms.

There are 4 Buttons to interect with
- Start - generates the grid with randomly positionated live cells and starts the timer(generations).
- Stop - freaze the game.
- Contiunue - unfreaze the game.
- Clear - clear the grid from all live cells.

Left Click on grid - "draws" a cell in the current position of the mouse.
Right Click on grid - "removes" the live cell from the current position of the mouse.

