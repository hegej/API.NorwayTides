import React, { useState } from 'react';
import HarborSelect from '../harborSelect/harborSelect';
import TideChart from '../tideChart/tideChart';
import { capitalize } from '../../utils/stringUtils';
import './splitView.css';

const SplitView = () => {
  const [selectedHarbors, setSelectedHarbors] = useState(['']);

  const addHarbor = (harbor) => {
    if (selectedHarbors.length < 4 && !selectedHarbors.includes(harbor)) {
      const newHarbors = selectedHarbors.map(h => h === '' ? harbor : h);
      if (!newHarbors.includes(harbor)) {
        newHarbors.push(harbor);
      }
      setSelectedHarbors(newHarbors.slice(0, 4));
    }
  };

  const removeHarbor = (harbor) => {
    setSelectedHarbors(selectedHarbors.filter(h => h !== harbor).concat('').slice(0, 4));
  };

  return (
    <div className="split-view">
      <div className="harbor-select-container">
        <HarborSelect onSelect={addHarbor} />
      </div>
      <div className="harbor-charts">
        {selectedHarbors.map((harbor, index) => (
          <div key={index} className="harbor-chart">
            <h2 className="sub-heading">
              {harbor ? (
                <>
                  Selected harbor: {capitalize(harbor)}
                  <button onClick={() => removeHarbor(harbor)} className="remove-harbor">Remove</button>
                </>
              ) : (
                'No harbor selected'
              )}
            </h2>
            <TideChart harborName={harbor} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default SplitView;