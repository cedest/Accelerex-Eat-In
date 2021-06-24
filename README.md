# Accelerex Eat-In

[![N|Solid](https://github.com/cedest/Accelerex-Eat-In/blob/main/Accelerex.Web/wwwroot/images/NET_Core_Logo.svg.thumb70.png)](https://dotnet.microsoft.com/download/dotnet/5.0)

[![Build Status](https://travis-ci.com/cedest/Accelerex-Eat-In.svg?branch=main)](https://travis-ci.com/cedest/Accelerex-Eat-In)


Accelerex Eat-In (Web & API) is a micro self hosted, mobile-ready C# .Net Core solution. This solution helps Accelerex restaurant manage open hours on a daily basis.


## Table of Content
- Features
- How to Install
- How to Use
- Tech Stack
- Plugins
- Credits
- License
- Answer to Question 2



## Features
- The solution features two projects 
-- The Web project and the API project
- The Web project serves has the client side, from where the data will be provided
- Data can be either be uploaded or pasted as string on the page
- If data would be uploaded, the upload components accepts either a text file (.txt) or a json file (.json). The uploaded file must contain a valid json string
- Once a valid json is submitted, the processed response will be displayed on the page

- The API project receives the submitted json string
- It then processes the string to an easily readable format
- Sends readable formatted string back to the caller




## How to Install
- [Download](https://git-scm.com/downloads) and Install Git for your OS version
- [Download](https://dotnet.microsoft.com/download/dotnet/5.0) and Install .NET 5
- [Download](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16) and Install Visual Studio Community Edition
- Clone the project from github


```sh
Navigate to the directory where you want to download the solution, run the following line of code to download the solution from git
git clone https://github.com/cedest/Accelerex-Eat-In.git
```
- Once the pull is complete:
> Navigate to the downloaded application folder and double click on the solution (Accelerex.Test.sln) file to lauch the application using visual studio. 
> You then need to ensure that both Web & API projects are set to start. Then click Start

[![N|Solid](https://github.com/cedest/Accelerex-Eat-In/blob/main/Accelerex.Web/wwwroot/images/MulipleProj.PNG)](#)

> Alternatively, you can publish the projects to a self hosted IIS environment




## How to Use

When you launch the application, you should see a page as shown below:

[![N|Solid](https://github.com/cedest/Accelerex-Eat-In/blob/main/Accelerex.Web/Screenshots/Landing.PNG)](#)
- Select the Json submission type

If File upload submission type is selected;
[![N|Solid](https://github.com/cedest/Accelerex-Eat-In/blob/main/Accelerex.Web/Screenshots/Landing-File.PNG)](#)
- Upload a text or json file containing a valid json string, click the button "Process OH"

If text pasting submissin type is selected
[![N|Solid](https://github.com/cedest/Accelerex-Eat-In/blob/main/Accelerex.Web/Screenshots/Landing-Text.PNG)](#)
- Paste only a valid json string in the section provided, click the button "Process OH"

If the json string provided was well formatted, a valid, east to read open hour data is displayed
[![N|Solid](https://github.com/cedest/Accelerex-Eat-In/blob/main/Accelerex.Web/Screenshots/WithoutError.PNG)](#)

If error encountered is not syntatic, the API tries to provide a proper error notification at that exact location
[![N|Solid](https://github.com/cedest/Accelerex-Eat-In/blob/main/Accelerex.Web/Screenshots/WithError.PNG)](#)

- ### API Endpoint


## Tech Stack

The solutions use a number of open source projects to work properly:

- [C#] - the best mordern day programming language - no shades to JAVA!
- [HTML5] - HTML enhanced for web apps!
- [Twitter Bootstrap] - great UI boilerplate for modern web apps
- [jQuery] - duh
- [Github] - made reading this possible, isn't this awesome
- [Font Awesome] - great responsibe and flexible fonts




## Plugins

Dillinger is currently extended with the following plugins.
Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Newtonsoft.Json | [plugins/Newtonsoft.Json/README.md](https://github.com/JamesNK/Newtonsoft.Json/blob/master/README.md) |
| Polly | [plugins/Polly/README.md](https://github.com/App-vNext/Polly/blob/master/README.md) |

## Credits
The credit is mine.


## License

MIT

**Free Software, Hell Yeah!**

## Answer to Question 2
- Besides the fact that Json is the defactor standard for mordern client-API communication, it is lightweight, easily readable and is usually structured to match a data object. It is the best way to store this kind of data; especially when compared with XML which requires node parsing; this can be very expensive
