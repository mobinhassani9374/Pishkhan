import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Login from './components/Login';
import Register from './components/Register';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/Login' component={Login} />
    <Route path='/Register' component={Register} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </Layout>
);
