import React, { useState, useEffect } from 'react';
import HarborSelect from './components/harborSelect/harborSelect';
import TideChart from './components/tideChart/tideChart';
import { capitalize } from './utils/stringUtils';
import './App.css';

const App = () => {
  const [selectedHarbor, setSelectedHarbor] = useState('');
  
  return (
    <div className="main-container">
      <h1 className="main-heading">Tides of Norway</h1>
      <HarborSelect onSelect={setSelectedHarbor} />
      <div className="mt-4">
        <h2 className="sub-heading">
          Selected harbor: {selectedHarbor ? capitalize(selectedHarbor) : 'none'}
        </h2>
        <TideChart harborName={selectedHarbor || 'none'} />
      </div>
    </div>
  );
};

export default App;
