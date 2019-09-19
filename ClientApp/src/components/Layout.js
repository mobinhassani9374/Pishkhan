import React from 'react';
import '../docs/lib/font-awesome-4.7.0/css/font-awesome.min.css';
import '../docs/lib/bootstrap/dist/css/bootstrap.min.rtl.css';
import '../docs/fonts/font-fa.css';
import '../docs/css/styles.css?v=0.0.1';
import '../docs/css/override.css?v=0.0.2';

export default props => (
  <div dir="rtl">{props.children}</div>
);