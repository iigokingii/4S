import React from 'react';
import logo from './logo.svg';
import './App.css';
import Header from './components/Header';
import FilterSearch from './components/FiltersSearh';
import Body from './components/Body';
function App() {
  return (
    <div className="App">
        <Header/>
        <FilterSearch/>
        <Body/>
    </div>
  );
}

export default App;
