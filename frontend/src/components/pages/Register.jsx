import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import styles from '../../css/Auth.module.css'; // Scoped CSS import

const Register = () => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        userName: '',
        phoneNumber: '',
        email: '',
        password: '',
        confirmPassword: '',
        profilePicture: null,
    });
    const navigate = useNavigate();

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevState) => ({
            ...prevState,
            [name]: value,
        }));
    };

    const handleFileChange = (e) => {
        setFormData((prevState) => ({
            ...prevState,
            profilePicture: e.target.files[0],
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // Implement your registration logic here (API call)
        navigate('/login'); // Redirect to login on successful registration
    };

    return (
        <section className={styles['auth-body']}> {/* Scoped class for body */}
            <div className={styles['auth-container']}> {/* Scoped class for container */}
                <div className={styles.title}>
                    <p>Registration</p>
                </div>
                <form onSubmit={handleSubmit}>
                    <div className={styles.user_details}>
                        <div className={styles.input_box}>
                            <label>First Name</label>
                            <input
                                type="text"
                                name="firstName"
                                placeholder="Enter your first name"
                                value={formData.firstName}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className={styles.input_box}>
                            <label>Last Name</label>
                            <input
                                type="text"
                                name="lastName"
                                placeholder="Enter your last name"
                                value={formData.lastName}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className={styles.input_box}>
                            <label>Username</label>
                            <input
                                type="text"
                                name="userName"
                                placeholder="Enter your username"
                                value={formData.userName}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className={styles.input_box}>
                            <label>Phone Number</label>
                            <input
                                type="text"
                                name="phoneNumber"
                                placeholder="Enter your phone number"
                                value={formData.phoneNumber}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className={styles.input_box}>
                            <label>Email</label>
                            <input
                                type="email"
                                name="email"
                                placeholder="Enter your email address"
                                value={formData.email}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className={styles.input_box}>
                            <label>Password</label>
                            <input
                                type="password"
                                name="password"
                                placeholder="Enter your password"
                                value={formData.password}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className={styles.input_box}>
                            <label>Confirm Password</label>
                            <input
                                type="password"
                                name="confirmPassword"
                                placeholder="Confirm your password"
                                value={formData.confirmPassword}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className={styles.input_box}>
                            <label>Profile Picture (Optional)</label>
                            <input type="file" name="profilePicture" onChange={handleFileChange} />
                        </div>
                    </div>
                    <div className={styles.reg_btn}>
                        <input type="submit" value="Register" />
                    </div>
                    <div className="text-center mt-3">
                        <p>
                            Have an Account?{' '}
                            <a href="/login" className="text-danger">
                                Login
                            </a>
                        </p>
                    </div>
                </form>
            </div>
        </section>
    );
};

export default Register;
