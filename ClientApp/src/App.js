import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Login from './components/Login';
import Register from './components/Register';
import PrivateRouter from './components/PrivateRouter';
import PublicRouter from './components/PublicRouter';

export default () => (
  <Layout>
    <PrivateRouter exact path='/' component={Home} />
    <PublicRouter exact path='/Login' component={Login} />
    <PublicRouter exact path='/Register' component={Register} />
  </Layout>
);
