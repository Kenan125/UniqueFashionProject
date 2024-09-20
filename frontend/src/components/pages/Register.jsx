import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import styles from '../../css/Auth.module.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons';

const Register = () => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        userName: '',
        email: '',
        password: '',
        confirmPassword: '',
        profilePicture: null,
        gender: 'Not Specified',
    });

    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);
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

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formDataToSend = new FormData();
        formDataToSend.append("firstName", formData.firstName);
        formDataToSend.append("lastName", formData.lastName);
        formDataToSend.append("userName", formData.userName);
        formDataToSend.append("email", formData.email);
        formDataToSend.append("password", formData.password);
        formDataToSend.append("confirmPassword", formData.confirmPassword);
        formDataToSend.append("gender", formData.gender);

        if (formData.profilePicture) {
            formDataToSend.append("profilePicture", formData.profilePicture);
        }

        try {
            const response = await fetch('https://localhost:7051/api/Auths/register', {
                method: 'POST',
                body: formDataToSend,
            });

            if (response.ok) {
                navigate('/login');
            } else {
                const data = await response.json();
                console.error(data.message || 'Failed to register');
            }
        } catch (error) {
            console.error('Error during registration:', error);
        }
    };

    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);
    };

    const toggleConfirmPasswordVisibility = () => {
        setShowConfirmPassword(!showConfirmPassword);
    };

    return (
        <section className={styles['auth-body']}>
            <div className={styles['auth-container']}>
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
                            <div className={styles.password_container}>
                                <input
                                    type={showPassword ? 'text' : 'password'}
                                    name="password"
                                    placeholder="Enter your password"
                                    value={formData.password}
                                    onChange={handleInputChange}
                                    required
                                />
                                <span onClick={togglePasswordVisibility} className={styles.eye_icon}>
                                    <FontAwesomeIcon icon={showPassword ? faEyeSlash : faEye} />
                                </span>
                            </div>
                        </div>
                        <div className={styles.input_box}>
                            <label>Confirm Password</label>
                            <div className={styles.password_container}>
                                <input
                                    type={showConfirmPassword ? 'text' : 'password'}
                                    name="confirmPassword"
                                    placeholder="Confirm your password"
                                    value={formData.confirmPassword}
                                    onChange={handleInputChange}
                                    required
                                />
                                <span onClick={toggleConfirmPasswordVisibility} className={styles.eye_icon}>
                                    <FontAwesomeIcon icon={showConfirmPassword ? faEyeSlash : faEye} />
                                </span>
                            </div>
                        </div>
                        <div className={styles.input_box}>
                            <label>Gender</label>
                            <select
                                name="gender"
                                value={formData.gender}
                                onChange={handleInputChange}
                                required
                            >
                                <option value="Male">Male</option>
                                <option value="Female">Female</option>
                                <option value="Not Specified">Not Specified</option>
                            </select>
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
                            Already have an account?&nbsp;
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
