module Main

open Feliz
open Elmish
open Elmish.Bridge
open Elmish.React

open Shared
open DataDisplayerStore
open DataDisplayer

type Model = {
    data: int list
}

let init _ =
    {
        data = []
    }, Cmd.none

let update (msg: SharedMsg) (model: Model) =
    match msg with
    | SharedMsg.ClientMsg clientMsg ->
        match clientMsg with
        | Data data ->
            addData.fire data
            {model with data = data}, Cmd.none
    | SharedMsg.ServerMsg serverMsg ->
        model, Cmd.bridgeSend serverMsg

let view (model: Model) dispatch =
    Html.div [
        Html.button [
            prop.text "Click me!"
            prop.onClick  (fun _ -> SharedMsg.ServerMsg ServerMsg.RequestData |> dispatch)
        ]
        DataDisplayer ()
    ]

Program.mkProgram init update view
|> Bridge.Program.withBridge Shared.endpoint
|> Program.withReactBatched "feliz-app"
|> Program.run