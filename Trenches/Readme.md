Given a matrix of integers that represents a terrain, with the following possible values:

0 -> Plain area
1 -> Trench
2 -> Objective

And considering that the starting position corresponds, always, to the first row and column (position 0, 0).

The problem consists of obtaining the minimum number of movements to achieve the objective. The available movements are:

- Horizontal movement (move to the contiguous column).
- Vertical movement (move to the contiguous row).

** Warning: It is not possible to move through a trench! **

Example: {{0, 0, 0, 0},
          {0, 1, 0, 0},
          {0, 1, 2, 0},
          {0, 0, 0, 0}};

Expected result: 4.
Explanation: 2 horizontal movements and then 2 vertical movements.
