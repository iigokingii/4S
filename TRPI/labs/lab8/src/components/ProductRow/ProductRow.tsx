import React from "react";
const ProductRow = (props) => {
  const {product} = props;
  const name = product.stocked ?
      product.name : <span style={{color: 'red'}}> {product.name} </span>

  return (
      <tr>
          <td>{name}</td>
          <td>{product.price}</td>
      </tr>
  );
};
export default ProductRow;


// import React from "react";
// class ProductRow extends React.Component {
//   render() {
//     const product = this.props.product;
//     const name = product.stocked ?
//       product.name :
//       <span style={{color: 'red'}}>
//         {product.name}
//       </span>;

//     return (
//       <tr>
//         <td>{name}</td>
//         <td>{product.price}</td>
//       </tr>
//     );
//   }
// }
// export default ProductRow;