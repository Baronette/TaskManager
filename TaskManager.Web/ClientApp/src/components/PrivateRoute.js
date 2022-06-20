import React from 'react';
import { useAuthorization } from '../AuthorizationContext';
import Login from '../pages/Login';
import { Route } from 'react-router-dom';

const PrivateRoute = ({ component, ...options }) => {
    const {user}  = useAuthorization();
    const finalComponent = !!user ? component : Login;
    return <Route {...options} component={finalComponent} />;
};

export default PrivateRoute;