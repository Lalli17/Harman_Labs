import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Header from './header/Header'
import DisplayProduct from './Display_Products/DisplayProducts'
import Counter from './Counter/Counter'

function App() {
  
    let products = {
        id: 1,
        name: "IPhone 13",
        price: 100
    }

  return(
    <>
      <Header msg='First react app'></Header>
      {/* <DisplayProduct products={products}></DisplayProduct>
      <Header msg='This is the header 1'></Header>
      <DisplayProduct products={{ id: 2, name: "IPhone 14", price: 120 }}></DisplayProduct>
      <Header msg='This is the header 2'></Header>
      <DisplayProduct products={{ id: 3, name: "IPhone 15", price: 140 }}></DisplayProduct> */}

      <Counter></Counter>
    </>
  );
}

export default App
