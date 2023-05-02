import React,{useState} from "react";
import SearchBar from "../SearchBar/SearchBar.tsx";
import ProductTable from "../ProductTable/ProductTable.tsx";
import products from "../state/State.module.ts";
import { StateType } from "../../types/types.js";

const FilterableProductTable =()=>{
  const [text, setText] = useState("");
  const [checked, setChecked] = useState(true);
  let state:StateType = {
    filterText: text,
    inStockOnly: checked,
    onFilterTextChange: (text:string) => setText(text),
    onInStockChange: (status : boolean) => setChecked(status)
}
  return(
    <div style={{padding:"50px 100px 50px 50px",border:"12px groove black" }}>
      <SearchBar state={state} />
      <ProductTable products={products} state ={state}/>
    </div>
  )
}
export default FilterableProductTable;






// import React from "react";
// import SearchBar from "../SearchBar/SearchBar.tsx"
// import ProductTable from "../ProductTable/ProductTable.tsx";
// class FilterableProductTable extends React.Component {
//     constructor(props) {
//       super(props);
//       this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
//       this.handleInStockChange = this.handleInStockChange.bind(this);
//     }
  
//     handleFilterTextChange(filterText) {
//       this.setState({
//         filterText: filterText
//       });
//     }
    
//     handleInStockChange(inStockOnly) {
//       this.setState({
//         inStockOnly: inStockOnly
//       })
//     }
  
//     render() {
//       return (
//         <div>
//           <SearchBar
//             filterText={this.state.filterText}
//             inStockOnly={this.state.inStockOnly}
//             onFilterTextChange={this.handleFilterTextChange}
//             onInStockChange={this.handleInStockChange}
//           />
//           <ProductTable
//             products={this.props.products}
//             filterText={this.state.filterText}
//             inStockOnly={this.state.inStockOnly}
//           />
//         </div>
//       );
//     }
// }
// export default FilterableProductTable;