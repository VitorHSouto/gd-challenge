import { InternalFile } from "../file/file.types";

export interface Product{
    id?: string;
    createdAt?: Date;
    updatedAt?: Date;
    active?: boolean;
    name?: string;
    description?: string;
    price?: number;
    companyId?: string;
    fileIds?: string;
    files?: InternalFile[];
}

export enum ProductIncludeDetails{
    undefined = 'UNDEFINED',
    file = 'FILE',
    all = 'ALL'
  }