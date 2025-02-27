# OdamnRecorder
This project is an audio recording and transcription application built using C#. It allows users to record audio, transcribe it using an external API, and manage recordings through a user-friendly interface.

## Features
- Audio recording functionality
- Audio transcription using an external API
- Global hotkey support for easy access
- User-friendly interface with separate windows for main and transcript display

## Getting Started

### Prerequisites
- .NET SDK (version 6.0 or later)
- An API key for the transcription service (e.g., OpenAI)

### Installation
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd OdamnRecorder
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```

### Configuration
- Update the `appsettings.json` file with your API key and other necessary settings.

### Running the Application
To run the application, use the following command:
```
dotnet run --project src/OdamnRecorder/OdamnRecorder.csproj
```

### Running Tests
To run the unit tests, use the following command:
```
dotnet test src/OdamnRecorder.Tests/OdamnRecorder.Tests.csproj
```

## Usage
- Launch the application and use the main window to start recording audio.
- Press the designated hotkey to process the audio and view the transcription results in a separate window.

## Contributing
Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.