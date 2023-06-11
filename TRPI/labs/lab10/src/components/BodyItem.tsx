import { useAppDispatch } from "../typedhook/hook";
import { ShowFiltersUl, PressedLike } from "../store/VacancySlice";
import {text} from '../store/TextObjects'

import BodyReqLang from "./BodyReqLang";
import '../styles/body.css'
interface IBodyItem {
    vacancy:text
}

const BodyItem:React.FC<IBodyItem> = ({vacancy})=>{
    const dispatch = useAppDispatch();
    return(
        <div className="itemBack">
            <div className="Itemwrapper" onClick={()=>dispatch(ShowFiltersUl(vacancy.id))}>
                <div className="IconContainer"><img src={vacancy.iconPath} alt="xer"/></div>
                <div className="ItemBody">
                    <p className="header">{vacancy.header}</p>
                    <p className="title">{vacancy.title}</p>
                    <p className="city">{vacancy.city}</p>
                    <BodyReqLang key={vacancy.id} vacancy={vacancy}/>
                 </div>
                 <div className="LikeAndDate">
                    <div >
                        <div onClick={()=>dispatch(PressedLike(vacancy.id))}>
                            <img className="icon_img" src={ vacancy.like ? vacancy.likedHeart:vacancy.standartHeart } alt="xer"></img>
                        </div>
                        <p className="date">{vacancy.date}</p>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default BodyItem;