export interface Advisor {
  id: number;
  name: string;
  socialInsuranceNumber: string;
  address?: string;
  phoneNumber?: string;
  healthStatus?: number;
}

// default empty advisor object
export const EMPTY_ADVISOR: Advisor = {
  id: 0,
  name: "",
  socialInsuranceNumber: "",
};
