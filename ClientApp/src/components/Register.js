import React, { Component } from 'react'
import { Link } from 'react-router-dom';

export default function Register() {
    return (
        <div className="login">
            <div className="col-md-4 col-sm-6 col-xs-12">
                <div className="login__box">
                    <form>
                        <div className="text-center">
                            <div className="login__box__icon">
                                <i className="fa fa-user"></i>
                            </div>
                        </div>
                        <div className="login__box__title">ثبت نام در سایت </div>
                        <div className="form-group">
                            <label>نام و نام خانوادگی را وارد کنید </label>
                            <input type="text" tabIndex="1" className="form-control" placeholder="نام و نام خانوادگی" />
                        </div>
                        <div className="form-group">
                            <label>ایمیل را وارد کنید </label>
                            <input type="email" tabIndex="2" className="form-control" placeholder="ایمیل" />
                        </div>
                        <div className="form-group">
                            <label>شماره تلفن را وارد کنید </label>
                            <input type="email" tabIndex="3" className="form-control" placeholder="شماره تلفن" />
                        </div>
                        <div className="login__box__link">
                            <Link to="/login">ورود به سایت </Link>
                        </div>
                        <div className="form-group">
                            <button tabIndex="4" type="submit" className="btn btn-success btn-block">ثبت نام</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}
