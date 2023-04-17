// 1.	Хранилище всего имеющегося товара в интернет-магазине представляет собой объект products. 
//  Весь товар разделен на категории, одна из них «Обувь», которая в свою очередь делится на виды «Ботинки», 
//  «Кроссовки», «Сандалии». О каждой паре обуви хранится следующая
//  информация: уникальный номер товара, размер обуви, цвет, цена. 
class Product {
    constructor(id, number, name, price, size, color, sale = 0) {
        this.sale = 0;
        this.sale = 0;
        this.id = id;
        this.type = number;
        this.name = name;
        this.size = size;
        this.color = color;
        this.sale = sale;
        this.startPrice = price;
        this.finalCost = (100 - this.sale) * this.startPrice / 100;
    }
    get Name() {
        return this.name;
    }
    get ID() {
        return this.id;
    }
    get Size() {
        return this.size;
    }
    get Color() {
        return this.color;
    }
    get Price() {
        return this.finalCost;
    }
    set Price(v) {
        this.startPrice = v;
        this.finalCost = (100 - this.sale) * this.startPrice / 100;
    }
}
let products = [
    new Product(1, "Кроссовки", "Nike Air Forse", 150, 42, "black"),
    new Product(2, "Кроссовки", "Addidas 32", 200, 40, "black", 20),
    new Product(3, "Кроссовки", "Boot Sicker", 50, 42, "Бежевый"),
    new Product(4, "Ботинки", "Vance", 900, 36, "black", 30),
    new Product(5, "Сандали", "New Balance", 500, 38, "Бежевый", 10),
];
//2
class ProductIterator {
    constructor(products) {
        this.index = 0;
        this.products = products;
    }
    next() {
        if (this.index < this.products.length) {
            return { done: false, value: this.products[this.index++] };
        }
        else {
            return { done: true, value: null };
        }
    }
}
let iterator = new ProductIterator(products);
let prod = iterator.next();
console.log('---------------------------------------------------');
while (prod.done == false) {
    console.log(prod.value);
    prod = iterator.next();
}
//задание 3
function filtreByPrice() {
    let min = 140;
    let max = 600;
    let arr = products.filter((value) => value.startPrice >= min &&
        value.startPrice <= max);
    console.log('Фильтр по цене в заданном диапазоне: ');
    arr.forEach(element => {
        console.log('id: ' + element.id);
        console.log('Mark: ' + element.type);
        console.log('Price: ' + element.startPrice);
    });
}
function filtreByColor() {
    let color = "black";
    let arr = products.filter((value) => value.color == color);
    console.log('Сортировка по цвету: ');
    arr.forEach(element => {
        console.log('id: ' + element.id);
        console.log('Mark: ' + element.type);
        console.log('Color: ' + element.color);
    });
}
function filtreBySize() {
    let size = 42;
    let arr = products.filter((value) => value.size == size);
    console.log('Сортировка по размеру: ');
    arr.forEach(element => {
        console.log('id: ' + element.id);
        console.log('Mark: ' + element.type);
        console.log('Size: ' + element.size);
    });
}
filtreByPrice();
filtreByColor();
filtreBySize();
let boot2 = {
    ID: 44,
    Size: 39,
    Color: "Yellow",
    Price: 600
};
let boot1 = {
    ID: 53,
    Size: 32,
    Color: "Green",
    Price: 120
};
let produc = {
    Products: [boot1, boot2]
};
//# sourceMappingURL=Lab2.js.map