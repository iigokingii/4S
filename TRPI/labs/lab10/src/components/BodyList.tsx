import { useAppSelector } from "../typedhook/hook";
import BodyItem from "./BodyItem";
import '../styles/body.css';
const BodyList=()=>{
    const vacancies = useAppSelector(state=>state.vacancies.vacancies);
    return(
        <div>
            {vacancies.map((vacancy)=>(
                <BodyItem key={vacancy.id} vacancy={vacancy}/>
            ))}
        </div>
    )
}
export default BodyList;