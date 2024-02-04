export interface Address
{
    id?: string;
    createdAt?: Date;
    updatedAt?: Date;
    active?: boolean;
    street?: string;
    number?: string;
    city?: string;
    state?: string;
    zipCode?: string;
}