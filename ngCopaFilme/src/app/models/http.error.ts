export class HttpError {
  Message: string;
  errors: ModelState;
}

export class ModelState {
  [k: string] : string[]
}
