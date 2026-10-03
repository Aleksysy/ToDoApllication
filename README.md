# ToDoApplication

A task managing application cli written in C#

## Features

- Create personal user profiles
- Create, view, edit, delete and mark tasks as done
- Interactive CLI experience

## Installation

.Net version 8.0.123

```bash
# Clone the repository
git clone https://github.com/Aleksysy/ToDoApllication.git

# Navigate into the directory
cd ToDoApplication
```

Install the following NuGet packages using package browser ot dotnet CLI (package versions should match sdk version):  
Microsoft.EntityFrameworkCore.Sqlite  
Microsoft.EntityFrameworkCore.Design  
BCrypt.Net-Next

```bash
# Install the following packages
dotnet add package Microsoft.EntityFrameworkCore.Sqlite -v 8.0.12
dotnet add package Microsoft.EntityFrameworkCore.Design -v 8.0.12
dotnet add package BCrypt.Net-Next
```

```bash
# Create database based on the models
dotnet ef migrations add InitialCreate
dotnet ef database update
```

```bash
# Run the application
dotnet run
# Or build the application for a target platform
# For Windows
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish/windows
# For Linux
dotnet publish -c Release -r linux-x64 --self-contained false -o ./publish/linux 
```

Or you can use the prebuilt application in the repo under ./publish/OS

## Usage

Start the application, navigate with arrow up/down and enter keys to register a new user. Login with the newly created user credentials. Create, view, edit, mark as done and delete tasks. 

## License

Copyright (C) <2026> <Aleks Holasyan>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://gnu.org>.