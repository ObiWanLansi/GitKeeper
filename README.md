# Git Keeper

GitKeeper is an small tool in .net core to create `.gitkeep` files in empty directory and remove
`.gitkeep` files in directory with one ore more other files.

Sometimes i create empty directories as reminder or because other tools need this directories.
When i made lot's of changes in a directory structure or adding/removing files, and i want to commit
my stuff, i running the GitKeeper again quickly.

## Add new .gitkeep files

In this example you have an empty directory and want to push it also to git.
Because git ignore empty directories, you can add an empty `.gitkeep` file,
that is useful for some reasons for the next developer who pull this repository.


```console
C:\Work>tree
C:\Work
├───Example              <- Empty directory, wouldn't be pushed to git.
└───HelloWorld.java

C:\Work>gk.exe
C:\Work
C:\Work\Example
    Directory c:\Work\Example contains no files or subfolders, i'll create an .gitkeep ...

C:\Work>tree
C:\Work
├───Example              <- Now the directory contains one empty .gitkeep, now the directory is pushed to git.
│   └───.gitkeep
└───HelloWorld.java
```

The tool also automatically goes through all subdirectories and checks for empty directories, too.

## Remove old .gitkeep files

If there are *real* files in a directory, or an directory have now subdirectories, 
the obsolete and unnecessary `.gitkeep` file should be deleted.

```console
C:\Work>tree
C:\Work
├───Example
│   ├───.gitkeep         <- This .gitkeep is obsolete and can be deleted.
│   └───HanSolo.json
└───HelloWorld.java

C:\Work>gk
C:\Work
C:\Work\Example
    Directory c:\Work\Example contains an obsolete .gitkeep ...

C:\Work>tree
C:\Work
├───Example              <- The obsolete .gitkeep is deleted.
│   └───HanSolo.json
└───HelloWorld.java
```

## Remarks

- The target framework is `net5.0` and should run under linux too.
- The building should be very easy: `dotnet build -c Release`
- Directories with the name `bin`, `obj`, `packages` and `build` are ignorerd and get skipped,
  but if you you want, you can customize this for your needs.
- The gitkeep filename is `.gitkeep`, but you can customize it for your needs.
- I tried to keep the sourcecode simple, i deliberately did not include try catch blocks to unnecessarily enlarge the code.
- When you have no access to an file or directory, mabye the executable throws an exception and exit.

## Links

- [Use .gitkeep to commit and push an empty Git folder or directory](https://www.theserverside.com/blog/Coffee-Talk-Java-News-Stories-and-Opinions/gitkeep-push-empty-folders-git-commit)
- [.GITKEEP File Extension](https://fileinfo.com/extension/gitkeep)