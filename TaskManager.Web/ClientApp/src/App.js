import React, { Component } from 'react';
import { Route } from 'react-router';
import { AuthorizationContextComponent } from './AuthorizationContext';
import Layout from './components/Layout';
import PrivateRoute from './components/PrivateRoute';
import Home from './pages/Home';
import Login from './pages/Login';
import Logout from './pages/Logout';
import Register from './pages/Register';


export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <AuthorizationContextComponent>
        <Layout>
          <PrivateRoute exact path='/' component={Home} />
          <Route exact path='/login' component={Login} />
          <Route exact path='/register' component={Register} />
          <PrivateRoute exact path='/logout' component={Logout} />
        </Layout>
      </AuthorizationContextComponent>

    );
  }
}
