# 🎓 Virtual Environment System (VES)

## 📌 Overview
The **Virtual Environment System (VES)** is a web-based platform designed to support distance learning. It enables students to access course materials, interact with tutors, and manage their learning experience online.

The system provides personalized support based on students' needs, motivation, and career goals.

---

## 🛠️ Tech Stack
- **Language:** C#
- **Framework:** ASP.NET
- **IDE:** Visual Studio 2022
- **Database:** SQL Server 2019

---

## 👥 User Roles

### 👨‍🏫 Tutor
- Register and log in  
- Create and manage courses  
- Upload materials (lectures, assignments, syllabus, etc.)  
- Post announcements  
- Manage student subscriptions  
- Assign and publish marks  

### 🎓 Student
- Register and log in  
- Search and view courses  
- Subscribe to courses  
- Access and download materials  
- View announcements and marks  
- Rate subjects and post testimonials  

### 🛡️ Administrator
- Approve/reject tutor registrations  
- Manage users (freeze/unfreeze accounts)  
- Manage course categories  
- View system statistics (users, courses)  
- Monitor system activities  

---

## 🔍 Features

### 🔐 Authentication & Security
- User authentication (Student, Tutor, Admin)  
- Session tracking  
- Cookie-based login option  
- Restricted access to unauthorized pages  

### 📚 Course Management
- Tutors can create, update, and delete courses  
- Upload course materials and announcements  
- Students can subscribe and access content  

### 🔎 Search System
- **Simple Search:** accessible without login  
- **Advanced Search:** detailed results (requires login)  

### 📊 Additional Features
- Live search functionality  
- Dynamic advertisements  
- Audit trail (tracks login attempts with date, time, IP)  
- Email notifications for subscriptions  
- Fully validated forms  

---

## 📋 Functional Requirements
- Tutor registration and course management  
- Student registration and course subscription  
- Admin dashboard for full system control  
- Viewing/downloading materials (restricted access)  
- Posting announcements and marks  
- Session-based personalized greetings  

---

## 🚀 How to Run the Project

### 1. Clone the repository
```bash
git clone https://github.com/yourusername/virtual-environment-system.git
### 2. Open the project
```bash
Open the solution in Visual Studio 2022
### 3. Configure the database
```bash
Create a database named VESDB in SQL Server 2019
Import the provided SQL file into VESDB
### 4. Update connection string
```bash
Open web.config
Update the connection string with your SQL Server details

Example:

<connectionStrings>
  <add name="VESDB"
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=VESDB;Integrated Security=True" />
</connectionStrings>
### 5. Run the application
```bash
Press F5 or click Start in Visual Studio

⚠️ Make sure SQL Server is running before starting the application.
