import React, { useState, useRef, useEffect } from 'react'
import { Link, Redirect } from 'react-router-dom';
import { Captcha, captchaSettings } from 'reactjs-captcha';
import axios from 'axios';
import {ToastsStore} from 'react-toasts';

export default function Register() {

    captchaSettings.set({
        captchaEndpoint:
            '/simple-captcha-endpoint.ashx'
    });

    useEffect(() => {
        settingCaptcha();
    })

    const [inputs, setInputs] = useState({})
    const [isLogin, setIsLogin] = useState(false)
    const captcha = useRef();

    const settingCaptcha = () => {
        captchaSettings.set({
            captchaEndpoint:
                '/simple-captcha-endpoint.ashx'
        });
    }

    const handleSubmit = (event) => {
        event.preventDefault();

        let userEnteredCaptchaCode = captcha.current.getUserEnteredCaptchaCode()

        let captchaId = captcha.current.getCaptchaId()

        var dataPost = {
            userEnteredCaptchaCode,
            captchaId,
            nationalCode: inputs.nationalCode,
            password: inputs.password,
            confirmPassword: inputs.confirmPassword,
            phoneNumber: inputs.phoneNumber,
        }
        axios.post('/api/register', dataPost).then((response) => {
            console.log(response)
            if (!response.data.isSuccess) {
                response.data.errors.map((error) => {                
                    ToastsStore.error(error)
                })
                captcha.current.reloadImage();
            }
            else {
                localStorage.setItem('token', response.data.data);
                setIsLogin(true)
            }
        }).catch((error) => {
            ToastsStore.error('در برقراری با سرور به مشکل خوردیم دوباره تلاش کنیم')
        })
    }

    const changeInputs = (event) => {
        event.persist();
        setInputs(inputs => ({ ...inputs, [event.target.name]: event.target.value }));
    }

    return (
        <div className="login">
            {
                isLogin ? <Redirect to="/" />
                    : <div className="col-md-4 col-sm-6 col-xs-12">
                        <div className="login__box">
                            <form onSubmit={handleSubmit}>
                                <div className="text-center">
                                    <div className="login__box__icon">
                                        <i className="fa fa-user"></i>
                                    </div>
                                </div>
                                <div className="login__box__title">ثبت نام در سایت </div>
                                <div className="form-group">
                                    <label>کد ملی  را وارد کنید </label>
                                    <input type="text" tabIndex="1" name="nationalCode" onChange={changeInputs} required className="form-control" placeholder="کد ملی " />
                                </div>
                                <div className="form-group">
                                    <label>شماره همراه را وارد کنید </label>
                                    <input type="text" tabIndex="2" name="phoneNumber" onChange={changeInputs} required className="form-control" placeholder="شماره همراه" />
                                </div>
                                <div className="form-group">
                                    <label>رمز عبور را وارد کنید </label>
                                    <input type="password" name="password" onChange={changeInputs} required tabIndex="3" className="form-control" placeholder="رمز عبور" />
                                </div>
                                <div className="form-group">
                                    <label>تکرار رمز عبور را وارد کنید </label>
                                    <input type="password" name="confirmPassword" onChange={changeInputs} required tabIndex="4" className="form-control" placeholder="تکرار رمز عبور" />
                                </div>
                                <div className="form-group">
                                    <Captcha captchaStyleName="registerCaptchaStyle"
                                        ref={captcha} />
                                    <label name="cap">کد امنیتی را وارد کنید </label>
                                    <input id="registerCaptchaUserInput" tabIndex="5" placeholder="کد امنیتی" className="form-control" type="text" />
                                </div>
                                <div className="login__box__link">
                                    <Link to="/login">ورود به سایت </Link>
                                </div>
                                <div className="form-group">
                                    <button tabIndex="6" type="submit" className="btn btn-success btn-block">ثبت نام</button>
                                </div>
                            </form>
                        </div>
                    </div>
            }
        </div>
    )
}
