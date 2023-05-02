import React from "react";
import FilterableProductTable from './components/FilterableProductTabl/FilterableProductTable.tsx';
const App=()=> {
  console.log();
  return (
    <div className="App" style={{display:"flex",justifyContent:"center"}}>
        <FilterableProductTable />
    </div>
  );
}

export default App;
