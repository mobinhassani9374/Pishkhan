import React from 'react';
import { connect } from 'react-redux';
import ColorLine from './ColorLine';
import Header from './Header';
import Menu from './Menu';
import Main from './Main';

const Home = props => (
  <div>
    <ColorLine />
    <Header />
    <Menu />
    <Main />
  </div>
);

export default connect()(Home);
