import React, { useState } from 'react';
import MenuList from './components/MenuList';
import OrderSummary from './components/OrderSummary';
import { MENU } from './data/menu';
import './App.css'; // Assuming you have some styles in App.css
export default function App() {

  const [order, setOrder] = useState([]); // array of {id,name,price,qty}
  function addToOrder(item) {
    setOrder((prev) => {
      const found = prev.find((p) => p.id === item.id);
      if (found) {
        // increment qty
        return prev.map((p) =>
          p.id === item.id ? { ...p, qty: p.qty + 1 } : p
        );
      }
      // add new item with qty 1
      return [...prev, { ...item, qty: 1 }];
    });
  }
  function removeFromOrder(id) {
    setOrder((prev) => prev.filter((p) => p.id !== id));
  }
  function updateQty(id, qty) {
    if (qty <= 0) return removeFromOrder(id);
    setOrder((prev) => prev.map((p) => (p.id === id ? { ...p, qty } : p)));
  }
  return (
    <div className="app">
      <h1>Café Order Builder</h1>
      <div className="layout">
        <MenuList items={MENU} onAdd={addToOrder} />
        <OrderSummary order={order} onRemove={removeFromOrder}
          onUpdateQty={updateQty} />
      </div>
    </div>
  );
}