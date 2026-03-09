# 2048 — Pygame Implementation

A fully functional clone of the classic **2048 puzzle game**, built with Python and Pygame. Slide tiles on a 4×4 grid, merge matching numbers, and try to reach the **2048** tile!

---

## Requirements

- Python 3.7+
- Pygame

Install Pygame via pip:

```bash
pip install pygame
```

---

## How to Run

```bash
python main.py
```

---

## Controls

| Key          | Action            |
| ------------ | ----------------- |
| `←` Arrow    | Slide tiles left  |
| `→` Arrow    | Slide tiles right |
| `↑` Arrow    | Slide tiles up    |
| `↓` Arrow    | Slide tiles down  |
| Close window | Quit the game     |

---

## How It Works

### Game Board

The board is a **4×4 grid** (800×800 pixels). Each cell is 200×200 px. The grid is drawn with rounded separator lines and a warm beige color scheme faithful to the original 2048.

### Tiles

Each `Tile` object holds:

- **value** — a power of 2 (starting at 2 or 4)
- **row / col** — its logical position in the grid
- **x / y** — its pixel position used for smooth animation

Tile colors are mapped automatically based on `log2(value)`, cycling through 9 predefined colors from light beige (2) to gold (512+).

### Tile Movement & Animation

When an arrow key is pressed, `move_tiles()` is called with a direction. The function:

1. **Sorts tiles** in the correct order for that direction (e.g., left-to-right for a left swipe, so tiles don't block each other).
2. **Moves each tile** by a fixed velocity (`MOVE_VEL = 20` pixels per frame) toward the target wall or the next blocking tile, animating the slide frame by frame.
3. **Merges tiles** when two tiles of the same value collide — the far tile is removed and the near tile's value doubles. A `blocks` set prevents a tile from merging more than once per move.
4. **Updates positions** by snapping tiles to the nearest grid cell after each animation step (`set_pos()` using `floor` or `ceil` depending on direction).
5. Loops until no tile has moved (`updated = False`), then calls `end_move()`.

### After Each Move

`end_move()` checks if the board is full (`16` tiles). If it is, the game ends with `"lost"`. Otherwise, a new tile (value `2` or `4`, chosen randomly) is placed on a random empty cell.

### Rendering

Every frame during animation calls `draw()`, which:

- Fills the background
- Draws all tiles with their number centered
- Overlays the grid lines
- Calls `pygame.display.update()`

---

## Game Over

The game ends when **all 16 cells are occupied** after a move and no further merges are possible. A `"lost"` state is returned — you can extend this to show a Game Over screen.

---

## Possible Extensions

- Display current score and best score
- Game Over / You Win overlay screens
- Restart button
- Saving high scores to a file
- Undo last move
