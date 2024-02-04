import { User } from "../user/user.types";

export interface ContextSettings {
    isAuthenticated?: boolean,
    user?: User
}