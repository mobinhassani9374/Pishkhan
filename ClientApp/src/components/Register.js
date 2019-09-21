import React, { useState, useRef, useEffect } from 'react'
import { Link, Redirect } from 'react-router-dom';
import { Captcha, captchaSettings } from 'reactjs-captcha';
import axios from 'axios';
import { ToastsStore } from 'react-toasts';
import LaddaButton, { XS, SLIDE_UP } from 'react-ladda';
import { useTranslation } from 'react-i18next';

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
    const [loading, setLoading] = useState(false)
    const captcha = useRef();
    const { t } = useTranslation(['register']);

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

        if(inputs.password !==inputs.confirmPassword) {
            return ToastsStore.error('رمز عبور و تکرار آن مطابقت ندارد ')
        }

        var dataPost = {
            userEnteredCaptchaCode,
            captchaId,
            nationalCode: inputs.nationalCode,
            password: inputs.password,
            confirmPassword: inputs.confirmPassword,
            phoneNumber: inputs.phoneNumber,
            username: inputs.username,
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
                //localStorage.setItem('token', response.data.data);
                ToastsStore.success('کد فعال سازی برای شما ارسال شد ')
                setIsLogin(true)
            }
            setLoading(false)
        }).catch((error) => {
            ToastsStore.error('در برقراری با سرور به مشکل خوردیم دوباره تلاش کنیم')
            setLoading(false)
        })
    }

    const changeInputs = (event) => {
        event.persist();
        setInputs(inputs => ({ ...inputs, [event.target.name]: event.target.value }));
    }

    return (
        <div className="login">
            {
                isLogin ? <Redirect to="/login" />
                    : <div className="col-md-4 col-sm-6 col-xs-12">
                        <div className="login__box">
                            <form onSubmit={handleSubmit}>
                                <div className="text-center">
                                    <div className="login__box__icon">
                                        <i className="fa fa-user"></i>
                                    </div>
                                </div>
                                <div className="login__box__title">{t('register')}</div>
                                <div className="form-group">
                                    <label>{t('national code')}</label>
                                    <input type="text" tabIndex="1" name="nationalCode" onChange={changeInputs} required className="form-control" placeholder={t('national code')} />
                                </div>
                                <div className="form-group">
                                    <label>{t('phone number')}</label>
                                    <input type="text" tabIndex="2" name="phoneNumber" onChange={changeInputs} required className="form-control" placeholder={t('phone number')} />
                                </div>
                                <div className="form-group">
                                    <label>{t('username')}</label>
                                    <input type="text" tabIndex="3" name="userName" onChange={changeInputs} required className="form-control" placeholder={t('username')} />
                                </div>
                                <div className="form-group">
                                    <label>{t('password')}</label>
                                    <input type="password" name="password" onChange={changeInputs} required tabIndex="4" className="form-control" placeholder={t('password')} />
                                </div>
                                <div className="form-group">
                                    <label>{t('confirm password')}</label>
                                    <input type="password" name="confirmPassword" onChange={changeInputs} required tabIndex="5" className="form-control" placeholder={t('confirm password')} />
                                </div>
                                <div className="form-group">
                                    <Captcha captchaStyleName="registerCaptchaStyle"
                                        ref={captcha} />
                                    <label name="cap">{t('security code')}</label>
                                    <input id="registerCaptchaUserInput" tabIndex="6" placeholder={t('security code')} required className="form-control" type="text" />
                                </div>
                                <div className="login__box__link">
                                    <Link to="/login">{t('login')}</Link>
                                </div>
                                <div className="form-group">
                                    <LaddaButton
                                        loading={loading}
                                        tabIndex="7"
                                        data-color="#eee"
                                        data-size={XS}
                                        data-style={SLIDE_UP}
                                        data-spinner-size={30}
                                        data-spinner-color="#ddd"
                                        data-spinner-lines={12}
                                    >
                                        {t('register')}
                                    </LaddaButton>
                                </div>
                            </form>
                        </div>
                    </div>
            }
        </div>
    )
}
