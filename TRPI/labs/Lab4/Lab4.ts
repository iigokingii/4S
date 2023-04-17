//1
interface forArray{
    id:number;
    name:string;
    group :number;
}
const array:forArray[] = [
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]


//2


/////////////////////////////////////////////////////
class CarsType {
    public model?:string;
    manufacturer?:string;
    cars?:Array<CarsType>;
}
/////////////////////////////////////////////////////



let car: CarsType ={}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';


//3
const car1: CarsType = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';

const car2: CarsType = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';

type ArrayCarsType = CarsType;


const arrayCars: Array<ArrayCarsType> = [{
    cars: [car1, car2]
}];

//4

type DoneType = boolean;
type MarkFilterType =1|2|3|4|5|6|7|8|9|10;
type GroupFilterType =1|2|3|4|5|6|7|8|9|10|11|12;

type MarkType = {
    subject: string,
    mark: MarkFilterType, // может принимать значения от 1 до 10
    done: DoneType,
}
type StudentType = {
    id: number,
    name: string,
    group: GroupFilterType, // может принимать значения от 1 до 12
    marks: Array<MarkType>,
}


const mark1:MarkType={
    subject:"math",
    mark:5,
    done:true
}
const mark2:MarkType={
    subject:"physics",
    mark:9,
    done:true
}
const mark3 :MarkType={
    subject:"Belarusian",
    mark:10,
    done:true
}
const mark4:MarkType={
    subject:"BD",
    mark:7,
    done:true
}
const mark5 :MarkType={
    subject:"OOP",
    mark:3,
    done:false
}

const student1:StudentType={
    id:1,
    name:"Igor'",
    group:12,
    marks:[mark1,mark3,mark5]
}
const student2:StudentType={
    id:2,
    name:"Vadim",
    group:8,
    marks:[mark3,mark4,mark5]
}
const student3:StudentType={
    id:3,
    name:"Maxim",
    group:8,
    marks:[mark2,mark1,mark4]
}
const student4:StudentType={
    id:4,
    name:"Polina",
    group:5,
    marks:[mark1,mark2,mark3]
}
type GroupType = {
    students:Array<StudentType> // массив студентов типа StudentType
    studentsFilter: (group: number) => Array<StudentType>, // фильтр по группе
    marksFilter: (mark: number) => Array<StudentType>, // фильтр по  оценке
    deleteStudent: (id: number) => void, // удалить студента по id из  исходного массива
    mark: MarkFilterType,
    group: GroupFilterType,
}
const groups:GroupType={
    students:[student1,student2,student3,student4],
    group:5,
    mark:9,
    studentsFilter(_group:number):Array<StudentType>{
        let temp : Array<StudentType>=[];
        for(let i:number=0;i<groups.students.length;i++){
            if (groups.students[i].group==_group){
                temp.push(groups.students[i])
            }   
        }
        return temp;
    },
    //TODO
    marksFilter(_mark:number):Array<StudentType>{
        let temp : Array<StudentType>=[];
        
    for (const student of this.students) {
        for(const mark1 of student.marks)
            if(mark1.mark == _mark)
            {
                temp.push(student);
            }
        }
        return temp;
    },
    deleteStudent(_id:number){
        groups.students.splice(_id-1,1);
    }
}
console.log('Вывод студентов: ');
console.log(groups.students);
var t = groups.studentsFilter(8);
console.log("Студенты 8 группы: ");
console.log(t);
console.log("Удаление студента с id= 1: ");
groups.deleteStudent(1);
console.log(groups.students);
console.log("Студенты с 5-ой: ");
let arr : Array<StudentType>=groups.marksFilter(5);
for(let i:number=0;i<arr.length;i++){
    console.log(arr[i].marks);
}











