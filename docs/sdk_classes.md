# SDK Classes

## Description

This document describes the classes and interfaces in the SDK.

## Basic App

The basic app is just a button on a page. This button consists of the following elements:

* A title (required)
* A (short) description (optional)
* An image/icon (optional, should we  use a placeholder then?)
* A link to navigate to (this should be absolute)    
We can introduce placeholders for use in the urls later.

## Advanced App

This app has some of the same properties:

* A title
* An optional image/icon
* A link to navigate to.

But there are some differences. The advanced apps get to draw their own content in the description part. This allows for them to put their own custom content there.

## What should we provide

For advanced apps we should provide a way to perform REST requests so that the depedency is already there. They will also need to be able to render their own settings.

## The app interface

If we look at all the shared properties there is very little difference between the two kinds of apps, except for the content. To make all of this work at it's best, we will define an interface that works for both apps.