import { useAppDispatch } from "../typedhook/hook";
import { useState } from "react";
import { SearchByCity } from "../store/VacancySlice";
import { SearchBySalary } from "../store/VacancySlice";
import React from "react"
import '../styles/TextFilters.css';
interface IFilterByUserText{
    iconPath:string,
    salary:boolean
}
const FilterByUserText:React.FC<IFilterByUserText>=({iconPath,salary})=>{
    const dispatch = useAppDispatch();
    const [text,setText] = useState('');
    function TextHandler(e: any){
        if(e.key==='Enter' && !salary){
            dispatch(SearchByCity(text));
            setText('');
        }
        else if(e.key==='Enter' && salary){
            dispatch(SearchBySalary(text));
            setText('');
        }
    }
    return(
        <div className="text_filter_wrapper">
            <div className="headersSt">
                <img className="imgSt" src={iconPath} alt="xer"></img>
                <input onChange={(e)=>setText(e.target.value)} onKeyDown={TextHandler} value={text} className="user_input" type="text"></input>        
            </div>
        </div>
    )
}

export default FilterByUserText;