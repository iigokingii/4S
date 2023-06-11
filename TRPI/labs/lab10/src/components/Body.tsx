import BodyInfo from "./BodyInfo";
import BodyList from "./BodyList";
import { useState,useEffect } from "react";
import '../styles/body.css'
const Body = () =>{
    const [windowWidth,setWindowWidth] = useState(window.innerWidth);
    const [visibleInfo,SetVisibleInfo] = useState(true);
    useEffect(()=>{
        const handleWindowResise = ()=>{
            setWindowWidth(window.innerWidth);
            if (windowWidth<1024 &&windowWidth>768){
                SetVisibleInfo(false);
            }
            if (windowWidth>1280){
                SetVisibleInfo(true);
            } 
        };
        window.addEventListener('resize',handleWindowResise);
        return()=>{
            window.removeEventListener('resize',handleWindowResise);
        }
    })
    return(
        <div>
            <div className="BodyWrapper">
                    <BodyList/>
                    
                    {visibleInfo && <BodyInfo/>}
            </div>
        </div>
    )
}
export default Body;