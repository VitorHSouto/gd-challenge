export interface User {
    id?: string,
    createdAt?: Date,
    updatedAt?: Date,
    active?: boolean,
    name?: string,
    email?: string
}

export interface AuthenticatedUser {
    id?: string,
    createdAt?: Date,
    updatedAt?: Date,
    active?: boolean,
    token?: string,
    userId?: string,
    user?: User
}

export interface UserSaveRequest {
    name?: string,
    email?: string;
    password?: string;
}