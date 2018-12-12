# Analysis

## Description

A launcher/lander system, written in C# with .NET Core. The idea is based on Heimdall, but I want to add authentication and authorization. I also don't like PHP, so I'm using .NET Core.

## Architecture

Larger subsystems:

1. Authentication
1. Authorization
1. Front End/web service
1. App SDK

### Authentication and Authorization

ASP .NET Core has some great built in middleware for this. So why use something else for starters? This can always be extended later

### Front End/web service

This will be ASP .NET Core with Bootstrap 4 (latest version at the time of writing). I will try to make the html as structured as possible to make themeing easier later down the line. The controllers will also function as a web service. We will try to make this as transparent as possible. Preferably so that you can simply add .json to the normal url and a token in the header or parameters to make requests.

### App SDK

This will be the base for all the "apps". This base will be built to create the built in apps as well. Dependency injection will be used so that it will suffice to add DLLs to the app folder. This is only meant to easily enable adding apps to the system by placing the binaries in an agreed upon folder and having the system pick up the rest.
