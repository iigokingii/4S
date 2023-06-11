import { useAppDispatch } from "../typedhook/hook";
import {ShowLiked,ShowAll} from '../store/VacancySlice';
import {useState} from 'react';
import '../styles/header.css'
const Header=()=>{
    const dispatch = useAppDispatch();
    const [mainPage,changePage] = useState(true);
    function handleClickSearch(){
        dispatch(ShowAll());
        changePage(true);
    }
    function handleClickLiked(){
        dispatch(ShowLiked())
        changePage(false);
    }
    return(
       <header className="head">
            <div className="mainContent">
                <img width={170} height={20} src="/images/logo.png" alt="xer"></img>
                <button className="vacancy_filter" style={mainPage ? {color:'#0070FB'} : {color:'#6B8397'}} onClick={handleClickSearch}>
                    Поиск вакансий
                </button>
                <button className="vacancy_filter" style={!mainPage ? {color:'#0070FB'} : {color:'#6B8397'}} onClick={handleClickLiked}>
                    Избранные вакансии
                </button>
            </div>
       </header>
    )
};
export default Header; 
