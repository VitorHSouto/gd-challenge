import { Address } from "../address/address.types";
import { InternalFile } from "../file/file.types";

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
  bannerFileId?: string;
  logoFileId?: string;
  bannerFile?: InternalFile;
  logoFile?: InternalFile;
}

export interface CompanyFilterRequest {
  includeDetails: string;
  searchText: string;
}

export enum CompanyIncludeDetails{
  undefined = 'UNDEFINED',
  address = 'ADDRESS',
  file = 'FILE',
  all = 'ALL'
}