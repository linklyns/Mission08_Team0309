# Mission 08 - Team 0309 Project (Covey's Quadrants)

## 🛠 Role #1: Database & Setup (Status: COMPLETED)
I have built the backend infrastructure using **Entity Framework Core (Code-First)** with a **Repository Pattern**. 

### 🚀 Getting Started (Run these first!)
To sync your local machine with the database and the seed data, run this in your **Package Manager Console**:
1. `Update-Database`

### 🏗 Architecture Notes
- **Database**: SQLite (file name: `TaskDatabase.sqlite`)
- **Repository Pattern**: I have implemented `ITaskRepository`. **Do not** talk to the `TaskContext` directly. Inject `ITaskRepository` into your controllers.
- **Seeded Data**: I have pre-loaded 8 tasks (2 per quadrant) and the 4 required categories (Home, School, Work, Church).

---

## 🎨 Role #2 & #3: Views & Controllers
Since you are both writing your own controllers/logic for your assigned views, please follow these guidelines to keep our code consistent:

### 1. How to use the Data (Repository)
In your constructor, inject the repository like this:
```csharp
private ITaskRepository _repo;
public YourController(ITaskRepository repo) {
    _repo = repo;
}
