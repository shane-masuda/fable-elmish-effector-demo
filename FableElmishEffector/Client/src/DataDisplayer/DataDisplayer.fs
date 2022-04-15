module DataDisplayer

open Feliz
open Effector
open DataDisplayerStore

[<ReactComponent>]
let DataDisplayer () =
    let data = useStore(dataDisplayerStore)
    Html.span (data.ToString())