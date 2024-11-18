# **Technology Recommendations**

---

### **1. Database Integration**

**Recommendation:**
Integrating a database would allow persistence of data when the application is run, a feature missing in the current version of the app. This would allow the data to be shared more effectively among users and make the app more suitable for long-term use.

**Benefits:**

- **Persistent Storage:** Data would be saved, eliminating the need for re-entry or loss of data if the application crashes or is closed.
- **Efficient Querying:** Databases are optimized for queries, making searching and filtering large datasets much faster.
- **Scalability:** A database can handle larger amounts of data compared to storing data in memory.

**Compatibility:**
The application is already built using .NET, so integrating SQL Server or SQLite would be straightforward using something like Entity Framework and linking the app to the SQL database.

---

### **2. Improved Security**

**Recommendation:**
Establishing better security for the application, such as user verification and features like single-sign-on (SSO), is important for improving data protection.

**Benefits:**

- **Data Security:** Only allowing users who have an account and have logged in will help prevent unauthorized users from accessing the application and viewing sensitive data.
- **Protection against Attacks:** Proper security features will protect the app and users from attacks like Distributed Denial of Service (DDoS), which could disrupt the app's availability.

**Compatibility:**
A simple login page with hashed passwords, communicating with the server in the backend, would provide a basic barrier to entry. This can be improved in the future by adding SSO and OAuth support.

---

### **3. Cloud Deployment**

**Recommendation:**
Deploying the application to the cloud using **Microsoft Azure** or another cloud platform would improve accessibility, scalability, and performance.

**Benefits:**

- **Scalability:** Cloud services offer the ability to scale resources up or down based on demand, ensuring consistent performance.
- **Availability:** Cloud platforms offer better stability and data security, ensuring that the application remains available more often.
- **Managed Services:** Azure provides managed database services, serverless computing, and other services that can also improve the application in the future.

**Compatibility:**
Azure integrates seamlessly with .NET applications, providing options for hosting, databases, and serverless computing, making it a suitable option for this project.











