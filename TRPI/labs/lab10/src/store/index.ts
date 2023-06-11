import { configureStore } from "@reduxjs/toolkit";
import vacancyReducer from './VacancySlice';

const store = configureStore({
    reducer:{
        vacancies:vacancyReducer,
    }
});

export default store;

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch;