import React, { useState } from 'react'
import { Redirect } from 'react-router-dom';

export default function Header() {
    const [isLogin, setIsLogin] = useState(true)
    const sidebar = () => {

        const sidebar = document.body.classList.contains('hide-sidebar');
        const pagesmall = document.body.classList.contains('page-small');

        if (pagesmall) {
            document.body.classList.remove('hide-sidebar');
            document.body.classList.remove('page-small');
        }
        else {
            if (sidebar) {
                document.body.classList.remove('hide-sidebar');
                document.body.classList.remove('page-small');
            }
            else {
                document.body.classList.add('hide-sidebar');
                document.body.classList.remove('page-small');
            }
        }
    }

    const logOut = () => {
        localStorage.removeItem('token');
        setIsLogin(false)
    }
    return (
        <div>
            {
                isLogin ? <header className="header">
                    < div className="header__welcome" > به ناحیه کاربری خودتون خوش آمدید</div >
                    <div className="header__dashbord" onClick={sidebar}>
                        <i className="fa fa-bars"></i>
                    </div>
                    <a onClick={logOut} className="header__link" data-toggle="tooltip" data-placement="top" title="خروج از سامانه">
                        <i className="fa fa-sign-in"></i>
                    </a>
                    <a className="header__link" data-toggle="tooltip" data-placement="top" title="خروج از سامانه">
                        <i className="fa fa-comment-o"></i>
                    </a>
                </header >
                    : <Redirect to="/" />
            }
        </div>
    )
}
