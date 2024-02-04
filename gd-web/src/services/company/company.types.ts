import { Address } from "../address/address.types";

export interface Company {
  id?: string;
  createdAt?: Date;
  updatedAt?: Date;
  active?: boolean;
  name?: string;
  description?: string;
  phone?: string;
  addressId?: string;
  address?: Address;
}

export interface CompanyFilterRequest {
  includeDetails: string;
  searchText: string;
}

export enum CompanyIncludeDetails{
  undefined = 'UNDEFINED',
  address = 'ADDRESS',
  all = 'ALL'
}