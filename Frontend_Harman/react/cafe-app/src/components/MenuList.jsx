import React from 'react'
import MenuItem from './MenuItem';

export default function MenuList({ items, onAdd }) {
  return (
    <div className='menu-list'>
        <h2>Menu</h2>
      {items.map(item => (
        <MenuItem key={item.id} item={item} onAdd={onAdd} />
      ))}
    </div>
  );
}