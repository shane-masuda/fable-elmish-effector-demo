module Effector

open Fable.Core
open Fable.Core.JsInterop

[<Import("createEvent", from="effector")>]
let createEventImpl: obj -> obj = jsNative

let testEvent2 = createEventImpl ()

type Event<'T> () =
    let internalEvent = createEventImpl ()
    member _.event = internalEvent
    member this.fire: 'T -> unit = fun (payload: 'T) -> this.event?call null payload
    member this.watch (watcher: 'T -> unit) = this.event?watch watcher

let createEvent<'T> =
    Event<'T>

[<Import("createStore", from="effector")>]
let createStoreImpl: obj -> obj = jsNative

type Store<'T> (defaultState: 'T) =
    let internalStore = createStoreImpl defaultState
    member _.store: obj = internalStore
    member this.on<'U> (event: Event<'U>) (reducer: 'T -> 'U -> 'T): unit =
        this.store?on event.event reducer

let createStore<'T> (defaultState: 'T) =
    Store<'T> defaultState

[<Import("useStore", from="effector-react")>]
let useStoreImpl: obj -> obj = jsNative

let useStore<'T> (store: Store<'T>) =
    let state = useStoreImpl store.store
    state
