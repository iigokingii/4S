//1 
var array = [1, 2, 3, 4, 1, 2, 3, 4, 9, 6];
function createPhoneNumber(numbers) {
    var phoneNumber = "(";
    for (var i = 0; i < numbers.length; i++) {
        if (i == 3) {
            phoneNumber += ")";
        }
        if (i == 6) {
            phoneNumber += "-";
        }
        phoneNumber += numbers[i];
    }
    return phoneNumber;
}
var phone = createPhoneNumber(array);
console.log("Phone Number:".concat(phone));
//2
//let temp = parseInt(<string>prompt("Введите верхний предел"));
var temp = 12;
function multiplicity(numb) {
    if (numb > 0) {
        var sum = 0;
        for (var i = 0; i < numb; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        return sum;
    }
    else
        return 0;
}
console.log("Result of Multiplicity func: ".concat(multiplicity(temp)));
//3
var nums = [1, 2, 3, 4, 5, 6, 7];
var k = -3;
console.log("Array after permutation: ".concat(arrayPermutation(nums, k)));
function arrayPermutation(nums, K) {
    if (K > 0) {
        for (var i = 0; i < K; i++) {
            nums.unshift(nums[6]);
            nums.pop();
        }
    }
    else {
        K = Math.abs(K);
        for (var i = 0; i < K; i++) {
            nums.push(nums[0]);
            nums.shift();
        }
    }
    return nums;
}
//4
var arr1 = [2, 5, 7, 9, 6];
var arr2 = [4, 8, 3 /*,1*/];
console.log("Median of Arrays : ".concat(findMedian(arr1, arr2)));
function findMedian(array1, array2) {
    var union = array1.concat(array2);
    for (var i = 0; i < union.length; i++) {
        var index = i;
        for (var j = i + 1; j < union.length; j++) {
            if (union[j] < union[index]) {
                index = j;
            }
        }
        if (index != i) {
            var temp_1 = union[i];
            union[i] = union[index];
            union[index] = temp_1;
        }
    }
    var median = 0;
    console.log(union);
    if (union.length % 2 == 0) {
        var i = Math.floor(union.length / 2);
        var j = Math.ceil(union.length / 2 - 1);
        median = (union[i] + union[j]) / 2;
        return median;
    }
    else {
        median = union[Math.floor(union.length / 2)];
        return median;
    }
}
//5
var sudoku = [
    [5, 3, 0, 0, 7, 0, 0, 0, 0],
    [6, 0, 0, 1, 9, 5, 0, 0, 0],
    [0, 9, 8, 0, 0, 0, 0, 6, 0],
    [8, 0, 0, 0, 6, 0, 0, 0, 3],
    [4, 0, 0, 8, 0, 3, 0, 0, 1],
    [7, 0, 0, 0, 2, 0, 0, 0, 6],
    [0, 6, 0, 0, 0, 0, 2, 8, 0],
    [0, 0, 0, 4, 1, 9, 0, 0, 5],
    [0, 0, 0, 0, 8, 0, 0, 7, 9]
];
function SudokuCheck(table) {
    var SIZE = 9;
    for (var i = 0; i < SIZE; i++) {
        var set = new Set();
        for (var j = 0; j < SIZE; j++) {
            if (table[j][i] === 0)
                continue;
            if (set.has(table[j][i])) {
                return "\u0421\u0442\u043E\u043B\u0431\u0446\u044B: \u0434\u043E\u0441\u043A\u0430 \u043D\u0435\u0432\u0435\u0440\u043D\u0430 \u0432 [".concat(j, ";").concat(i, "] = ").concat(table[j][i]);
            }
            else
                set.add(table[j][i]);
        }
    }
    for (var i = 0; i < SIZE; i++) {
        var set = new Set();
        for (var j = 0; j < SIZE; j++) {
            if (table[i][j] == 0)
                continue;
            if (set.has(table[i][j])) {
                return " \u0421\u0442\u0440\u043E\u043A\u0438: \u0434\u043E\u0441\u043A\u0430 \u043D\u0435\u0432\u0435\u0440\u043D\u0430 \u0432 [".concat(i, ";").concat(j, "] = ").concat(table[i][j]);
            }
            else
                set.add(table[i][j]);
        }
    }
    var squares = [[0, 3], [3, 6], [6, 9]];
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var setForSquare = new Set();
            for (var m = squares[i][0]; m < squares[i][1]; m++) {
                for (var n = squares[j][0]; n < squares[j][1]; n++) {
                    if (table[m][n] == 0)
                        continue;
                    if (setForSquare.has(table[m][n])) {
                        return " \u041A\u0432\u0430\u0434\u0440\u0430\u0442\u044B: \u0434\u043E\u0441\u043A\u0430 \u043D\u0435\u0432\u0435\u0440\u043D\u0430 \u0432 [".concat(m, ";").concat(n, "]");
                    }
                    else
                        setForSquare.add(table[m][n]);
                }
            }
        }
    }
    return " Таблица корректна";
}
console.log(SudokuCheck(sudoku));
