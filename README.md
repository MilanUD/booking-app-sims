# Booking Application

## Project Description

This is a WPF booking application that provides different functionalities based on the user's role. The project was developed using C#, WPF for the frontend, and the MVVM architecture. The application supports four types of users:
- **Tourist**: Creates tour requests, books tours, tracks tour statistics, follows tours live, and uses additional features such as PDF report generation and a tutorial video. This section is tailored for elderly users with average computer skills and poor vision, supporting tablet resolutions.
- **Guide**: Manages tours and tour requests.
- **Guest**: Books accommodations.
- **Owner**: Creates and manages accommodations.

## Technologies and Tools

- **Language**: C#
- **Frontend**: WPF
- **Architecture**: MVVM
- **Development Principles**: Clean Code, SOLID
- **Diagrams**: Class, activity, sequence, and use case diagrams (created with Draw.io)
- **Wireframe Tool**: Balsamiq
- **Dependency Injection**: Implemented
- **Observer Pattern**: Used for real-time updates
- **NuGet Packages**:  
- `Extended.Wpf.Toolkit` (v4.6.0): A collection of WPF controls for creating modern Windows applications.
- `itext7` (v8.0.4): A library for PDF generation written entirely in C# for the .NET platform.
- `itext7.bouncy-castle-adapter` (v8.0.4): A BouncyCastle adapter module for additional cryptography support in PDF generation.
- `LiveCharts.Wpf` (v0.9.7): A flexible and interactive library for data visualization in WPF applications.
- `MahApps.Metro` (v2.4.10): A toolkit for creating modern, "Metro-style" UI for WPF applications with minimal effort.
- `Microsoft.Xaml.Behaviors.Wpf` (v1.1.77): Provides reusable functionality for XAML elements, making it easy to add interactivity to WPF applications.
- `OxyPlot.Wpf`: A plotting library for WPF, useful for creating charts and graphs.


## Project Structure

### Main Folders and Their Purpose
- **CustomClasses**: Contains custom classes used in the application.
- **Diagrams**: Includes all diagrams used in the project (class, activity, sequence, use case).
- **Domain**: Defines core entities of the application.
- **Dto**: Data Transfer Object classes for communication between layers.
- **Injector**: Implementation of Dependency Injection.
- **Observer**: Implementation of the Observer pattern.
- **Repository**: Data access layers.
- **Resources**: Resources like images and videos.
- **Serializer**: Layers for data serialization.
- **Services**: Business logic of the application.
- **Validation**: Data validation logic.
- **View**: XAML files for the user interface.
- **Wireframe**: Contains wireframes designed in Balsamiq.
- **WPF**: Main folder for the MVVM structure:
  - **ViewModels**: Presentation logic for each view.
  - **Views**: XAML views.
  - `RelayCommand.cs`: Implementation of the RelayCommand for binding commands.

## Installation and Running the Application

1. Clone the repository:
```bash
git clone https://github.com/MilanUD/booking-app-sims.git
```
2. Open the project in Visual Studio.
3. Run the application by pressing the **Start** button.

## Features

### My Part: **Tourist**
- Creating and tracking tour requests.
- Booking tours and viewing statistics.
- Live tour tracking.
- Generating PDF reports.
- Tutorial video to help users.
- Tailored interface for elderly users:
- Large fonts and buttons.
- Tablet resolution support.
- Rating visited tours

### Other Parts
- **Guide**: Manages tours and tour requests (Isidora Mićković).
- **Guest**: Books accommodations (Milena Tomanović).
- **Owner**: Creates and manages accommodations (Željana Pelić).

## Team Members
- **Milan Keča**: Tourist.
- **Isidora Mićković**: Guide.
- **Željana Pelić**: Owner.
- **Milena Tomanović**: Guest.

## Screenshots
- **Tourist**
![image](https://github.com/user-attachments/assets/720fe41f-4ce7-4974-90d4-c4e819e980a1)
![image](https://github.com/user-attachments/assets/98e2d095-fe15-4cd2-8e74-6d62a2101911)


## Notes
- The application uses the Observer pattern for real-time UI updates.
- The tourist module is specifically tailored for accessibility and usability for elderly users.
