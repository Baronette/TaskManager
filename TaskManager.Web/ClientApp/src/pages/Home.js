import React, { useEffect, useState, useRef } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { useAuthorization } from '../AuthorizationContext';

const Home = () => {
    const [title, setTitle] = useState('');
    const [tasks, setTasks] = useState();
    const connectionRef = useRef(null);
    const { user } = useAuthorization();
    useEffect(() => {
        const connectToHub = async () => {
            const connection = new HubConnectionBuilder().withUrl("/tasks").build();
            await connection.start();
            connectionRef.current = connection;
            connectionRef.current.invoke('onLogin');

            connection.on('tasks', tasks => {
                setTasks(tasks)
            });
            connection.on('new-task', task => {
                setTasks(tasks => [...tasks, task])
            });
            console.log(tasks)
        }
        connectToHub();
    }, []);

    const onSubmit = async () => {
        await connectionRef.current.invoke('newTask', { title });
        setTitle('');
    }
    const takeTask = async (id) => {
        connectionRef.current.invoke('takeTask', { id })
    }
    const completeTask = async (id) => {
        connectionRef.current.invoke('completeTask', { id })
    }


    return (
        <div className='container col-md-8'>
            <div className='row mt-2'>
                <input type='text' placeholder='Task Title' className='col-md-6 ml-3 form-control' value={title} onChange={e => setTitle(e.target.value)} />
                <button className='btn btn-primary col-md-2 ml-2' onClick={onSubmit}>Add Task</button>
            </div>
            <table className='table table-hover table-striped table-bordered mt-3'>
                <thead>
                    <tr>
                        <th>Task</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    {tasks && tasks.map(t => {
                        return (<tr key={t.id}>
                            {console.log(t)}
                            <td>{t.title}</td>
                            <td>
                                {(t.user && t.user.id === user.id) && <button className='btn btn-success' onClick={() => completeTask(t.id)}>I'm Done</button>}
                                {(t.user && t.user.id !== user.id) && <button className='btn btn-warning' disabled >{t.user.firstName} {t.user.lastName} is doing this</button>}
                                {!t.user && <button className='btn btn-info' onClick={() => takeTask(t.id)}>I'm doing this one</button>}
                            </td>
                        </tr>)
                    })}
                </tbody>
            </table>
        </div>
    )
}
export default Home;