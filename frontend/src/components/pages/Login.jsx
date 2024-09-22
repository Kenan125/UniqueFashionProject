import { useState } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import styles from '../../css/Auth.module.css';

const Login = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [rememberMe, setRememberMe] = useState(false);
    const navigate = useNavigate();
    const location = useLocation();

    // Get the previous page URL or use "/" if none exists
    const from = location.state?.from || '/';

    const handleSubmit = async (e) => {
        e.preventDefault();
        const loginData = { userName, password };

        try {
            const response = await fetch('https://localhost:7051/api/Auths/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(loginData),
            });

            if (response.ok) {
                const data = await response.json();
                localStorage.setItem('token', data.token); // Store JWT token
                localStorage.setItem('username', userName); // Store username

                // Store userId from response
                if (data.userId) {
                    localStorage.setItem('userId', data.userId);
                } else {
                    console.error('Login response did not include userId');
                }

                // Redirect to the previous page or "/"
                navigate(from, { replace: true });
            } else {
                console.error('Login failed');
            }
        } catch (err) {
            console.error('An error occurred during login', err);
        }
    };

    return (
        <section className={styles['auth-body']}>
            <div className={styles['auth-container']}>
                <div className={styles.title}>
                    <p>Login</p>
                </div>
                <form onSubmit={handleSubmit}>
                    <div className={styles.user_details}>
                        <div className={styles.input_box}>
                            <label>Username</label>
                            <input
                                type="text"
                                placeholder="Please Enter Your Username"
                                value={userName}
                                onChange={(e) => setUserName(e.target.value)}
                                required
                            />
                        </div>
                        <div className={styles.input_box}>
                            <label>Password</label>
                            <input
                                type="password"
                                placeholder="Password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                required
                            />
                        </div>

                        {/* Remember Me Section */}
                        <div className={styles.input_box} style={{ display: 'flex', alignItems: 'center' }}>
                            <label>Remember me</label>
                            <div
                                className={styles.switch}
                                style={{ marginLeft: '10px', position: 'relative', width: '60px', height: '30px', cursor: 'pointer' }}
                                onClick={() => setRememberMe(!rememberMe)}
                            >
                                <input
                                    type="checkbox"
                                    className={styles.checkBox}
                                    checked={rememberMe}
                                    readOnly
                                    style={{ opacity: 0, width: '60px', height: '30px', position: 'absolute', cursor: 'pointer' }}
                                />
                                <div
                                    className={styles.box}
                                    style={{
                                        position: 'absolute',
                                        width: '100%',
                                        height: '100%',
                                        backgroundColor: rememberMe ? 'black' : 'red',
                                        borderRadius: '5px',
                                        transition: 'background-color 1s',
                                    }}
                                ></div>
                                <div
                                    className={styles.stick}
                                    style={{
                                        position: 'absolute',
                                        height: '2px',
                                        width: '20px',
                                        backgroundColor: rememberMe ? 'red' : 'black',
                                        top: '50%',
                                        left: rememberMe ? '35px' : '5px',
                                        transform: 'translateY(-50%) rotate(90deg)',
                                        transition: 'transform 1s, background-color 1s, left 1s',
                                    }}
                                ></div>
                            </div>
                        </div>
                    </div>

                    <div className={styles.reg_btn}>
                        <input type="submit" value="Login" />
                    </div>
                    <div className="text-center mt-3">
                        <p>
                            Don&apos;t have an Account?&nbsp;
                            <a href="/register" className="text-danger">
                                Create Account
                            </a>
                        </p>
                    </div>
                </form>
            </div>
        </section>
    );
};

export default Login;
