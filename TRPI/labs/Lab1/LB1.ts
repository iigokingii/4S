//1 
let array:number[] = [1,2,3,4,1,2,3,4,9,6];
function createPhoneNumber(numbers:number[]):string{
    let phoneNumber:string="(";
    for(let i:number=0;i<numbers.length;i++){
        if (i==3){
            phoneNumber+=")";
        }
        if(i==6){
            phoneNumber+="-";
        }
        phoneNumber +=numbers[i];
    }
    return phoneNumber;
}
let phone:string = createPhoneNumber(array);
console.log(`Phone Number:${phone}`);

//2
//let temp = parseInt(<string>prompt("Введите верхний предел"));
let temp:number = 12;
function multiplicity(numb : number):number{
    if(numb>0){
        let sum:number = 0;
        for(let i:number=0 ; i<numb; i++){
            if(i % 3==0 || i % 5 ==0){
                sum += i;
            }
        }
        return sum;
    }
    else
        return 0;
}
console.log(`Result of Multiplicity func: ${multiplicity(temp)}`);

//3

let nums:number[]=[1,2,3,4,5,6,7];
let k:number =-3;
console.log(`Array after permutation: ${arrayPermutation(nums,k)}`)
function arrayPermutation(nums:number[],K:number):number[]{
    if(K>0){
        for(let i:number = 0; i<K;i++){
            nums.unshift(nums[6]);
            nums.pop();
        }
    }
    else{
        K=Math.abs(K);
        for(let i:number = 0; i<K;i++){
            nums.push(nums[0]);
            nums.shift();
        }
    }
    return nums;
}
//4
let arr1:number[]=[2,5,7,9,6];
let arr2:number[]=[4,8,3/*,1*/];
console.log(`Median of Arrays : ${findMedian(arr1,arr2)}`);
function findMedian(array1:number[],array2:number[]):number{
    let union:number[] = array1.concat(array2);
    for(let i:number = 0; i<union.length;i++){
        let index : number = i;
        for(let j:number = i+1; j<union.length;j++){
            if(union[j]<union[index]){
                index=j;
            }
        }
        if(index!= i){
            let temp : number = union[i];
            union[i]=union[index];
            union[index]=temp;
        }
    }
    let median : number = 0;
    console.log(union);
    if(union.length%2==0){
        let i : number = Math.floor(union.length/2);
        let j : number = Math.ceil(union.length/2-1);
        median=(union[i]+union[j])/2
        return median;
    }
    else{
        median=union[Math.floor(union.length/2)];
        return median;
    }
}
//5
let sudoku: number[][] = [
    [5,3,0,0,7,0,0,0,0],
    [6,0,0,1,9,5,0,0,0],
    [0,9,8,0,0,0,0,6,0],
    [8,0,0,0,6,0,0,0,3],
    [4,0,0,8,0,3,0,0,1],
    [7,0,0,0,2,0,0,0,6],
    [0,6,0,0,0,0,2,8,0],
    [0,0,0,4,1,9,0,0,5],
    [0,0,0,0,8,0,0,7,9]
];
function SudokuCheck(table: number[][]):string{
    const SIZE: number = 9;
    for (let i : number = 0; i < SIZE; i++){
        let set = new Set<number>();
        for (let j : number = 0; j < SIZE; j++){
            if (table[j][i] === 0) continue;
            if (set.has(table[j][i])){
                return `Столбцы: доска неверна в [${j};${i}] = ${table[j][i]}`;
                
            }
            else set.add(table[j][i]);
        }
    }
    
    for (let i : number = 0; i < SIZE; i++){
        let set = new Set<number>();
        for (let j : number = 0; j < SIZE; j++){
            if (table[i][j] == 0) continue;
            if (set.has(table[i][j])){
                return ` Строки: доска неверна в [${i};${j}] = ${table[i][j]}`;
            }
                else set.add(table[i][j]);
        }
    }
    
    let squares : number[][] = [[0, 3], [3, 6], [6, 9]];
    for (let i : number = 0; i < 3; i++){
        for (let j : number = 0; j < 3; j++){
            let setForSquare = new Set<number>();
            for (let m : number = squares[i][0]; m < squares[i][1]; m++){
                for (let n : number = squares[j][0]; n < squares[j][1]; n++){
                    if (table[m][n] == 0) continue;
                    if (setForSquare.has(table[m][n])){
                        return ` Квадраты: доска неверна в [${m};${n}]`;
                    }
                        else setForSquare.add(table[m][n]);
                }
            }
        }
    }
    return" Таблица корректна";
}
console.log(SudokuCheck(sudoku));