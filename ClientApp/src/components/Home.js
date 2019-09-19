import React from 'react';
import { connect } from 'react-redux';
import ColorLine from './ColorLine';
import Header from './Header';

const Home = props => (
  <div>
    <ColorLine />
    <Header />
  </div>
);

export default connect()(Home);
