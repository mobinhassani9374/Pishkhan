import React, { Component } from 'react'

export default class Login extends Component {
    render() {
        return (
            <div className="login">
                <div className="col-md-4 col-sm-6 col-xs-12">
                    <div className="login__box">
                        <form>
                            <div className="text-center">
                                <div className="login__box__icon">
                                    <i className="fa fa-sign-in"></i>
                                </div>
                            </div>
                            <div className="login__box__title">ورود به سایت </div>
                            <div className="form-group">
                                <label>نام کاربری را وارد کنید </label>
                                <input type="text" className="form-control" placeholder="نام کاربری" />
                            </div>
                            <div className="form-group">
                                <label>رمز عبور را وارد کنید </label>
                                <input type="password" className="form-control" placeholder="رمز عبور" />
                            </div>
                            <div className="login__box__link">
                                <a href="#">ثبت نام</a>
                                <a href="#">فراموشی رمز عبور</a>
                            </div>
                            <div className="form-group">
                                <button type="submit" className="btn btn-success btn-block">ورود</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}
