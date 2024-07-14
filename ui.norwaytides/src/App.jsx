import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HarborSelector from './components/HarborSelector';
import TidalChart from './components/TidalChart';
function App() {
    const [selectedHarbor, setSelectedHarbor] = useState('');

    return (
        <div className="App">
            <h1>Norway Tides</h1>
            <HarborSelector onSelectHarbor={setSelectedHarbor} />
            {selectedHarbor && <p>Selected Harbor: {selectedHarbor}</p>}
        </div>
    );
}

export default App;
