import React from 'react'
import { useState } from 'react';

function Counter() {
  
    const [count, setCount] = useState(0);

  const increment = () => {
    setCount(count + 1);
    console.log("Incremented:", count + 1);
  };

//   console.log("usestate  return: ",count,setCount);

  const decrement = () => {
    setCount(count - 1);
    console.log("Decremented:", count - 1);
  };

  return (
    <div>
      <h2>Counter: {count}</h2>
      <button onClick={increment}>Increment</button>
      <button onClick={decrement}>Decrement</button>
    </div>
  )
}

export default Counter
