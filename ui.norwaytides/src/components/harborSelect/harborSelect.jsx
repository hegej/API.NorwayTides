import React, { useState, useEffect } from "react";
import { SearchSelect, SearchSelectItem } from "@tremor/react";
import { getAvailableHarbors } from "../../Api";
import { capitalize } from '../../utils/stringUtils';
import "./harborSelect.css";

const HarborSelect = ({ onSelect }) => {
    const [searchTerm, setSearchTerm] = useState('');
    const [harbors, setHarbors] = useState([]);
  
    useEffect(() => {
      const fetchHarbors = async () => {
        const data = await getAvailableHarbors();
        setHarbors(data);
      };
  
      fetchHarbors();
    }, []);
  
    const filteredHarbors = harbors.filter(harbor =>
      harbor.toLowerCase().startsWith(searchTerm.toLowerCase())
    );
  
    return (
      <div className="harbor-select-wrapper">
        <SearchSelect
          placeholder="Search for harbor"
          onValueChange={(value) => {
            setSearchTerm(value);
            onSelect(value);
          }}
        >
          {filteredHarbors.map((harbor, index) => (
            <SearchSelectItem key={index} value={harbor}>
              {capitalize(harbor)}
            </SearchSelectItem>
          ))}
        </SearchSelect>
      </div>
    );
  };
  
  export default HarborSelect;