export interface Product{
    id?: string;
    createdAt?: Date;
    updatedAt?: Date;
    active?: boolean;
    name?: string;
    description?: string;
    price?: number;
    companyId?: string;
}