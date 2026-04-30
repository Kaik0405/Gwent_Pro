# Gwent Pro: Solo Leveling Edition

![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-blue.svg?style=for-the-badge)

**Gwent Pro** is a high-performance, turn-based strategic card game. Developed as a cornerstone academic project for the Faculty of Mathematics and Computer Science (MATCOM) at the University of Havana, it showcases advanced OOP principles within the Unity engine.

## 🖼️ Media
*(Recommendation: Add screenshots or a GIF here)*
![Main Board](link_a_tu_imagen_aqui)

## 🛠️ Technologies & Core Stack
*   **Game Engine:** Unity 2022 LTS.
*   **Scripting:** C# (.NET Framework).
*   **Design Pattern:** Data-Driven Design using **ScriptableObjects**.
*   **Version Control:** Git for iterative development and deployment.

## ⚙️ Engineering Highlights

### Architecture & Key Scripts
The codebase is modularized into 24 distinct scripts to ensure separation of concerns:
*   **`GameManager.cs`**: Orchestrates the global state machine and round transitions.
*   **`Card.cs`**: Abstract data layer for card entities, decoupling visual representation from core data.
*   **`Effect.cs`**: A static utility class housing all ability logic, invoked via delegates.
*   **`DisplayCard.cs`**: Handles runtime UI updates and dynamic sprite loading.

### Advanced Logic Implementation
*   **Delegate-Based Skill Execution:** Instead of complex `switch` statements, skills are assigned via method references (delegates), allowing for O(1) effect triggering.
*   **Event-Driven Interaction:** Uses Unity's `IDropHandler` interface to manage complex card-to-row validation logic based on faction and card type.

## 🚀 Deployment

The project is compiled and available for immediate testing.

> [!IMPORTANT]
> **[Direct Download: Gwent Pro v1.0 (.rar)](https://github.com/Kaik0405/Gwent_Pro/releases/download/v1.0/GwentPro.Version.1.0.rar)**

1. Download and extract the `.rar` package.
2. Launch `GwentPro.exe`.

## ✒️ Author
*   **Alejandro López Castro** - Computer Science Student, University of Havana.

---
*Developed during an intensive 4-week sprint, focusing on mastering Object-Oriented Programming and Software Architecture in game development.*
