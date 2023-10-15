import React from 'react';

import CourseList from './CourseList'; // Eğitim bilgilerini listeleyen bileşen


const HomePage = () => {
    return (
        <div>
           
            
            <main >
                <CourseList /> {/* Eğitim bilgilerini listeleyen bileşen */}
            </main>
         
        </div>
    );
};

export default HomePage;
