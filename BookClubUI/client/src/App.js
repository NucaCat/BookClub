import React from 'react';
import logo from './logo.svg';
import './App.css';
import {useAuth} from './pages/auth.hook.js';
import { AuthContext } from './context/AuthContext';
import { BrowserRouter as Router } from 'react-router-dom'
import { Route } from 'react-router';
import  LoginPage  from './pages/LoginPage';
import CabinetPage from './pages/CabinetPage'

function App() {
  const {login, id, isAuthenticated} = useAuth()
  return (
    <div className="App">
      <AuthContext.Provider value = {{
      login, id, isAuthenticated
    }}>

    <Router>
      <Route exact path='/' component={LoginPage} />
      <Route path='/login' component={LoginPage} />
      <Route path='/cabinet' component={CabinetPage} />
    </Router>

    </AuthContext.Provider>
    </div>
  );
}

export default App;
