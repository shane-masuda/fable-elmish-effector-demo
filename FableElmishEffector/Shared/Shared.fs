namespace Shared

// Messages processed on the server
type ServerMsg =
    | RequestData
// Messages processed on the client
type ClientMsg =
    | Data of int list
module Shared =
    let endpoint = "/socket"