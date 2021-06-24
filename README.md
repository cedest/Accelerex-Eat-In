# Accelerex Eat-In

[![N|Solid](https://github.com/cedest/Accelerex-Eat-In/blob/main/Accelerex.Web/wwwroot/images/NET_Core_Logo.svg.thumb70.png)](https://dotnet.microsoft.com/download/dotnet/5.0)

[![Build Status](https://travis-ci.com/cedest/Accelerex-Eat-In.svg?branch=main)](https://travis-ci.com/cedest/Accelerex-Eat-In)


Accelerex Eat-In (Web & API) is a micro self hosted, mobile-ready .Net Core solution. This solution helps Accelerex restaurant manage open hours on a daily basis.

## Table of Content
- Features
- How to Install
- How to Use
- Tech Stack
- Installation
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
- [Download](https://git-scm.com/downloads) and Install Git for your OD version
- [Download](https://dotnet.microsoft.com/download/dotnet/5.0) and Install .NET 5
- [Download](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16) and Install Visual Studio Community Edition
- Clone the project from github
- 
```sh
Navigate to the directory where you want to download the solution, run the following line of code to download the solution from git
git clone https://github.com/cedest/Accelerex-Eat-In.git
```


## How to Use

- Import a HTML file and watch it magically convert to Markdown
- Drag and drop images (requires your Dropbox account be linked)
- Import and save files from GitHub, Dropbox, Google Drive and One Drive
- Drag and drop markdown and HTML files into Dillinger
- Export documents as Markdown, HTML and PDF

Markdown is a lightweight markup language based on the formatting conventions
that people naturally use in email.
As [John Gruber] writes on the [Markdown site][df1]

> The overriding design goal for Markdown's
> formatting syntax is to make it as readable
> as possible. The idea is that a
> Markdown-formatted document should be
> publishable as-is, as plain text, without
> looking like it's been marked up with tags
> or formatting instructions.

This text you see here is *actually- written in Markdown! To get a feel
for Markdown's syntax, type some text into the left window and
watch the results in the right.

## Tech Stack

Dillinger uses a number of open source projects to work properly:

- [AngularJS] - HTML enhanced for web apps!
- [Ace Editor] - awesome web-based text editor
- [markdown-it] - Markdown parser done right. Fast and easy to extend.
- [Twitter Bootstrap] - great UI boilerplate for modern web apps
- [node.js] - evented I/O for the backend
- [Express] - fast node.js network app framework [@tjholowaychuk]
- [Gulp] - the streaming build system
- [Breakdance](https://breakdance.github.io/breakdance/) - HTML
to Markdown converter
- [jQuery] - duh

And of course Dillinger itself is open source with a [public repository][dill]
 on GitHub.

## Installation

Dillinger requires [Node.js](https://nodejs.org/) v10+ to run.

Install the dependencies and devDependencies and start the server.

```sh
cd dillinger
npm i
node app
```

For production environments...

```sh
npm install --production
NODE_ENV=production node app
```

## Plugins

Dillinger is currently extended with the following plugins.
Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Credits



## License

MIT

**Free Software, Hell Yeah!**

## Answer to Question 2
- Besides the fact that Json is the defactor standard for mordern client-API communication, it is lightweight, easily readable and is usually structured to match a data object. It is the best way to store this kind of data; especially when compared with XML which requires node parsing; this can be very expensive)
