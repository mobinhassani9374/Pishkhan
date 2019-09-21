import React from 'react';
import '../docs/lib/font-awesome-4.7.0/css/font-awesome.min.css';
import '../docs/lib/bootstrap/dist/css/bootstrap.min.rtl.css';
import '../docs/fonts/font-fa.css';
import '../docs/css/styles.css?v=0.0.1';
import '../docs/css/override.css?v=0.0.2';
import '../docs/css/ladda.min.css';
import { useTranslation } from 'react-i18next';



export default function Layout(props) {
  const { t  } = useTranslation(['home']);

  return (
    <div dir={t('ltr')}>{props.children}</div>
  )
}