import React from 'react'
import profileImg from '../docs/img/profile.jpg';

export default function Menu() {
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
                    <a href="./login.html">صفحه لاگین</a>
                </li>
                <li className="link__item">
                    <a href="./register.html">صفحه ثبت نام</a>
                </li>
                <li className="link__item">
                    <a href="./notfound.html">صفحه  404</a>
                </li>
            </ul>
        </aside>
    )
}
