import React from "react";
import FilterableProductTable from './components/FilterableProductTabl/FilterableProductTable.tsx';
import PRODUCTS from './components/state/State.module.ts';
const App=()=> {
  console.log(PRODUCTS);
  return (
    <div className="App">
        <FilterableProductTable PRODUCTS={PRODUCTS}/>
    </div>
  );
}

export default App;
