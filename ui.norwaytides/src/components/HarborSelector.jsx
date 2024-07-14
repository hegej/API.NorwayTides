import React from 'react';
import harbors from '../data/harbors.json';

function HarborSelector({ onSelectHarbor }) {
    console.log('Rendering HarborSelector');

    return (
        <select onChange={(e) => onSelectHarbor(e.target.value)}>
            <option value="">Select a harbor</option>
            {harbors.map(harbor => (
                <option key={harbor} value={harbor}>{harbor}</option>
            ))}
        </select>
    );
}

export default HarborSelector;