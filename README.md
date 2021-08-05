# Description

This is a hacky Roslyn-based LSP server written in F#. After some experimentation
I felt I could try to hack my own custom LSP server for C#.

The code here is based on
[F# Language Server](https://github.com/fsprojects/fsharp-language-server) code.

# TODO lists
## Next version
 - navigate all symbols on solution
 - code actions:
   - fix usings
   - more?
 - publish as `dotnet tool csharp-ls`

## Wish list
 - code lenses
 - formatting
 - parse documentation into format needed for lsp
 - go-to definition on symbol in metada
 - ability to run tests
