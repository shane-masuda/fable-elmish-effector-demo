namespace Shared

// Messages processed on the server
type ServerMsg =
    | RequestData
// Messages processed on the client
type ClientMsg =
    | Data of int list
// Shared messages
type SharedMsg =
    | ClientMsg of ClientMsg
    | ServerMsg of ServerMsg
module Shared =
    let endpoint = "/socket"