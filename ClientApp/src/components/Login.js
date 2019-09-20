

import React, { useState, useEffect, useRef } from 'react'
import { Link } from 'react-router-dom';
import { Captcha } from 'reactjs-captcha';
import { captchaSettings } from 'reactjs-captcha';
import { useToasts } from 'react-toast-notifications'

export default function Login() {
    useEffect(() => {
        captchaSettings.set({
            captchaEndpoint:
                'https://localhost:5001/simple-captcha-endpoint.ashx'
        });
    })

    const [inputs, setInputs] = useState({})
    const captcha = useRef();
    const { addToast } = useToasts();

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(inputs)
        console.log(captcha.current.getUserEnteredCaptchaCode())
        console.log(captcha.current.getCaptchaId())
        addToast('خطایی رخ داد ', { appearance: 'error' })
        addToast('با موفقیت اضافه شد ', { appearance: 'success' })
    }

    const changeInputs = (event) => {
        event.persist();
        setInputs(inputs => ({ ...inputs, [event.target.name]: event.target.value }));
    }
    return (
        <div className="login">
            <div className="col-md-4 col-sm-6 col-xs-12">
                <div className="login__box">
                    <form onSubmit={handleSubmit}>
                        <div className="text-center">
                            <div className="login__box__icon">
                                <i className="fa fa-sign-in"></i>
                            </div>
                        </div>
                        <div className="login__box__title">ورود به سایت </div>
                        <div className="form-group">
                            <label>نام کاربری را وارد کنید </label>
                            <input type="text" name="userName" required onChange={changeInputs} tabIndex="1" className="form-control" placeholder="نام کاربری" />
                        </div>
                        <div className="form-group">
                            <label>رمز عبور را وارد کنید </label>
                            <input type="password" name="password" required onChange={changeInputs} tabIndex="2" required className="form-control" placeholder="رمز عبور" />
                        </div>
                        <div className="form-group">
                            <Captcha captchaStyleName="yourFirstCaptchaStyle"
                                ref={captcha} />
                            <label name="cap">کد امنیتی را وارد کنید </label>
                            <input id="yourFirstCaptchaUserInput" name="code" required onChange={changeInputs} placeholder="کد امنیتی" className="form-control" type="text" />
                        </div>
                        <div className="login__box__link">
                            <Link to="/register">ثبت نام</Link>
                            <Link to="/register">فراموشی رمز عبور</Link>
                            {/* <a href="#">فراموشی رمز عبور</a> */}
                        </div>
                        <div className="form-group">
                            <button tabIndex="3" type="submit" className="btn btn-success btn-block">ورود</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}
