import React, { useState, useEffect } from 'react';
import ReactDOM from 'react-dom';
import './App.css';
import HarborSelect from './components/harborSelect/harborSelect';
import TideChart from './components/tideChart/tideChart';
import SplitView from './components/splitView/splitView';
import { capitalize } from './utils/stringUtils';

const App = () => {
  const [selectedHarbor, setSelectedHarbor] = useState('');
  const [currentPage, setCurrentPage] = useState('home');

  useEffect(() => {
    window.setCurrentPage = setCurrentPage;
  }, []);

  const renderContent = () => {
    switch (currentPage) {
      case 'home':
        return (
          <>
            <h2 className="sub-heading">
              Selected harbor: {selectedHarbor ? capitalize(selectedHarbor) : 'none'}
            </h2>
            <TideChart harborName={selectedHarbor || 'none'} />
          </>
        );
      case 'split':
        return <SplitView />;
      default:
        return <div>Page not found</div>;
    }
  };

  return (
    <>
      {ReactDOM.createPortal(
        <div className="main-container">
          {currentPage === 'home' && <HarborSelect onSelect={setSelectedHarbor} />}
        </div>,
        document.getElementById('harbor-selector')
      )}

      {ReactDOM.createPortal(
        <div className="mt-4">
          {renderContent()}
        </div>,
        document.getElementById('react-graph')
      )}
    </>
  );
};

export default App;
