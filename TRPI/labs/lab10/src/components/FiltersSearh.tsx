import Filter from './Filter'
import FilterByUserText from './FilterByUserText';
import { ExperienceSort,EmploymentSort,ScheduleSort } from '../store/VacancySlice';
import '../styles/filters.css';
const FilterSearch = ()=>{
    return(
        <div className='filtersWrapper'>
            <FilterByUserText iconPath='/images/vector1.png' salary={false} />
            <Filter action={ScheduleSort} iconPath='/images/vector2.png' tittle='Гибкий график' criteries={["Полный день","Гибкий график","Удаленная работа"]}/>
            <Filter action={EmploymentSort} iconPath='/images/vector3.png' tittle='Частичная занятость' criteries={["Полная занятость","Частичная занятость","Проектная работа","Стажировка"]}/>
            <Filter action={ExperienceSort} iconPath='/images/vector4.png' tittle='От 1 года до 3 лет' criteries={["Нет опыта","От 1 года до 3 лет","От 3 до 6 лет","Более 6 лет"]}/>
            <FilterByUserText iconPath='/images/vector5.png' salary={true} />
            <button className='search_btn'>Поиск</button>
        </div>    
    )
}
export default FilterSearch;