function findLargestSum() {
  if (matrix.length == 0) {
    console.log("Empty arrays can't have sums.");
    return;
  }
  console.log(`Finding maximum contiguous sum in matrix: [${matrix}]`);
  let max = matrix[0];
  let currentMax = matrix[0];
  let startMaxIndex = 0;
  let endMaxIndex = 1;
  for (let i = 1; i < matrix.length; i++) {
    let val = matrix[i];
    currentMax = Math.max(val + currentMax, val);
    max = Math.max(max, currentMax);

    // Update max sum indices
    if (currentMax == val) {
      startMaxIndex = i;
      endMaxIndex = i + 1;
    } else {
      endMaxIndex++;
    }
  }
  console.log(`Max sum: ${max} from contiguous sequence ${matrix.slice(startMaxIndex, endMaxIndex)}`);
}

let matrix = [34, -50, 42, 14, -5, 86];
// let matrix = [34, -50, 42, 14, -5, -23, -50, 86];
// let matrix = [-223, -34, -102, -10];
// let matrix = [-2];
// let matrix = [5, -4];
// let matrix = [];
findLargestSum(matrix);
