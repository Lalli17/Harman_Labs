
// //old way of declaring variables
// var name='John Doe';
// console.log(name);

// // Using let and const for variable declarations
// let name2='Jane Doe';
// console.log(name2);
// let age;
// age = 30;
// age = 31; // This is allowed because age is declared with let
// console.log(age);

// const name3 = 'Alice';
// console.log(name3);
// name3 = 'Bob'; // This will cause an error because name3 is a constant


// function add(a, b) {
//     return a + b;
// }// named function
// console.log(add(20, 30)); // Output: 50


// const result = function(a,b){return a + b;};//anonymous function
// console.log(result(20, 30)); // Output: 50


// // Arrow function
// const addArrow = (a, b) => {return a + b}; //lambda function
// console.log(addArrow(250, 30)); // Output: 280

// const sum = (a, b) => a + b; // concise arrow function
// console.log(sum(250, 320)); // Output: 570

// const a=10;
// const b=20;
// const sum2 = (a, b) => a + b; // concise arrow function with parameters
// console.log(`the sum of ${a} and ${b} is ${sum2(a, b)}`); // Output: 30


// //Destructuring
// const names=['John', 'Jane', 'Alice', 'Bob'];
// const name1= names[0];
// const name2= names[1];// Old way of accessing array elements
// console.log(name1, name2); // Output: John Jane


// //happens in a sequential manner

// const [name11,name22,name33,name44] = names; // Destructuring assignment
// console.log(name11, name22, name33, name44); // Output: John Jane Alice Bob

// // Destructuring with objects
// const person = {
//     firstName: 'John',
//     lastName: 'Doe',
//     age: 30,
//     address:{
//         city: 'Bangalore',
//         state: 'Karnataka',
//         country: 'India'
//     }
// };

// // Old way of accessing object properties
// console.log(person.firstName, person.lastName, person.age, person.address); // Output: John Doe 30 Bangalore Karnataka India

// // Destructuring assignment for objects
// const { firstName, lastName, age, address: { city, state, country } } = person; //address is renamed to city
// console.log(firstName, lastName, age, city, state, country); // Output: John Doe 30 Bangalore Karnataka India


//spread operator
// const numbers = [1, 2, 3];
// numbers.push(4, 5); // Old way of adding elements to an array
// console.log("normal",numbers); // Output: [1, 2, 3, 4, 5]
// console.log("spread",...numbers); // Output: 1 2 3 4 5


// // Using the spread operator to add elements to an array
// const moreNumbers = [6, 7, 8, 9, 10];

// console.log("spread and concatenated",...numbers,...moreNumbers,10,11,12); // Output: 1 2 3 4 5 6 7 8 9 10
// //const allNumbers = [...numbers, ...moreNumbers, 10, 11, 12]; // spread operator
// //console.log("spread", ...allNumbers); // Output: 1 2 3 4 5 6 7 8 9 10 10 11 12

    

// function sum(a,b,c,...numbers) {
//     console.log("numbers",a,b,c, numbers); // Output: 1, 2, 3 [4, 5]
// }
// console.log(sum(1, 2, 3, 4, 5)); // Output: 15


//map , reduce , filter


//map method
// const names = ['John', 'Jane', 'Alice', 'Bob'];

// let nameList=[];
// for(let i=0;i<names.length;i++){
//     nameList.push(convertToUpperCase(names[i]));// Using a for loop to convert names to uppercase
// }
// console.log(nameList); // Output: ['JOHN', 'JANE', 'ALICE', 'BOB']
//traditional way of converting names to uppercase


// const upperNames=names.map(function(name) {return name.toUpperCase();});// anonymous function
// console.log(upperNames); // Output: ['JOHN', 'JANE', 'ALICE', 'BOB']

// const upperNamesArrow = names.map(name => name.toUpperCase()); // arrow function
// console.log(upperNamesArrow); // Output: ['JOHN', 'JANE', 'ALICE', 'BOB']


// function convertToUpperCase(name) {
//     return name.toUpperCase();
// }


//reduce method

// const numbers = [1, 2, 3, 4, 5];
// let sum=0;
// numbers.forEach(n=> sum+=n); // Using forEach to calculate the sum of numbers
// console.log("sum using forEach", sum); // Output: 15


// const tot=numbers.reduce((total,value)=>total=total*value);
// console.log("sum using reduce", tot); // Output: 120

// //filter method
// const ages = [15, 20, 25, 30, 35, 40];
// const adults = ages.filter(age => age >= 32);// Using filter to get ages greater than or equal to 32
// console.log("adults", adults); // Output: [35, 40]

//default parameters
// function greet(name = 'Guest') {
//     console.log(`Hello, ${name}!`);
// }
// greet(); // Output: Hello, Guest!
// greet('Alice'); // Output: Hello, Alice!




// class Person{
//     constructor(name)
//     {
//         this.name = name;
//     }
//     greet(){
//         console.log(`Hello, ${this.name}!`);
//     }
// }
// let person = new Person('John');
// person.greet(); // Output: Hello, John!


//Constructors and Classes
class Product
{
    // name=''
    // price=0;
    constructor(name,price)
    {
        this.name=name;
        this.price=price;
    }
}
let p=new Product('Laptop', 1500);
console.log(p.name,p.price);