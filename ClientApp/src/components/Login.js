import React, { useState, useEffect, useRef } from 'react'
import { Link, Redirect } from 'react-router-dom';
import { Captcha, captchaSettings } from 'reactjs-captcha';
import axios from 'axios';
import { ToastsStore } from 'react-toasts';
import LaddaButton, { XS, SLIDE_UP } from 'react-ladda';
import { useTranslation } from 'react-i18next';

export default function Login() {

    captchaSettings.set({
        captchaEndpoint:
            '/simple-captcha-endpoint.ashx'
    });

    useEffect(() => {
        settingCaptcha();
    })

    const [inputs, setInputs] = useState({})
    const [isLogin, setIsLogin] = useState(false)
    const [loading, setLoading] = useState(false)
    const captcha = useRef();
    const { t , i18n} = useTranslation(['login']);
    //i18n.changeLanguage('fa_IR');

    const handleSubmit = (event) => {
        event.preventDefault();

        let userEnteredCaptchaCode = captcha.current.getUserEnteredCaptchaCode()

        let captchaId = captcha.current.getCaptchaId()

        var dataPost = {
            userEnteredCaptchaCode,
            captchaId,
            userName: inputs.userName,
            password: inputs.password
        }

        setLoading(true)

        let headers = {
            'Content-Type': 'application/json',
            'X-XSRF-TOKEN': 'X-XSRF-TOKEN'
        }

        axios.post('/api/login',  dataPost , {
            headers: headers
          }).then((response) => {
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
            setLoading(false)
        }).catch((error) => {
            console.log(error)
            ToastsStore.error('در برقراری با سرور به مشکل خوردیم دوباره تلاش کنیم')
            setLoading(false)
        })
    }

    const changeInputs = (event) => {
        event.persist();
        setInputs(inputs => ({ ...inputs, [event.target.name]: event.target.value }));
    }

    const settingCaptcha = () => {
        captchaSettings.set({
            captchaEndpoint:
                '/simple-captcha-endpoint.ashx'
        });
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
                                        <i className="fa fa-sign-in"></i>
                                    </div>
                                </div>
                                <div className="login__box__title">{t('login')}</div>
                                <div className="form-group">
                                    <label>{t('username')} </label>
                                    <input type="text" name="userName" required onChange={changeInputs} tabIndex="1" className="form-control" placeholder={t('username')} />
                                </div>
                                <div className="form-group">
                                    <label>{t('password')}</label>
                                    <input autoComplete="false" type="password" name="password" onChange={changeInputs} required tabIndex="2" className="form-control" placeholder={t('password')} />
                                </div>
                                <div className="form-group">
                                    <Captcha captchaStyleName="loginCaptchaStyle"
                                        ref={captcha} />
                                    <label name="cap">{t('security code')}</label>
                                    <input id="loginCaptchaUserInput" required tabIndex="3" placeholder={t('security code')} className="form-control" type="text" />
                                </div>
                                <div className="login__box__link">
                                    <Link to="/register">{t('register')}</Link>
                                    <Link to="/register">{t('forgot password')}</Link>
                                    {/* <a href="#">فراموشی رمز عبور</a> */}
                                </div>
                                <div className="form-group">
                                    <LaddaButton
                                        loading={loading}
                                        tabIndex="4"
                                        data-color="#eee"
                                        data-size={XS}
                                        data-style={SLIDE_UP}
                                        data-spinner-size={30}
                                        data-spinner-color="#ddd"
                                        data-spinner-lines={12}
                                    >
                                        {t('login')}
                                    </LaddaButton>
                                </div>
                            </form>
                        </div>
                    </div>
            }
        </div>
    )
}
