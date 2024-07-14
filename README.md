# Tides of Norway Project Plan

## Technologies
- Backend:
  - Language: C# (.net 8.0) 
  - Framework:ASP.NET Core API
- Frontend:
  - Language: JavaScript
  - Framework: React (version 18.3)
  

### 1. Project Setup

- [x] Create GitHub repository
- [x] Set up folders
- [x] Create initial README.md
- [x] Invite collaborators

### 2. Backend Development (.NET Core API)

- [x] Create new .NET Core API project
- [x] Create folder structure (Controllers, Models, Services, DTOs, Helpers, etc.)
- [x] Configure intial project settings in appsettings.json
- [x] Implement API data fetching service
- [x] Develop text parser for converting plain/text data to JSON
- [x] Create API endpoints in controller
- [ ] Implement DTOs for API respons (consider if needed)
- [ ] Implement error handeling and logging

### 3. Frontend Development (React)
- [x] Create new React project
- [ ] Set up React project structure
- [ ] Create main application component
- [ ] Implement API service for fetching data from backend
- [ ] Develop harbor selection component
- [ ] Create chart component for visualizing SURGE, TIDE, and TOTAL values
- [ ] Implement data fetching and state management for the chart data
- [ ] Style chart component for data representation
- [ ] Develop split view for comparing two harbors
- [ ] Responsive design for various screen sizes
- [ ] Error handling for API requests
- [ ] Error handeling for data loading
- [ ] Look at implementing user-friendly loading states and animations

### 4. Integration and testing
- [ ] Verify correct communication between frontend and backend
- [ ] End-to-end data flow to chart display from the user selection
- [ ] test harbor selection and data loading with different scenarios
- [ ] test split view functionality and comparison feature
