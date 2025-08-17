import React from 'react'

export default function MenuItem({ item, onAdd }) {
  return (
    <div className='menu-item'>
      <h3>{item.name}</h3>
      <p>{item.desc}</p>
      <div>
        <strong>Price: ₹{item.price}</strong>
         <button onClick={() => onAdd(item)}>Add</button>
      </div>
    </div>
  );
}


