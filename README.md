# MunicipalAppProgPoe README

## Introduction

Welcome to the **MunicipalAppProgPoe**! This application is designed to help manage and report municipal service requests, events, and announcements efficiently. With features such as request tracking, event management, and issue reporting, this app makes it easier for citizens to communicate their needs and stay updated on local events.

## Table of Contents

1. [Installation](#installation)
2. [Compilation](#compilation)
3. [Running the Program](#running-the-program)
4. [Features](#features)
5. [Usage](#usage)
6. [File Structure](#file-structure)
7. [Contributing](#contributing)
8. [License](#license)

---

## Installation

Before you begin, ensure that you have the following prerequisites:

- **Microsoft Visual Studio** with the following components installed:
  - .NET Framework (Version 4.8 or higher)
  - WPF support (Windows Presentation Foundation)

### Steps to Install:

1. **Clone the repository**:  
   To get started, clone this repository to your local machine:
   ```bash
   git clone https://github.com/TobyDwyer/ProgPOEFinal.git
   
2. **Open the Solution in Visual Studio**:  
   After opening the solution in Visual Studio, ensure that all the required dependencies are restored by clicking on **Tools > NuGet Package Manager > Restore NuGet Packages**.

3. **Build the project**:  
   Click on **Build > Build Solution** (or press `Ctrl + Shift + B`). This will compile the project and ensure that everything is in place for execution.

---

## Running the Program

1. **Start the application**:  
   In Visual Studio, click **Debug > Start Debugging** or press `F5` to run the application.

2. **Test the features**:  
   Once the program runs, explore the following main sections:
   - **Service Request**: View, add, and search service requests.
   - **Report Issue**: Report new municipal issues with attachment options.
   - **Events & Announcements**: Browse and search through upcoming events.

---

## Features

The **MunicipalAppProgPoe** app includes the following features:

- **Service Request Management**:
  - Add, view, search, and optimize service requests.
  - Handle request statuses like "Pending," "In Progress," and "Completed."
  - Use an AVL Tree to store requests and optimize search functionality.

- **Issue Reporting**:
  - Report issues such as street maintenance, water supply, etc.
  - Attach media files (e.g., images) related to the issue.
  - Progress bar to show completion status during issue reporting.

- **Event Management**:
  - View a list of upcoming events sorted by date.
  - Filter events by name, category, and location.
  - Display recommended events based on previous searches.

---

## Usage

### Service Request Management

- **Add Request**:  
   Fill in the description and select the status (e.g., Pending, In Progress, Completed), and click **Add Request** to add a new service request.

- **Search Requests**:  
   Use the search bar to filter service requests by description or status.

- **View Related Requests**:  
   After selecting a service request, click on **Show Related Items** to view other requests with similar keywords.

- **Optimize Display**:  
   Click **Optimize Display** to sort the requests by status, description, and ID.

### Issue Reporting

- **Attach Media**:  
   Click **Attach Media** to select files from your system and add them to your report.

- **Submit Issue**:  
   After filling in the required details (location, category, description, and attached files), click **Submit** to report the issue.

- **Progress Bar**:  
   The progress bar will update as you fill in the form.

### Event & Announcements

- **Search Events**:  
   Use the search window to filter events by name, category, or date.

- **Sort Events**:  
   Sort events alphabetically by name using the **Sort By Name** button.

- **Recommended Events**:  
   Get recommendations based on your previous search patterns with the **Show Recommende
