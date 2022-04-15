import { Union } from "../Client/src/fable_modules/fable-library.3.6.2/Types.js";
import { list_type, int32_type, union_type } from "../Client/src/fable_modules/fable-library.3.6.2/Reflection.js";

export class ServerMsg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["RequestData"];
    }
}

export function ServerMsg$reflection() {
    return union_type("Shared.ServerMsg", [], ServerMsg, () => [[]]);
}

export class ClientMsg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Data"];
    }
}

export function ClientMsg$reflection() {
    return union_type("Shared.ClientMsg", [], ClientMsg, () => [[["Item", list_type(int32_type)]]]);
}

export class SharedMsg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["ClientMsg", "ServerMsg"];
    }
}

export function SharedMsg$reflection() {
    return union_type("Shared.SharedMsg", [], SharedMsg, () => [[["Item", ClientMsg$reflection()]], [["Item", ServerMsg$reflection()]]]);
}

export const Shared_endpoint = "/socket";

//# sourceMappingURL=Shared.fs.js.map
