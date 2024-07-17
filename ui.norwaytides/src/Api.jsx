const BASE_URL = "https://norwaytides.azurewebsites.net/api/tidaldata";

export const getAvailableHarbors = async () => {
    try {
      const response = await fetch(`${BASE_URL}/AvailableHarbors`, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      if (!response.ok) {
        throw new Error('Network response error');
      }
      const data = await response.json();
      return data;
    } catch (error) {
      console.error('Error fetching harbors:', error);
      return [];
    }
  };
  
  export const getTideDataForHarbor = async (harborName) => {
    try {
      const response = await fetch(`${BASE_URL}/Harbor/${harborName}`, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      if (!response.ok) {
        throw new Error('Network response error');
      }
      const data = await response.json();
      return data;
    } catch (error) {
      console.error(`Error fetching the tide data for harbor ${harborName}:`, error);
      return [];
    }
  };