import React , {useEffect , useState} from 'react';
import '../docs/lib/font-awesome-4.7.0/css/font-awesome.min.css';
import '../docs/lib/bootstrap/dist/css/bootstrap.min.rtl.css';
import '../docs/fonts/font-fa.css';
import '../docs/css/styles.css?v=0.0.1';
import '../docs/css/override.css?v=0.0.2';
import '../docs/css/ladda.min.css';
import { useTranslation } from 'react-i18next';



export default function Layout(props) {
  const { t , i18n } = useTranslation(['home']); 
  
  useEffect(() => {
    i18n.changeLanguage('fa_IR');
  },[i18n])

  const [lang , setLang] = useState('fa')

  const changeLang=(event)=>{
    setLang(event.target.value)
    if(lang=='en') {
      i18n.changeLanguage('fa_IR');
    }
    else {
      i18n.changeLanguage('en_Us');
    }
  }

  return (
    <div dir={t('ltr')}>
      <div>
          <select value={lang} onChange={changeLang}>
            <option value="en">انگلیسی</option>
            <option value="fa">فارسی</option>
          </select>
      </div>
      {props.children}
    </div>
  )
}