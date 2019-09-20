import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Login from './components/Login';
import Register from './components/Register';
import PrivateRouter from './components/PrivateRouter';

export default () => (
  <Layout>
    <PrivateRouter exact path='/' component={Home} />
    <Route path='/Login' component={Login} />
    <Route path='/Register' component={Register} />
  </Layout>
);
