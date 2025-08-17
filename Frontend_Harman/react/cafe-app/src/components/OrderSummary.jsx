import React from 'react';


export default function OrderSummary({ order, onRemove, onUpdateQty }) {
    const total = order.reduce((sum, it) => sum + it.price * it.qty, 0);

    return (
        <div className="order-summary">
            <h2>Order Summary</h2>
            {order.length === 0 ? (
                <p>Your order is empty.</p>
            ) : (
                <div>
                    {order.map((it) => (
                        <div className="order-item" key={it.id}>
                            <span>
                                {it.name} — ₹{it.price} x {it.qty}
                            </span>
                            <div className="btn-group">
                                <button onClick={() => onUpdateQty(it.id, it.qty - 1)}>-</button>
                                <button onClick={() => onUpdateQty(it.id, it.qty + 1)}>+</button>
                                <button
                                    className="remove-btn"
                                    onClick={() => onRemove(it.id)}
                                >
                                    Remove
                                </button>
                            </div>
                        </div>
                    ))}
                </div>
            )}
            <h3 className="summary-total">Total: ₹{total}</h3>
        </div>
    );
}
