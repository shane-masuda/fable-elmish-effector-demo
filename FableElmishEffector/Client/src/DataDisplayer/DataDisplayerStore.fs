module DataDisplayerStore

open Effector

let addData = createEvent<int list> ()

let dataDisplayerStore = createStore<int list> ([])

dataDisplayerStore.on addData (fun state payload -> payload)