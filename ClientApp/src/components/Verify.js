import React, { useEffect , useState } from 'react'
import LaddaButton, { XS, SLIDE_UP } from 'react-ladda';
import { useTranslation } from 'react-i18next';
import { Link, Redirect } from 'react-router-dom';

export default function Verify(props) {
    useEffect(() => {
        console.log(props.location.state.phoneNumber)
    })

    const [isLogin , setIsLogin] = useState(false)
    const [loading , setloading] = useState(false)
    const [inputs, setInputs] = useState({})

    const { t } = useTranslation(['verify']);

    const handleSubmit=()=>{

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
                                        <i className="fa fa-mobile-phone"></i>
                                    </div>
                                </div>
                                <div className="login__box__title">{t('activation code')}</div>
                                <div className="form-group">
                                    <label>{t('activation code')} </label>
                                    <input type="text" name="code" required onChange={changeInputs} tabIndex="1" className="form-control" placeholder={t('activation code')} />
                                </div> 
                                <div className="login__box__link">
                                    <Link to="/register">{t('register')}</Link>
                                    {/* <a href="#">فراموشی رمز عبور</a> */}
                                </div>
                                <div className="form-group">
                                    <LaddaButton
                                        loading={loading}
                                        tabIndex="2"
                                        data-color="#eee"
                                        data-size={XS}
                                        data-style={SLIDE_UP}
                                        data-spinner-size={30}
                                        data-spinner-color="#ddd"
                                        data-spinner-lines={12}
                                    >
                                        {t('activation code')}
                                    </LaddaButton>
                                </div>
                            </form>
                        </div>
                    </div>
            }
        </div>
    )
}
