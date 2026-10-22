# 🎓 Student Information System (SIS)

![C#](https://img.shields.io/badge/Language-C%23-blue.svg)
![.NET](https://img.shields.io/badge/.NET-10.0-512BD4.svg)
![UI](https://img.shields.io/badge/UI-Windows%20Forms-lightgrey.svg)
![Database](https://img.shields.io/badge/Database-MySQL%208-orange.svg)
![Platform](https://img.shields.io/badge/Platform-Windows%2010%2F11-0078D6.svg)
![License](https://img.shields.io/badge/License-MIT-green.svg)

A desktop application for managing student records, built with **C# Windows Forms** and **MySQL**. It provides add, update and delete operations, input validation, parameterized SQL queries, and a live `DataGridView` of all students.

Built by **Klink Klank Klan** as a Computer Science Midterm Project.

---

## 📌 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Screens & Controls](#-screens--controls)
- [Tech Stack](#-tech-stack)
- [System Requirements](#-system-requirements)
- [Installation & Setup](#-installation--setup)
- [Project Structure](#-project-structure)
- [Database](#-database)
- [Validation Rules](#-validation-rules)
- [Documentation](#-documentation)
- [Git Workflow](#-git-workflow)
- [Known Issues & Roadmap](#-known-issues--roadmap)
- [Development Team](#-development-team)
- [License](#-license)

---

## 📖 Overview

The **Student Information System (SIS)** is a centralized digital directory for student data. The WinForms interface (`Form1`) talks to a MySQL database through a static `StudentRepository` class that uses parameterized queries, so user input is never concatenated into SQL.

---

## ✨ Features

### Implemented

| Feature | Description |
| :--- | :--- |
| **Add student** | Enrolls a new student with Student ID, full name, gender, year level, program and contact number. |
| **View students** | Loads every record into a `DataGridView`, ordered by Student ID. |
| **Select to edit** | Clicking a grid row fills the form fields with that record. |
| **Update student** | Saves changes to the selected record (the Student ID is the lookup key). |
| **Delete student** | Removes a record only after a Yes/No confirmation dialog. |
| **Clear form** | Resets all inputs and the grid selection. |
| **Input validation** | Blocks empty or invalid values before anything reaches the database. |
| **Error handling** | `try-catch` around every database operation, with clear message boxes instead of crashes. |
| **Safe SQL** | All values are passed as `MySqlCommand` parameters. |
| **External config** | The connection string is read from a local `appsettings.json`, which is git-ignored so passwords are never committed. |

### Planned

- Live search by Student ID or name
- Quick filters for year level and program
- Custom color palette and typography

See [Known Issues & Roadmap](#-known-issues--roadmap).

---

## 🖥️ Screens & Controls

The app has a single window, **Student Information System** (`Form1`).

| Control | Name | Purpose |
| :--- | :--- | :--- |
| TextBox | `txtStudentId` | Student ID (e.g. `2025-01-0001`) |
| TextBox | `txtFullName` | Full name |
| ComboBox | `cboGender` | Male, Female or Other |
| TextBox | `txtYearLevel` | Year level |
| TextBox | `txtProgram` | Academic program (e.g. `BS Computer Science`) |
| TextBox | `txtContactNumber` | 11-digit contact number |
| Button | `btnAdd` / `btnUpdate` / `btnDelete` / `btnClear` | CRUD and reset actions |
| DataGridView | `dgvStudents` | Lists all students |

---

## 🛠️ Tech Stack

| Area | Technology |
| :--- | :--- |
| Language | C# |
| Target framework | `net10.0-windows` |
| UI | Windows Forms (Visual Studio Designer) |
| Database | MySQL Server 8.0 / MariaDB (XAMPP works) |
| Database driver | [`MySql.Data`](https://www.nuget.org/packages/MySql.Data) 26.10.0 |
| Configuration | `Microsoft.Extensions.Configuration.Json` 10.0.13 |
| Version control | Git & GitHub |
| Technical documentation | CherryTree notebook (`.ctd`) |

---

## ⚠️ System Requirements

> [!NOTE]
> The project targets **.NET 10** (`net10.0-windows`). It does not use .NET Framework, and older Windows versions (7, 8, 8.1) are not supported by current .NET releases.

| Component | Requirement |
| :--- | :--- |
| **OS** | Windows 10 or Windows 11 (64-bit) |
| **SDK** | .NET 10 SDK |
| **IDE** | Visual Studio with the **.NET desktop development** workload, on a version that supports the .NET 10 SDK and `.slnx` solution files |
| **Database** | MySQL Server 8.0 or XAMPP (MariaDB) |
| **Display** | 1280 × 720 or higher (the window is designed for a wide layout) |

---

## 🚀 Installation & Setup

### 1. Database

1. Start your MySQL server (XAMPP Control Panel, WAMP or MySQL Workbench).
2. Run the migration, which creates the `student_information_system_db` database and the `Student` table.
3. Run the seed script to add two sample students (optional).

```bash
mysql -u root -p < database/migrations/001_initial_setup.sql
mysql -u root -p < database/seeds/001_sample_data.sql
```

You can also paste the contents of those two files into phpMyAdmin or MySQL Workbench. Run the migration first, then the seed.

### 2. Clone the repository

```bash
git clone https://github.com/gabaga1926/Student-Information-System.git
cd Student-Information-System
```

### 3. Configure the connection string

The repo does not include `appsettings.json` because it is listed in `.gitignore` (so passwords are never committed). Create it yourself inside the `Interface/` folder:

```json
{
  "ConnectionStrings": {
    "StudentDb": "Server=localhost;Port=3306;Database=student_information_system_db;Uid=root;Pwd=YOUR_PASSWORD;"
  }
}
```

- The key must be exactly `ConnectionStrings` → `StudentDb`.
- At startup the app searches for `appsettings.json` starting in the output folder and moving up through parent folders, so placing it in `Interface/` works.
- Never commit your real password.

### 4. Build and run

1. Open `Interface/Interface.slnx` in Visual Studio.
2. Let NuGet restore the packages (`MySql.Data`, `Microsoft.Extensions.Configuration.Json`).
3. Press **F5**.

Or from the command line:

```bash
dotnet run --project Interface
```

### Troubleshooting

| Message | Likely cause |
| :--- | :--- |
| `appsettings.json was not found` | The file is missing. Create it as shown above. |
| `Connection string 'StudentDb' was not found` | The key name is wrong. It must be `ConnectionStrings:StudentDb`. |
| `Unable to connect to any of the specified MySQL hosts` | MySQL is not running, or the port or credentials are wrong. |
| `Unknown database 'student_information_system_db'` | The migration has not been run. |
| `No student table was found in the configured database` | `Database=` points to the wrong database, or the migration was not run. |
| `Duplicate entry ...` | Student ID and contact number must each be unique. |
| Build errors mentioning `net10.0` | Install the .NET 10 SDK and update Visual Studio. |

---

## 📁 Project Structure

```text
Student-Information-System/
├── database/
│   ├── migrations/
│   │   └── 001_initial_setup.sql     # Creates the database and Student table
│   └── seeds/
│       └── 001_sample_data.sql       # Two sample students
├── Interface/
│   ├── Interface.slnx                # Visual Studio solution
│   ├── Interface.csproj              # net10.0-windows project file
│   ├── Program.cs                    # Entry point
│   ├── Form1.cs                      # UI logic, validation, button handlers
│   ├── Form1.Designer.cs             # Designer-generated layout
│   ├── Form1.resx                    # Form resources
│   ├── Student.cs                    # Student model
│   └── StudentRepository.cs          # MySQL data access layer
├── Klink Klank Klank cherrytree documentation.ctd   # Full technical notebook
├── .gitignore
├── LICENSE
└── README.md
```

---

## 🗄️ Database

**Database:** `student_information_system_db` · **Table:** `Student`

| Column | Type | Rules |
| :--- | :--- | :--- |
| `Student_ID` | `VARCHAR(20)` | Primary key |
| `Full_Name` | `VARCHAR(100)` | Required |
| `Gender` | `VARCHAR(20)` | Required |
| `Year_Level` | `INT` | Required, must be between 1 and 4 |
| `Program` | `VARCHAR(100)` | Required |
| `Contact_Number` | `VARCHAR(11)` | Required, unique, exactly 11 digits (`REGEXP '^[0-9]{11}$'`) |

The seed script uses `ON DUPLICATE KEY UPDATE`, so it can be re-run safely.

---

## 🛡️ Validation Rules

Checks run in `Form1.BuildStudentFromForm()` before any database call. The first failure shows a warning message and stops the action.

| Field | Rule |
| :--- | :--- |
| Student ID | Required, at least 3 characters |
| Full name | Required |
| Gender | Must be Male, Female or Other |
| Year level | Whole number (see the [known issue](#-known-issues--roadmap) about the 1–4 vs 1–8 range) |
| Program | Required |
| Contact number | Required, digits only, exactly 11 characters |

All text inputs are trimmed before being saved.

---

## 📚 Documentation

Full technical documentation lives in the CherryTree notebook **`Klink Klank Klank cherrytree documentation.ctd`** in the repository root. Open it with [CherryTree](https://www.giuspen.net/cherrytree/). It is organized into five top-level nodes:

1. **Team & Overview:** project summary, member roles, Git workflow, tech stack and repo layout.
2. **Database Info:** schema, constraints, SQL scripts and notes.
3. **Setup Guide:** prerequisites, configuration, running the app and troubleshooting.
4. **App Walkthrough:** UI controls, each CRUD feature, validation, error handling and the data layer API.
5. **Source Code:** full source of every file in the `Interface` project.

---

## 🌿 Git Workflow

| Branch | Purpose |
| :--- | :--- |
| `main` | Stable branch containing merged, working code |
| `develop` | Integration branch |
| `feature/database` | SQL schema and seed data |
| `feature/interface` | WinForms UI and data layer |

Work flows `feature/*` → pull request → `develop` → pull request → `main`.

---

## 🧭 Known Issues & Roadmap

**Known issues**

- [ ] **Year level range mismatch:** the form accepts 1 to 8, but the database only allows 1 to 4. Values 5 to 8 pass validation and then fail in MySQL.
- [ ] **Row selection:** the grid uses `CellContentClick`, so only clicking the cell text selects a row. `CellClick` would work across the whole row.
- [ ] **No example config:** an `appsettings.example.json` is not yet in the repo.
- [ ] **Table name lookup:** `StudentRepository` tries several candidate table names and re-queries column info on every call. The schema is fixed, so this can be simplified.
- [ ] **Cleanup:** the designer left many empty event handlers in `Form1.cs`, and `btnAdd` still uses the default handler name `button1_Click`.

**Roadmap**

- [ ] Live search by Student ID or name
- [ ] Year level and program quick filters
- [ ] UI color palette and typography polish
- [ ] ER diagram and screenshots in the CherryTree notebook

---

## 👨‍💻 Development Team

**Klink Klank Klan**

| Developer | Role | Key Responsibilities |
| :--- | :--- | :--- |
| **Brix Llarena** | **Lead Developer** | System architecture, Git workflow and branch management, core CRUD integration oversight, and repository curation. |
| **Cyber John Llacer** | **Lead Programmer** | MySQL integration, database connection, parameterized SQL query logic, data layer security, and state management. |
| **Erwin Gabriel Aga** | **Assistant Developer** | UI/UX layout, `DataGridView` styling, input validation, error handling, and CherryTree documentation. |

---

## 📜 License

Distributed under the MIT License. See [`LICENSE`](LICENSE) for details.
