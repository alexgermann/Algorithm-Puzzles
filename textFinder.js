// Finds if any permutations of a pattern exist within a string

const fs = require("fs");
const readline = require("readline");

function test() {
  let patternTexts = [];
  let searchTexts = [];

  let numberOfTexts = 0;
  let lineNum = 0;
  var lineReader = require("readline").createInterface({
    input: require("fs").createReadStream("input.txt")
  });

  lineReader.on("line", function (line) {
    if (lineNum == 0) {
      numberOfTexts = line;
    } else if (lineNum % 2 == 1) {
      patternTexts.push(line);
    } else {
      searchTexts.push(line);
    }
    lineNum++;
  });

  lineReader.on("close", function () {
    for (let i = 0; i < searchTexts.length; i++) {
      let test = checkString(patternTexts[i], searchTexts[i]);
      console.log(test ? "YES" : "NO");
    }
  });
}

function checkString(pattern, searchString) {
  let patternCount = [];
  let searchStringCount = [];

  // Initialize arrays with first pattern length's counts of letters
  for (let i = 0; i < pattern.length; i++) {
    patternCount[pattern[i]] != null ? patternCount[pattern[i]]++ : (patternCount[pattern[i]] = 1);
    searchStringCount[searchString[i]] != null
      ? searchStringCount[searchString[i]]++
      : (searchStringCount[searchString[i]] = 1);
  }

  let firstFound = checkArrays(pattern, patternCount, searchStringCount);

  if (firstFound) {
    return true;
  }

  // Iterate through search text, keeping the search count array up to date with char counts
  for (let i = pattern.length; i < searchString.length; i++) {
    // Remove old char (already checked) from array count
    searchStringCount[searchString[i - pattern.length]]--;
    // Add new char to array count
    searchStringCount[searchString[i]] != null
      ? searchStringCount[searchString[i]]++
      : (searchStringCount[searchString[i]] = 1);

    let found = checkArrays(pattern, patternCount, searchStringCount);
    if (found) {
      return true;
    }
  }

  return false;
}

function checkArrays(pattern, patternCount, searchStringCount) {
  let found = true;
  // Check to see if there's a match
  for (let j = 0; j < pattern.length; j++) {
    if (patternCount[pattern[j]] != searchStringCount[pattern[j]]) {
      found = false;
      break;
    }
  }
  return found;
}

test();
