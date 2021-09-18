# Git Keeper

GitKeeper is an small tool in .net core to create `.gitkeep` files in empty folders and remove
`.gitkeep` files in folders with one ore more other files.

Sometimes i create empty folders as reminder or because other tools need this folders. When i made lot's
of changes in the folder structure or adding/removing files, and i want to commit
my stuff, i running the GitKeeper again quickly.

## Add new .gitkeep files

In this example you have an empty directory and want to push it also to git.
Because git ignore empty directories, you can add an empty `.gitkeep` file,
that is useful for some reasons for the next developer who pull this repository.


```console
C:\Work>tree
C:\Work
├───Example
└───HelloWorld.java

C:\Work>gk.exe
C:\Work
C:\Work\Example
    Directory c:\Work\Example contains no files or subfolders, i'll create an .gitkeep ...

C:\Work>tree
C:\Work
├───Example
│   └───.gitkeep
└───HelloWorld.java
```

The tool also automatically goes through all subdirectories and checks for empty directories, too.

## Remove old .gitkeep files

If there are real files in a directory, or an directory have now subdirectories, 
the obsolete and unnecessary `.gitkeep` files should be deleted.

```console
C:\Work>tree
C:\Work
├───Example
│   ├───.gitkeep
│   └───HanSolo.json
└───HelloWorld.java

C:\Work>gk
C:\Work
C:\Work\Example
    Directory c:\Work\Example contains an obsolete .gitkeep ...

C:\Work>tree
C:\Work
├───Example
│   └───HanSolo.json
└───HelloWorld.java
```