import React from 'react';
import { Link } from 'react-router-dom';
import { useAuthorization } from '../AuthorizationContext';

const Layout = ({ children }) => {
    const {user} = useAuthorization();
    return (
        <div>
            <header>
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                    <Link className="navbar-brand" to='/'>Task Manager</Link>
                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <ul className="navbar-nav">
                        <li className="nav-item ">
                            <Link className="nav-link text-light" to='/'>Home </Link>
                        </li>
                        {!user && <><li className="nav-item">
                            <Link className="nav-link text-light" to='/login'>Login</Link>
                        </li>
                        <li className="nav-item">
                        <Link className="nav-link text-light" to='/register'>Register</Link>
                    </li></>}
                        {user && <li className="nav-item">
                            <Link className="nav-link text-light" to='/logout'>Logout</Link>
                        </li>}
                    </ul>
                </nav>
            </header>
            {children}
        </div>
    )
}
export default Layout;