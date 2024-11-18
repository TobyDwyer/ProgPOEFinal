# Project Completion Report

---

### **Overview**

The Municipal Services Application was designed to help users manage and track service requests for municipal services such as streetlight repairs, garbage collection, and other maintenance tasks. The primary goal was to create an interactive system that allows users to add, search, and view the status of service requests efficiently.

The key features implemented include:

- Adding and managing services within the application.
- Reporting issues with the relevant details.
- Viewing events and announcements.

The application was developed using **C#**, **WPF**, and **.NET**, ensuring that the user interface was easy to navigate, and the backend logic was efficient and scalable.

---

### **2. Task 3 Implementation: Challenges and Solutions**

Task 3 required us to implement a service request feature. This feature used an **AVL Tree** for efficient service request management and a **Graph** to represent relationships between requests. The following challenges were faced during its implementation:

#### **Challenge 1: Designing the Graph for Related Requests**

- **Issue:** Initially, the application was very basic, but using the graph to implement a related services feature was difficult at first due to the challenge of defining what would relate the services to one another.
- **Solution:** After analyzing the requirements, I decided to link requests that share common keywords in their descriptions. I used the `Contains` method to match keywords between requests, allowing us to create edges in the graph between nodes that shared similar descriptions.

#### **Challenge 2: Efficiently Traversing the Graph for Related Requests**

- **Issue:** After setting up the graph, it became necessary to implement an efficient way to traverse and retrieve all related requests for a selected service. It was important that this traversal remained efficient as the number of values grew, so the app could scale effectively.
- **Solution:** The graph was implemented using an **Adjacency List**, which allowed for **O(1)** average-time lookups of neighbors. I used **Depth First Search (DFS)** to traverse the graph and retrieve all connected components for a node. This method ensured that even with a larger scale, traversing the graph remained efficient.

#### **Challenge 3: User Interface Integration**

- **Issue:** Displaying related service requests on the user interface presented challenges in ensuring that the results were presented clearly and promptly.
- **Solution:** I utilized WPF’s **ListView** control to display the results. The ListView was dynamically updated based on the results of the graph traversal, ensuring that the user always saw the most relevant service requests.

---

### **3. Key Learnings and Insights**

Throughout the development of this project, several key learnings were acquired, both in terms of **technical skills** and **problem-solving approaches**:

- **Efficient Data Structures:** The project highlighted the importance of choosing the right data structures to best achieve a task. The **AVL Tree** proved best for efficient management and retrieval of requests, while the **Graph** allowed relationships to be set up between requests, enabling more advanced features. Understanding how all the different data structures work was a big learning point for me.
- **Graph Theory and Traversal:** Implementing the graph-based relationships helped deepen my understanding of graph theory. Specifically, learning how to represent relationships with an adjacency list and applying algorithms to improve the functionality of the graphs was also very interesting.
- **UI/UX Considerations:** Designing the user interface to handle dynamic data, such as related requests, meant I had to improve my knowledge of which components were best to use, such as ListViews, and managing navigation between pages for the best user experience.
- **Problem-Solving Approach:** One thing that this project taught me about problem-solving is how setting up a structured plan will help in the long run. Initially, between tasks 1 and 2, I had no plan for long-term development, which made integrating changes difficult. However, I changed my methods, and Task 3 went considerably smoother.
- **Programming Techniques:** In this project, I used techniques such as Object-Oriented Programming (OOP) for integrating multiple classes to perform a single task and using LINQ queries to help improve the efficiency of my code for tasks such as manipulating and filtering data throughout the project.

---
