import React from 'react';
import { connect } from 'react-redux';
import ColorLine from './ColorLine';
import Header from './Header';
import Menu from './Menu';

const Home = props => (
  <div>
    <ColorLine />
    <Header />
    <Menu />
  </div>
);

export default connect()(Home);
