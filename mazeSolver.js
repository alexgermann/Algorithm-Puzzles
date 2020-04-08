// Maze solver (incomplete/non-functional)

// 1 1 1 1 1 1 1 1 1 1 1 1
// 1 0 1 0 1 0 1 1 1 1 0 1
// 1 0 0 0 1 0 0 0 0 0 0 1
// 1 1 1 0 1 0 0 0 0 1 0 1
// 1 0 0 0 0 1 1 1 0 1 0 1
// 1 1 1 1 0 1 F 1 0 1 0 1
// 1 0 0 1 0 1 0 1 0 1 0 1
// 1 1 0 1 0 1 0 1 0 1 0 1
// 1 0 0 0 0 0 0 0 0 1 0 1
// 1 1 1 1 1 1 0 1 1 1 0 1
// 1 0 0 0 0 0 0 1 0 0 0 1
// 1 1 1 1 1 1 1 1 1 1 1 1

// top left to bottom right

// 1 1 1 0 1 1
// 1 0 1 0 1 1
// 1 0 0 0 1 1
// 1 1 1 0 0 1
// 1 1 0 0 0 1
// 1 1 0 1 1 1
// 1 1 0 0 0 1

function findMazeCenter() {
  let matrix = [
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1],
    [1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1],
    [1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1],
    [1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1],
    [1, 1, 1, 1, 0, 1, "F", 1, 0, 1, 0, 1],
    [1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1],
    [1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1],
    [1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1],
    [1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
  ];
  let path = [];
  traversePath2(matrix, path, 1, 1);
  console.log(path);
  return path;
}

function traversePath2(matrix, path, y, x) {
  // console.log(y + "," + x + " is a " + matrix[y][x]);
  if (matrix[y][x] !== 0) {
    return false; //null?
  }
  path.push([y, x]);
  if (y === matrix.length - 1 && x === matrix[y - 1].length - 1) {
    // We are at bottom right corner of maze
    // console.log("Found it");
    return true;
  }
  let completed = false;
  if (matrix.length > y + 1) {
    completed = traversePath2(matrix, path, y + 1, x);
  }
  if (!completed && matrix[y].length > x + 1) {
    completed = traversePath2(matrix, path, y, x + 1);
  }
  if (!completed && y - 1 > 0) {
    completed = traversePath2(matrix, path, y - 1, x);
  }
  if (!completed && x - 1 > 0) {
    completed = traversePath2(matrix, path, y, x - 1);
  }
  return completed;
}
