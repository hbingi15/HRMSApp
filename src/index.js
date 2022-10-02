import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter } from 'react-router-dom';
import { Auth0Provider } from '@auth0/auth0-react';
import {Provider} from "react-redux"
import {store} from "./component/redux/store"
const domain="dev-sqihwep5.us.auth0.com"
const client_Id="piDs3n2qhK253ZmUiZW1K3RhqCX1qlU1"

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <React.StrictMode>
    <Provider store={store}>
    <Auth0Provider
    clientId={client_Id}
     domain={domain}
     redirectUri={window.location.origin}

    >


    <BrowserRouter>
    
    <App />
    </BrowserRouter>
    </Auth0Provider>
    </Provider>
   
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
