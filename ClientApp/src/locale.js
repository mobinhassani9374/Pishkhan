import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';
// import HomeLocale from '../scenes/Home/Home.locale';
import HomeLocale from './locale/home.locale'


let namespace = {...HomeLocale}

i18n
    .use(initReactI18next) // pass the i18n instance to react-i18next.
    .init({
        resources:namespace,
        lng: 'en_US', // default language
        fallbackLng: 'en_US',
        debug: false,
        interpolation: {
            escapeValue: false // not needed for react as it escapes by default
        }
    });
export default i18n;