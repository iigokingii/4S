// 1.	Хранилище всего имеющегося товара в интернет-магазине представляет собой объект products. 
//  Весь товар разделен на категории, одна из них «Обувь», которая в свою очередь делится на виды «Ботинки», 
//  «Кроссовки», «Сандалии». О каждой паре обуви хранится следующая
//  информация: уникальный номер товара, размер обуви, цвет, цена. 
class Product
{
  public readonly id : number;
  public readonly size: number;
  public readonly color: string;
  public readonly type: number;
  public  startPrice: number;
  private sale : number = 0;
  private name: string;
  public finalCost: number;
  constructor(id,number, name, price, size, color, sale = 0) {
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
  public get Name():string
  {
    return this.name;
  }

  public get ID(): number
  {
    return this.id;
  }
  public get Size() : number 
  {
    return this.size;
  }

public get Color() : string   
  {
    return this.color;
  }

public get Price() : number 
  {
    return this.finalCost;
  }

public set Price(v : number) 
{
    this.startPrice = v;
    this.finalCost = (100 - this.sale) * this.startPrice / 100;
}

}

let products = [
  new Product(1,"Кроссовки", "Nike Air Forse", 150, 42, "black"),
  new Product(2,"Кроссовки", "Addidas 32", 200, 40, "black", 20),
  new Product(3,"Кроссовки", "Boot Sicker", 50, 42, "Бежевый"),
  new Product(4,"Ботинки", "Vance", 900, 36, "black",  30),
  new Product(5,"Сандали", "New Balance", 500, 38, "Бежевый",  10),
];
//2
class ProductIterator 
{
    private index : number = 0;
    private products : Product[];

    constructor(products : Product[])
    {
        this.products = products;
    }

    public next() : IteratorResult<Product>
    {
        if(this.index < this.products.length)
        {
            return {done: false, value: this.products[this.index++]};
        }
        else
        {
            return {done: true, value: null};
        }
    }
}
  let iterator = new ProductIterator(products);
  let prod=iterator.next();
  console.log('---------------------------------------------------');
  while(prod.done==false){
    console.log(prod.value);
    prod=iterator.next();
  }
  //задание 3
 
function filtreByPrice() 
{
 
    let min : number =140;
    let max : number =600;

    let arr: Product[] = products.filter(
        (value) => value.startPrice >= min &&
                   value.startPrice <= max
                   );

    console.log('Фильтр по цене в заданном диапазоне: ');
    arr.forEach(element => {
      console.log('id: '+ element.id);
      console.log('Mark: '+ element.type);
      console.log('Price: '+ element.startPrice);
    }); 
}

function filtreByColor()
{
    let color : string = "black";

    let arr: Product[] = products.filter(
        (value) => value.color == color
                   );

    console.log('Сортировка по цвету: ');
    arr.forEach(element => {
      console.log('id: '+ element.id);
      console.log('Mark: '+ element.type);
      console.log('Color: '+ element.color);
    }); 
}

function filtreBySize()
{
    let size : number = 42;

    let arr: Product[] = products.filter(
        (value) => value.size == size
                   );

    console.log('Сортировка по размеру: ');
    arr.forEach(element => {
      console.log('id: '+ element.id);
      console.log('Mark: '+ element.type);
      console.log('Size: '+ element.size);
    }); 
}

filtreByPrice();
filtreByColor();
filtreBySize();
// Оптимизируйте объект-хранилище, при этом свойства «id», «цвет»  
// и «размер» должны быть доступны только для чтения, свойство «id» не может быть удалено. 

/////////////
interface IBoot
{
    readonly ID : number;
    readonly Size : number;
    readonly Color : string;
    Price : number;
}
interface IProducts
{
    Products: IBoot[]
}

let boot2 : IBoot =
{
  ID: 44,
  Size: 39,
  Color: "Yellow",
  Price: 600
};
let boot1 : IBoot =
{
  ID: 53,
  Size: 32,
  Color: "Green",
  Price: 120
};

let produc : IProducts = 
{
    Products: [boot1, boot2]
}