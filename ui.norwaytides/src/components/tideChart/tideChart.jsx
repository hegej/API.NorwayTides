import React, { useState, useEffect } from 'react';
import { LineChart, Select, SelectItem } from '@tremor/react';
import { getTideDataForHarbor } from '../../Api';
import './tideChart.css';

const TideChart = ({ harborName = '' }) => {
  const [tideData, setTideData] = useState([]);
  const [selectedDate, setSelectedDate] = useState('');
  const [availableDates, setAvailableDates] = useState([]);

  const emptyChartData = Array.from({ length: 24 }, (_, i) => ({
    Hour: i,
    Surge: null,
    Tide: null,
    Total: null
  }));

  useEffect(() => {
    const fetchTideData = async () => {
      if (harborName && harborName !== 'none') {
        const data = await getTideDataForHarbor(harborName);
        setTideData(data);
        
        const dates = [...new Set(data.map(item => `${item.Day}.${item.Month}`))]
          .sort((a, b) => {
            const [dayA, monthA] = a.split('.');
            const [dayB, monthB] = b.split('.');
            return new Date(2024, monthA - 1, dayA) - new Date(2024, monthB - 1, dayB);
          });
        setAvailableDates(dates);
        setSelectedDate(''); 
      } else {
        setTideData([]);
        setAvailableDates([]);
        setSelectedDate('');
      }
    };

    fetchTideData();
  }, [harborName]);

  const filteredData = harborName
    ? (selectedDate
        ? tideData.filter(item => `${item.Day}.${item.Month}` === selectedDate)
        : tideData)
    : emptyChartData;

  const valueFormatter = (number) => number !== null ? `${number.toFixed(2)} m` : '';

  return (
    <div className="tide-chart-container">
      {harborName && (
        <Select
          className="mb-4"
          placeholder="Select Date"
          value={selectedDate}
          onValueChange={setSelectedDate}
        >
          <SelectItem value="">All Dates</SelectItem>
          {availableDates.map(date => (
            <SelectItem key={date} value={date}>
              {date}
            </SelectItem>
          ))}
        </Select>
      )}
      <LineChart
        className="tide-chart"
        data={filteredData}
        index="Hour"
        categories={['Surge', 'Tide', 'Total']}
        colors={['blue', 'green', 'red']}
        valueFormatter={valueFormatter}
        yAxisWidth={65}
        showLegend={true}
        showXAxis={true}
        showYAxis={true}
        showGridLines={true}
        showAnimation={true}
        enableLegendSlider={true}
        startEndOnly={false}
        connectNulls={true}
      />
      <div className="axis-labels">
        <span className="x-axis-label">Hour of Day</span>
        <span className="y-axis-label">Water Level (m)</span>
      </div>
    </div>
  );
};

export default TideChart;