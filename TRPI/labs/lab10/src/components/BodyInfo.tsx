import { useAppSelector } from "../typedhook/hook";
import '../styles/ItemInfo.css'
const BodyInfo=()=>{
    const ShowInfo = useAppSelector(state=>state.vacancies.ShowInfo);
    return(
        <div className="wrapper">
            <div className="HeadWrapper">
                <img className="img" src={ShowInfo.iconPath} alt="xer"/>
                <div className="TittleWrapper">
                    <p className="TittleStyle">{ShowInfo.title}</p>
                    <p className="InfoStyle">{ShowInfo.header}     |     {ShowInfo.city}</p>
                </div>
            </div>
            <div className="contentWrapper">
                <p className="salaryStyle">{ShowInfo.salary}</p>
                <div>
                    {/* {ShowInfo.information.map(function(inf){
                        if(inf.includes(ShowInfo.header)||inf.includes('И если у Вас есть:')||inf.includes('Вы именно тот, кого мы ищем!')){
                            return(
                                <p className="strongStyle"><strong>{inf}</strong></p>
                            )    
                        }
                        else{
                            if(inf.includes('.')){
                                return(
                                    <p className="normalStyle">{inf}<br/><br/></p>
                                )
                            }
                            return(
                                <p className="normalStyle">{inf}</p>
                            )
                        }
                        
                    })} */}
                    <p className="normalStyle">
                        Мы, <strong>Winfinity</strong>, занимаемся разработкой инновационных решений в области игорно-развлекательного контента.
                    </p>
                    <p className="normalStyle">
                        Для создания наших продуктов используются передовые технологии, среди которых: Computer Vision, Unreal Engine, Ultra Low Latency Video Streaming. У нас очень крутой и суперсовременный технопарк - от камер и света, до графических карт, которые почти невозможно найти.
                    </p>
                    <p className="normalStyle">
                        Сегодня мы на стадии активного развития. Мы создаём масштабный, технологически сложный и в тоже время очень интересный, глобальный проект - частью которого можете стать Вы!
                    </p>
                    <p className="normalStyle">
                        <strong>И если у Вас есть:</strong>
                    </p>
                    <p className="normalStyle">
                        опыт коммерческой разработки на JavaScript от 2 лет;<br/>
                        опыт коммерческой разработки на React от 2 лет;<br/>
                        опыт работы в команде с git;<br/>
                        опыт работы с любым сборщиком (webpack, gulp и т.д.).<br/>
                        …то <strong>Вы именно тот, кого мы ищем!</strong><br/>
                    </p>
                    <p className="normalStyle">
                        Обязательные знания:
                    </p>
                    <p className="normalStyle">
                        Typescript;<br/>
                        Webpack;<br/>
                        Styled-components;<br/>
                        GraphQL;<br/>
                        Express;<br/>
                        MongoDB;<br/>
                        WebSockets;<br/>
                        Docker.<br/>
                        После испытательного срока мы предлагаем:<br/>
                    </p>
                    <p className="normalStyle">
                        возможную релокацию в столицу Латвии с помощью в оформлении всех необходимых документов;
                        бесплатную стоянку рядом с современным офисом в центре города;
                        медицинскую страховку;
                        абонемент в спортивный зал.
                        Наша сила - в отсутствии бюрократии, легаси кода, чайка менеджмента, бизнеса, который уже не знает, чего хочет.
                    </p>
                    <p className="normalStyle">
                        Мы за нестандартные идеи, профессиональный и творческий подход, отличные отношения в коллективе и результат.
                    </p>
                </div>
            </div>
        </div>
    )
}
export default BodyInfo;