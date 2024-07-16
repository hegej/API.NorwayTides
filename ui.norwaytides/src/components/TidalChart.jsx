import React from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

function TidalChart({ data }) {
    console.log('Data received in TidalChart:', data);

    const formattedData = data.map(item => ({
        ...item,
        timestamp: `${item.Year}-${item.Month.toString().padStart(2, '0')}-${item.Day.toString().padStart(2, '0')} ${item.Hour.toString().padStart(2, '0')}:00`
    }));

    return (
        <div style={{ width: '100%', height: 400 }}>
            <ResponsiveContainer>
                <LineChart data={formattedData}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="timestamp" />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <Line type="monotone" dataKey="Surge" stroke="#8884d8" />
                    <Line type="monotone" dataKey="Tide" stroke="#82ca9d" />
                    <Line type="monotone" dataKey="Total" stroke="#ffc658" />
                </LineChart>
            </ResponsiveContainer>
        </div>
    );
}

export default TidalChart;