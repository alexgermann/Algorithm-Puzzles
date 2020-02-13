// Problem: https://www.algoexpert.io/questions/River%20Sizes

function riverSizes(matrix) {
  let trackerArray = [];
  let riverArray = [];
  // Initialize array to track visited nodes
  for (var i = 0; i < matrix.length; i++) {
    trackerArray.push(Array(matrix[i].length));
  }

  // depth first search
  for (let x = 0; x < matrix.length; x++) {
    for (let y = 0; y < matrix[x].length; y++) {
      let riverSize = computeSize(matrix, trackerArray, x, y);
      if (riverSize !== 0) {
        riverArray.push(riverSize);
      }
    }
  }
  return riverArray;
}

function computeSize(matrix, trackerArr, x, y) {
  let size = 0;
  try {
    if (trackerArr[x][y] === 1) {
      // Already computed node
      return 0;
    }
    size = matrix[x][y];
    // Mark node as computed
    trackerArr[x][y] = 1;
  } catch (err) {
    // index out of bounds - too lazy to check
    return 0;
  }
  if (size === undefined) {
    // imagine throwing an error for some array out of bounds indexes and returning undefined for others... smh
    return 0;
  }
  if (size === 1) {
    // Recursively compute river size
    size += computeSize(matrix, trackerArr, x + 1, y);
    size += computeSize(matrix, trackerArr, x - 1, y);
    size += computeSize(matrix, trackerArr, x, y + 1);
    size += computeSize(matrix, trackerArr, x, y - 1);
  }

  return size;
}

// Do not edit the line below.
exports.riverSizes = riverSizes;
