import {PayloadAction, createSlice} from '@reduxjs/toolkit'
import TextObjects, { text } from'./TextObjects'
import { Schedule } from '@material-ui/icons'

type listText ={
    vacancies:Array<text>,
    ShowInfo:text,
}
const initialState:listText={
    vacancies:TextObjects,
    ShowInfo:{id:'2',schedule:'удаленная работа',employment:'частичная занятость',experience:'Более 6 лет',like:false,standartHeart:'/images/standart.png',likedHeart:'/images/like.png',iconPath:'/images/icon3.png',header:'Winfinity',title:'Frontend developer (React)',city:'Москва',languages:['jQuery','JavaScript'],date:'29/03/2021',salary:'От 150 000 до 300 000 руб.',information:['Мы,', 'Winfinity',', занимаемся разработкой инновационных решений в области игорно-развлекательного контента.','Для создания наших продуктов используются передовые технологии, среди которых: Computer Vision, Unreal Engine, Ultra Low Latency Video Streaming. У нас очень крутой и суперсовременный технопарк - от камер и света, до графических карт, которые почти невозможно найти.','Сегодня мы на стадии активного развития. Мы создаём масштабный, технологически сложный и в тоже время очень интересный, глобальный проект - частью которого можете стать Вы!','И если у Вас есть:','опыт коммерческой разработки на JavaScript от 2 лет;','опыт коммерческой разработки на React от 2 лет;','опыт работы в команде с git;','опыт работы с любым сборщиком (webpack, gulp и т.д.).','…то ','Вы именно тот, кого мы ищем!','Обязательные знания:','Typescript;','Webpack;','Styled-components;','GraphQL;','Express;','MongoDB;','WebSockets;','Docker.','После испытательного срока мы предлагаем:','возможную релокацию в столицу Латвии с помощью в оформлении всех необходимых документов;','бесплатную стоянку рядом с современным офисом в центре города;','медицинскую страховку;','абонемент в спортивный зал.','Наша сила - в отсутствии бюрократии, легаси кода, чайка менеджмента, бизнеса, который уже не знает, чего хочет.','Мы за нестандартные идеи, профессиональный и творческий подход, отличные отношения в коллективе и результат.']},
}

const VacancySlice=createSlice({
    name:'vacancies',
    initialState,
    reducers:{
        ShowFiltersUl(state,action:PayloadAction<string>){
            const temp = state.vacancies.find(vacancy=>vacancy.id===action.payload)
            if(temp){
                console.log(state)
                
                state.ShowInfo={
                    id: new Date().toISOString(),
                    iconPath: temp.iconPath,
                    standartHeart:temp.standartHeart,
                    likedHeart:temp.likedHeart,
                    header: temp.header,
                    title: temp.title,
                    city: temp.city,
                    languages: temp.languages,
                    date: temp.date,
                    salary: temp.salary,
                    information: temp.information,
                    like: temp.like,
                    schedule:temp.schedule,
                    experience:temp.experience,
                    employment:temp.employment
                }
            }
        },

        PressedLike(state,action:PayloadAction<string>){
            state.vacancies = state.vacancies.map((vacancy)=>{
                if(vacancy.id!==action.payload)
                    return vacancy;
                return{
                    ...vacancy,
                    like :!vacancy.like
                }
            })
        },
        ShowLiked(state,action:PayloadAction<void>){
            state.vacancies = state.vacancies.filter((vacancy)=>{
                if(vacancy.like)
                    return vacancy;
            })
        },
        ShowAll(state,action:PayloadAction<void>){
            const temp = state.vacancies;            
            state.vacancies = TextObjects.map(function(vacancy){
                for(let i=0;i<temp.length;i++){
                    if(temp[i].id===vacancy.id){ 
                        return temp[i];
                    }
                }
                return vacancy;
            })
        },
        ShowKnowledge(state,action:PayloadAction<String>){
            state.vacancies = state.vacancies.filter((vacancy)=>{
                // vacancy.languages.forEach(lang => {
                //     if(lang.includes(action.payload.toString())){
                //         console.log('xer')
                //         return vacancy;
                //     }
                // });
                for(let i = 0; i<vacancy.languages.length;i++){
                    if(vacancy.languages[i].includes(action.payload.toString())){
                        return vacancy;
                    }     
                }
            })
        },
        SearchByCity(state,action:PayloadAction<string>){
            console.log('City');
            const temp = state.vacancies;            
            state.vacancies = TextObjects.map(function(vacancy){
                for(let i=0;i<temp.length;i++){
                    if(temp[i].id===vacancy.id){ 
                        return temp[i];
                    }
                }
                return vacancy;
            })
            
            state.vacancies = state.vacancies.filter((vacancy)=>{
                if(vacancy.city.toLocaleLowerCase()===action.payload.toLocaleLowerCase())
                    return vacancy;
            })
        },
        SearchBySalary(state,action:PayloadAction<string>){
            console.log('Salary');
            const temp = state.vacancies;            
            state.vacancies = TextObjects.map(function(vacancy){
                for(let i=0;i<temp.length;i++){
                    if(temp[i].id===vacancy.id){ 
                        return temp[i];
                    }
                }
                return vacancy;
            })

            state.vacancies = state.vacancies.filter((vacancy)=>{
                if(vacancy.salary.includes(action.payload))
                    return vacancy;
            })
        },
        ScheduleSort(state,action:PayloadAction<string>){
            console.log('Schedule');
            //restoration list of vacancies
            const temp = state.vacancies;            
            state.vacancies = TextObjects.map(function(vacancy){
                for(let i=0;i<temp.length;i++){
                    if(temp[i].id===vacancy.id){ 
                        return temp[i];
                    }
                }
                return vacancy;
            })

            state.vacancies = state.vacancies.filter((vacancy)=>{
                if(vacancy.schedule.toLocaleLowerCase()===action.payload.toLocaleLowerCase())
                    return vacancy;
            })
        },
        ExperienceSort(state,action:PayloadAction<string>){
            console.log('Experience')
            const temp = state.vacancies;            
            state.vacancies = TextObjects.map(function(vacancy){
                for(let i=0;i<temp.length;i++){
                    if(temp[i].id===vacancy.id){ 
                        return temp[i];
                    }
                }
                return vacancy;
            })

            state.vacancies = state.vacancies.filter((vacancy)=>{
                if(vacancy.experience.toLocaleLowerCase()===action.payload.toLocaleLowerCase())
                    return vacancy;
            })
        },
        EmploymentSort(state,action:PayloadAction<string>){
            console.log('Emloyment');
            const temp = state.vacancies;            
            state.vacancies = TextObjects.map(function(vacancy){
                for(let i=0;i<temp.length;i++){
                    if(temp[i].id===vacancy.id){ 
                        return temp[i];
                    }
                }
                return vacancy;
            })
            state.vacancies = state.vacancies.filter((vacancy)=>{
                if(vacancy.employment.toLocaleLowerCase()===action.payload.toLocaleLowerCase())
                    return vacancy;
            })
        }
    }
})

export const {ShowFiltersUl,PressedLike,ShowLiked,ShowAll,ShowKnowledge,SearchByCity,SearchBySalary,ScheduleSort,EmploymentSort,ExperienceSort} = VacancySlice.actions;
export default VacancySlice.reducer;
