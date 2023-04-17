var array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
//2
/////////////////////////////////////////////////////
var CarsType = /** @class */ (function () {
    function CarsType() {
    }
    return CarsType;
}());
/////////////////////////////////////////////////////
var car = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';
//3
var car1 = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';
var car2 = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';
var arrayCars = [{
        cars: [car1, car2]
    }];
var mark1 = {
    subject: "math",
    mark: 5,
    done: true
};
var mark2 = {
    subject: "physics",
    mark: 9,
    done: true
};
var mark3 = {
    subject: "Belarusian",
    mark: 10,
    done: true
};
var mark4 = {
    subject: "BD",
    mark: 7,
    done: true
};
var mark5 = {
    subject: "OOP",
    mark: 3,
    done: false
};
var student1 = {
    id: 1,
    name: "Igor'",
    group: 12,
    marks: [mark1, mark3, mark5]
};
var student2 = {
    id: 2,
    name: "Vadim",
    group: 8,
    marks: [mark3, mark4, mark5]
};
var student3 = {
    id: 3,
    name: "Maxim",
    group: 8,
    marks: [mark2, mark1, mark4]
};
var student4 = {
    id: 4,
    name: "Polina",
    group: 5,
    marks: [mark1, mark2, mark3]
};
var groups = {
    students: [student1, student2, student3, student4],
    group: 5,
    mark: 9,
    studentsFilter: function (_group) {
        var temp = [];
        for (var i = 0; i < groups.students.length; i++) {
            if (groups.students[i].group == _group) {
                temp.push(groups.students[i]);
            }
        }
        return temp;
    },
    //TODO
    marksFilter: function (_mark) {
        var temp = [];
        for (var _i = 0, _a = this.students; _i < _a.length; _i++) {
            var student = _a[_i];
            for (var _b = 0, _c = student.marks; _b < _c.length; _b++) {
                var mark1_1 = _c[_b];
                if (mark1_1.mark == _mark) {
                    temp.push(student);
                }
            }
        }
        return temp;
    },
    deleteStudent: function (_id) {
        groups.students.splice(_id - 1, 1);
    }
};
console.log('Вывод студентов: ');
console.log(groups.students);
var t = groups.studentsFilter(8);
console.log("Студенты 8 группы: ");
console.log(t);
console.log("Удаление студента с id= 1: ");
groups.deleteStudent(1);
console.log(groups.students);
console.log("Студенты с 5-ой: ");
var arr = groups.marksFilter(5);
for (var i = 0; i < arr.length; i++) {
    console.log(arr[i].marks);
}
