import React , {useEffect} from 'react'
import profileImg from '../docs/img/profile.jpg';
import { Link } from 'react-router-dom';

export default function Menu() {
    useEffect(()=>{
        resizePage()
    })

    window.onresize = function() {
        resizePage()
    }

    const resizePage = () =>{
        //console.log(event)
        let width = window.innerWidth

        if(width<767) {
            document.body.classList.add('page-small');
            document.body.classList.remove('hide-sidebar');
          }
          else {
           document.body.classList.remove('page-small');
           document.body.classList.remove('hide-sidebar');
          }
    }
    return (
        <aside id="menu">
            <div className="profile">
                <img src={profileImg} className="profile__img" />
                <div className="profile__name">مهدی و مبین حسنی </div>
                <div className="profile__desc">آخرین به روز رسانی پروفایل : 28 شهریور 98</div>
            </div>
            <ul className="link">
                <li className="link__item">
                    <a href="#">داشبورد کاربر</a>
                </li>
                <li className="link__item hasSubmenu">
                    <a href="#" data-toggle="collapse" data-target="#submenu"> تنظیمات</a>
                    <ul id="submenu" className="collapse">
                        <li className="link__item__submenu"><a href="#">ویرایش پروفایل</a></li>
                        <li className="link__item__submenu"><a href="#">ویرایش پروفایل</a></li>
                    </ul>
                </li>
                <li className="link__item">
                    <Link to='/login'>صفحه لاگین</Link>            
                </li>
                <li className="link__item">
                    <Link to='/register'>صفحه ثبت نام</Link>
                </li>
            </ul>
        </aside>
    )
}
