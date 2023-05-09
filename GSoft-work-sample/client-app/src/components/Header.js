import React, { useState, useEffect } from 'react';
import logo from '../assets/logo.png';
import '../css/header.css'; 

function Header(props) {

    const [options, setOptions] = useState([]);
    const [selectedOption, setSelectedOption] = useState('Select'); 

    useEffect(() => {
        fetch('http://localhost:5285/Product/names')
            .then(response => response.json())
            .then(data => setOptions(data))
            .catch(error => console.error(error));
    }, [selectedOption]);

    useEffect(() => {
        props.callback(selectedOption);
    });

    const handleOptionChange = (e) => {
        const value = e.target.value;
        setSelectedOption(value);
    };    

    return (
        <div className="header">
            <div>
                <img src={logo} alt="Logo" className="logo" />
            </div>
            <div className="dropdown">           
                <select className="option" value={selectedOption} onChange={handleOptionChange}>
                    <option disabled>Select</option>
                    {options.map((option) => (
                        <option key={option} value={option}>
                            {option}
                        </option>
                    ))}
                </select>
            </div>
        </div>   
    );
}

export default Header;
