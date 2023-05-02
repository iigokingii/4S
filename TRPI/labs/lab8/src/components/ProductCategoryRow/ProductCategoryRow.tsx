import React from "react";
import { ProductCategoryRowType } from "../../types/types";

const ProductCategoryRow = (props:ProductCategoryRowType)=>{
    const category = props.category;
    return (
        <tr>
          <th>
            {category}
          </th>
        </tr>
      );
};
export default ProductCategoryRow;

// import React from "react";
// class ProductCategoryRow extends React.Component {
//   render() {
//     const category = this.props.category;
//     return (
//       <tr>
//         <th>
//           {category}
//         </th>
//       </tr>
//     );
//   }
// }
// export default ProductCategoryRow;