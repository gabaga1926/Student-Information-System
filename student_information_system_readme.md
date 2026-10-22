# 🎓 Student Information System (SIS)

![C#](https://img.shields.io/badge/Language-C%23-blue.svg)
![Framework](https://img.shields.io/badge/Framework-.NET%20Framework%204.8-purple.svg)
![Database](https://img.shields.io/badge/Database-MySQL-orange.svg)
![Platform](https://img.shields.io/badge/Platform-Windows%20Desktop-lightgrey.svg)
![License](https://img.shields.io/badge/License-MIT-green.svg)

A modern, robust, and user-friendly desktop application built with **C#.NET Windows Forms** and **MySQL**. Designed to streamline student data management, this application provides full CRUD operations, live data filtering, input validation, and secure database interactions.

---

## 📌 Table of Contents
- [Project Overview](#-project-overview)
- [Key Features](#-key-features)
- [System Requirements & OS Compatibility Caution](#-system-requirements--os-compatibility-caution)
- [Tech Stack & Tools](#-tech-stack--tools)
- [Installation & Setup Guide](#-installation--setup-guide)
- [Documentation Structure](#-documentation-structure)
- [Development Team](#-development-team)
- [License](#-license)

---

## 📖 Project Overview

The **Student Information System (SIS)** serves as a centralized digital directory for academic institutions. Built as a desktop software solution for the Midterm Project evaluation, it bridges C# WinForms UI components with a relational MySQL database server through optimized query execution and defensive programming practices.

---

## ✨ Key Features

### 🏢 Core CRUD Operations
* **Add Student:** Enrolls new student records containing fields for Student ID, Full Name, Gender, Year Level, Academic Program, and Contact Details.
* **View & Live Search:** Instant filtering via the top search bar—query by Student ID or Name with real-time `DataGridView` updates.
* **Edit Records:** Seamlessly populates selected record details into editable fields for swift database updates.
* **Delete Safeguard:** Requires explicit confirmation (`MessageBox` dialog) prior to deleting any record from the database to prevent accidental data loss.

### 🛡️ Safety & Validation
* **Input Sanitization:** Blocks empty inputs and invalid string formatting prior to database execution.
* **Exception Handling:** Comprehensive `try-catch` blocks surrounding all database transactions to prevent application crashes caused by dropped connections or query faults.

### 🎨 Polished UI & QoL Enhancements
* Clean, modern UI color palette with customized typography.
* Quick filters for **Year Level** and **Program**.
* Custom modal interfaces and defensive user prompts.

---

## ⚠️ System Requirements & OS Compatibility Caution

> [!WARNING]
> ### 🛑 Critical OS & Compatibility Notice
> **Recommended OS:** Windows 10 (1903 or higher) / Windows 11 (64-bit)
> 
> Running this application on **legacy Windows environments (Windows 7, Windows 8, or Windows 8.1)** is **strongly discouraged** due to the following technical constraints:
>
> 1. **TLS 1.2+ & MySQL Authentication:** Newer MySQL connector libraries (`MySql.Data`) default to secure TLS handshake protocols. Older Windows builds lack out-of-the-box native support for TLS 1.2/1.3 without explicit registry overrides, resulting in `MySqlException: Unable to connect to any of the specified MySQL hosts`.
> 2. **WinForms High-DPI Scaling:** Modern Windows Forms high-DPI auto-scaling features depend on API hooks introduced in recent Windows 10 updates. Running the app on Windows 7/8 may lead to visual clipping, overlapping labels, or blurry fonts on high-resolution displays.
> 3. **Missing Runtime Dependencies:** The application targets **.NET Framework 4.8**. Outdated operating systems without recent Windows Update patches will fail to launch the application (`CLR initialization error`).

### Minimum System Specifications
| Component | Minimum Requirement | Recommended |
| :--- | :--- | :--- |
| **OS** | Windows 10 (64-bit) | Windows 11 (64-bit) |
| **Runtime** | .NET Framework 4.8 | .NET Framework 4.8.1 |
| **Database Engine** | MySQL Server 8.0 / MariaDB 10.4 | MySQL Server 8.0 / XAMPP v3.3+ |
| **RAM** | 2 GB | 4 GB+ |
| **Display Resolution**| 1280 x 720 | 1920 x 1080 |

---

## 🛠️ Tech Stack & Tools

* **Language:** C# (.NET Framework 4.8)
* **GUI Engine:** Windows Forms (WinForms / Visual Studio Designer)
* **Database Management System:** MySQL Server / XAMPP (MariaDB)
* **Database Driver:** `MySql.Data` (NuGet Package)
* **Version Control:** Git & GitHub
* **Technical Documentation:** CherryTree Notebook (`.ctb` / `.ctd`)

---

## 🚀 Installation & Setup Guide

### 1. Database Configuration
1. Start your local MySQL server (via **XAMPP Control Panel**, **WAMP**, or **MySQL Workbench**).
2. Create a new database named `sis_db` (or your chosen database name):
   ```sql
   CREATE DATABASE sis_db;
   ```
3. Import the database script included in this repository (`/database/student_db.sql` or `.sql` dump file).

### 2. Application Setup
1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   ```
2. Open the `.sln` file in **Visual Studio 2019 or 2022**.
3. Ensure the `MySql.Data` NuGet package is installed/restored (`Tools > NuGet Package Manager > Restore NuGet Packages`).
4. Locate the Database Connection String helper class (or `App.config`) and update your credentials:
   ```csharp
   string connectionString = "Server=localhost;Database=sis_db;Uid=root;Pwd=your_password;";
   ```
5. Press `F5` to build and run the application.

---

## 📁 Documentation Structure

Full technical details and sprint notes are maintained inside our **CherryTree** notebook file included in the root release zip. The hierarchy is organized into 4 primary nodes:

1. **Team & Overview:** Member roster, role allocation, and individual contribution matrix.
2. **Database Info:** Entity-Relationship diagrams, schema screenshots, and SQL scripts.
3. **Setup Guide:** Environment setup, NuGet dependency guidelines, and deployment steps.
4. **App Walkthrough:** Visual interface tours, workflow screenshots, and CRUD implementation code snippets.

---

## 👨‍💻 Development Team

Meet the engineering team behind this system:

| Developer | Role | Key Responsibilities |
| :--- | :--- | :--- |
| **Brix Llarena** | **Lead Developer** | System Architecture, Git workflow & branch management, core CRUD integration oversight, and project repository curation. |
| **Cyber John Llacer** | **Lead Programmer** | MySQL engine integration, database connection drivers, parameterized SQL query logic, data layer security, and state management. |
| **Erwin Gabriel Aga** | **Assistant Developer** | UI/UX visual layout, `DataGridView` styling, input validation routines, error handling guardrails, and CherryTree documentation. |

---

## 📜 License

Distributed under the MIT License. See `LICENSE` for more information.