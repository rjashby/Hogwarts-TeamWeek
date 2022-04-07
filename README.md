<h1 align="center">Hogwarts</h1>

![Hogwarts Castle](https://static.onecms.io/wp-content/uploads/sites/6/2018/07/hogwarts1-2000.jpg)

#### By _**Ryan Ashby, Liam Eller, Daniel Lindsay, Anastasiia Riabets, and Sarah Espinet**_ 

#### _This application serves as a portal for new Hogwarts students to be accepted into the school, buy supplies, get sorted into the respective houses, and explore their common room._

### _Link to GitHub Repository_

* https://github.com/rjashby/Hogwarts-TeamWeek

### _Link to Hosted Site_

* http://hogwarts.dlinds.com:6001

## Technologies Used 

* _VS Code Software_
* _Git_
* _Github_
* _C#_
* _.NET5_
* _ASP.NET Core_
* _Javascript_
* _AJAX_
* _jQuery_
* _Bootstrap_
* _MVC_
* _Razor View Engine_
* _MySQL Workbench_
* _Windows PowerShell_
* _Identity_

## Description 

_This is a fan based recreation of the Harry Potter world. It is a MVC, C# application that let's users login, shop for a items they will need during their first year at Hogwarts and then be sorted into a house._

_Users will also be able to navigate to their common rooms and interact with items there._

_The entirety of the application will be subject to login authorization via Identity. A registered user can read, and edit the database as necessary, automatically updating the database._
 
## Setup/Installation Requirements 

**Required Software**

1) _You will need some type of coding software should you wish to view and edit the code. VS Code is an example of a free code editor, which can be downloaded at [VS Code](https://code.visualstudio.com/)_.

2) _Additionally, you will need to download the .NET framework, which can be downloaded at [.NET5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)_.

3) _To effectively work with the database, download MySQL Workbench at [MySQL Workbench](https://dev.mysql.com/downloads/workbench/)._


**Cloning**

1) _In order to utilize this page on your local machine, you will need to clone a copy of this repository._

2) _Navigate to your desired directory in your command terminal and run:_ ``` $ git clone https://github.com/rjashby/Hogwarts-TeamWeek```

3) _Once cloned, open the folder of the cloned repository in your code editor to view all the necessary files._


**Downloading**

1) _In your browser, navigate to https://github.com/rjashby/Hogwarts-TeamWeek, and click the green "Code" button, which will provide a drop down menu. Click on "Download ZIP" at the bottom of the menu, and save it to your desired location._

2) _Once downloaded, unzip and extract the files._

3) _Follow the steps above to view, edit, and open the files as needed._


**Running the Program**

1) _In your terminal, navigate to the Hogwarts folder by starting at the root directory and typing the following into your terminal:_ ```cd Hogwarts```

2) _In the Hogwarts directory run ```dotnet restore``` to download the needed dependencies._

3) _Once here, you will need to run the following in your terminal:_ ```dotnet build```

4) _Once the project builds (and no errors appear), you can run the program by entering the following in your terminal:_ ```dotnet run```

5) _If you wish to changes made in real time, you may run:_ ```dotnet watch run```

6) _At this stage, only the basic layout will be in place. You will first need to build the database to effectively use the application._


**Initial Database Setup** 

1) _Start by creating an appsettings.json file in the main/root directory. This file should BE KEPT PRIVATE and should be populated with the following lines of code:_

```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[Your Database Name Goes Here];uid=[Your Id Goes Here];pwd=[Your Password Here];"
  }
}
```
2) _Ensure that your .gitignore file includes the following files before pushing to GitHub:_

``` 
*/obj/
*/bin/
.vscode
*/appsettings.json
```

**Creating The Database**

1) _Ensure that you have proper tools installed. Start by installing dotnet ef by running the following command in your terminal:_```dotnet tool install --global dotnet-ef```

2) _You will already have access to the current migration, with which you can build and view the database. Now run the following command in your terminal in the "Hogwarts" directory:_ ```dotnet ef database update```

3) _If you want to view the database, open MySQL Workbench. You should see your database, with the appropriate tables and columns. Note: the database name will be based on the name you supplied. See: Initial Database Setup, Step 1._

## Known Bugs 

* _No Known Bugs._  

### License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). Copyright (C) 2022 Ryan Ashby, Liam Eller, Daniel Lindsey, Anastasiia Riabets, and Sarah Espinet. All Rights Reserved.

```
MIT License

Copyright (c) 2022 Ryan Ashby, Liam Eller, Daniel Lindsey, Anastasiia Riabets, and Sarah Espinet.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the "Software"), to deal in the Software without restriction, including 
without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so 
subject to the following conditions:

The above copyright notice and this permission notice shall be included 
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE 
AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```

------------------------------

<a href="#">Return to Top</a>
