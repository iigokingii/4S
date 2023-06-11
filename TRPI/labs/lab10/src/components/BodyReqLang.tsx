import { useAppDispatch } from '../typedhook/hook';
import {text} from '../store/TextObjects'
import { ShowKnowledge } from '../store/VacancySlice';
import React from "react";
interface IBodyReqLang{
    vacancy:text,
}
const BodyReqLang:React.FC<IBodyReqLang> = ({vacancy}) =>{
    const dispatch = useAppDispatch();
    return(
        <div className="langWrapper">
            {vacancy.languages.map((lang)=>(
                <div onClick={()=>dispatch(ShowKnowledge(lang))} className="lang" key={vacancy.languages.indexOf(lang)}>{lang}</div>
            ))}
        </div>
    )
}
export default BodyReqLang;