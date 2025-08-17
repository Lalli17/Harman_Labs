function DisplayProduct({ products })
{
  const {id,name,price} = products;

    return (
        <div>
            <h2>Product Details</h2>
            <ul>
                <li>ID: {id}</li>
                <li>Name: {name}</li>
                <li>Price: {price}</li>
            </ul>
        </div>
    );
}


export default DisplayProduct;