import { makeAutoObservable } from "mobx";
import { Advisor, EMPTY_ADVISOR } from "../../../models/advisor";
import HttpService from "../../../services/http.service";
import APIService from "../../../services/api.service";

export default class NewAdvisorViewModel {
  // services
  _httpService: HttpService;
  _apiService: APIService;
  //observables
  advisor: Advisor = { ...EMPTY_ADVISOR };

  constructor(httpService: HttpService, apiService: APIService) {
    makeAutoObservable(this);
    this._httpService = httpService;
    this._apiService = apiService;
  }

  // actions
  public updateAdvisorDetails(changedValues: any) {
    // get the raw value from the mask
    if (changedValues.phoneNumber !== undefined) {
      changedValues.phoneNumber = changedValues.phoneNumber.replace(
        /[^\d]/g,
        ""
      );
    } else if (changedValues.socialInsuranceNumber !== undefined) {
      changedValues.socialInsuranceNumber =
        changedValues.socialInsuranceNumber.replace(/[^\d]/g, "");
    }
    this.advisor = {
      ...this.advisor,
      ...changedValues,
    };
  }

  public saveAdvisor(navigateCallback: any) {
    this._httpService
      .post(this._apiService.getAdvisors(), this.advisor)
      .then(() => navigateCallback())
      .catch((error) => console.error(error));
  }

  public clearAll() {
    this.advisor = { ...EMPTY_ADVISOR };
  }
}
