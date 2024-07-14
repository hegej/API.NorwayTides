import React from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';
import tidalData from '../data/tidalData.json';

function TidalChart({ harbor }) {
    console.log('Rendering TidalChart for', harbor);

    return (
        <LineChart width={600} height={300} data={tidalData}>
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="timestamp" />
            <YAxis />
            <Tooltip />
            <Legend />
            <Line type="monotone" dataKey="surge" stroke="#8884d8" />
            <Line type="monotone" dataKey="tide" stroke="#82ca9d" />
            <Line type="monotone" dataKey="total" stroke="#ffc658" />
        </LineChart>
    );
}

export default TidalChart;