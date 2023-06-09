import React from 'react';
import ProductCategoryRow from '../ProductCategoryRow/ProductCategoryRow.tsx';
import ProductRow from '../ProductRow/ProductRow.tsx';
import { IProduct, ProductTableType } from '../../types/types.js';
import './ProductTable.css';

const ProductTable = (props:ProductTableType) => {
    const products = props.products;
    let {state} = props;
    const rows : any = [];
    let lastCategory : string = '';
    products.forEach((product:IProduct) => {
        if (product.name.indexOf(state.filterText) === -1) {
            return;
        }
        if (state.inStockOnly && !product.stocked) {
            return;
        }
        if (product.category !== lastCategory) {
            rows.push(
                <ProductCategoryRow category={product.category}/>
            );
        }
        rows.push(
            <ProductRow product={product}/>
        );
        lastCategory = product.category;
    });

    return (
        <table className='TabSt'>
            <thead>
            <tr>
                <th>Name</th>
                <th>Price</th>
            </tr>
            </thead>
            <tbody>{rows}</tbody>
        </table>
    );
};
export default ProductTable;
// import React from "react";
// import ProductCategoryRow from "../ProductCategoryRow/ProductCategoryRow.tsx";
// import ProductRow from "../ProductRow/ProductRow.tsx";
// class ProductTable extends React.Component {
//   render() {
//     const filterText = this.props.filterText;
//     const inStockOnly = this.props.inStockOnly;

//     const rows = [];
//     let lastCategory = null;

//     this.props.products.forEach((product) => {
//       if (product.name.indexOf(filterText) === -1) {
//         return;
//       }
//       if (inStockOnly && !product.stocked) {
//         return;
//       }
//       if (product.category !== lastCategory) {
//         rows.push(
//           <ProductCategoryRow
//             category={product.category}
//             key={product.category} />
//         );
//       }
//       rows.push(
//         <ProductRow
//           product={product}
//           key={product.name}
//         />
//       );
//       lastCategory = product.category;
//     });

//     return (
//       <table>
//         <thead>
//           <tr>
//             <th>Name</th>
//             <th>Price</th>
//           </tr>
//         </thead>
//         <tbody>{rows}</tbody>
//       </table>
//     );
//   }
// }
// export default ProductTable;