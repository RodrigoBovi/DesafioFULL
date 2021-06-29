export class User {
    email: string;
    password: string;

    constructor(init?: Required<User>) {
        Object.assign(this, init);
    }
}
