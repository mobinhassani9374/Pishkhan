import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import './index.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'react-router-redux';
import { createBrowserHistory } from 'history';
import configureStore from './store/configureStore';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { ToastsContainer, ToastsStore } from 'react-toasts';
import {I18nextProvider} from 'react-i18next'
import i18n from './locale.js';

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const history = createBrowserHistory({ basename: baseUrl });

// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = window.initialReduxState;
const store = configureStore(history, initialState);

const rootElement = document.getElementById('root');

ReactDOM.render(
  //<I18nextProvider></I18nextProvider>
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <div>
        <App />
        <ToastsContainer store={ToastsStore} />
      </div>
    </ConnectedRouter>
  </Provider>,
  rootElement);

registerServiceWorker();
