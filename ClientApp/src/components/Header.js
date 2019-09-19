import React from 'react'

export default function Header() {
    return (
        <header className="header">
            <div className="header__welcome">به ناحیه کاربری خودتون خوش آمدید</div>
            <div className="header__dashbord">
                <i className="fa fa-bars"></i>
            </div>
            <a className="header__link" data-toggle="tooltip" data-placement="top" title="خروج از سامانه">
                <i className="fa fa-sign-in"></i>
            </a>
            <a className="header__link" data-toggle="tooltip" data-placement="top" title="خروج از سامانه">
                <i className="fa fa-comment-o"></i>
            </a>
        </header>
    )
}
