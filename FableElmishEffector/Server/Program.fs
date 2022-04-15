open Elmish
open Elmish.Bridge
open Suave.Operators

open Shared

type Model = {
    data: int list
}

let init dispatch _ =
    {
        data = [1; 2; 3; 4; 5]
    }, Cmd.none

let update dispatch (msg: Shared.ServerMsg) (model: Model) =
    match msg with
    | RequestData ->
        dispatch model.data
        model, Cmd.none

let server =
  Bridge.mkServer Shared.endpoint init update
  |> Bridge.run Suave.server

let config = {
    Suave.Web.defaultConfig with
      bindings = [ Suave.Http.HttpBinding.createSimple Suave.Http.HTTP "127.0.0.1" 8081 ]
}

let webPart =
  Suave.WebPart.choose [
    server
    Suave.Filters.path "/" >=> Suave.Files.browseFileHome "index.html"
  ]
Suave.Web.startWebServer config webPart
