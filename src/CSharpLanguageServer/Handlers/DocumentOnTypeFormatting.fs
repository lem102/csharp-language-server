namespace CSharpLanguageServer.Handlers

open System
open System.Collections.Immutable

open Ionide.LanguageServerProtocol.Server
open Ionide.LanguageServerProtocol.Types
open Microsoft.CodeAnalysis
open Microsoft.CodeAnalysis.FindSymbols
open Microsoft.CodeAnalysis.Text

open CSharpLanguageServer.State
open CSharpLanguageServer.RoslynHelpers

[<RequireQualifiedAccess>]
module DocumentOnTypeFormatting =
    let provider (clientCapabilities: ClientCapabilities option) : DocumentOnTypeFormattingOptions option =
        Some
            { FirstTriggerCharacter = ';'
              MoreTriggerCharacter = Some([| '}'; ')' |]) }

    let handle (scope: ServerRequestScope) (format: DocumentOnTypeFormattingParams) : AsyncLspResult<TextEdit[] option> = async {
            let maybeDocument = scope.GetUserDocumentForUri format.TextDocument.Uri
            let! formattingChanges =
                match maybeDocument with
                | Some doc -> handleTextOnTypeFormatAsync doc format.Ch format.Position
                | None -> Array.empty |> async.Return
            return formattingChanges |> Some |> LspResult.success
        }