import { action, makeAutoObservable } from "mobx";
import { Advisor, EMPTY_ADVISOR } from "../../../models/advisor";
import HttpService from "../../../services/http.service";
import APIService from "../../../services/api.service";

export default class AdvisorDetailsViewModel {
  // services
  _httpService: HttpService;
  _apiService: APIService;
  //observables
  advisor: Advisor = { ...EMPTY_ADVISOR };
  loading = false;

  constructor(httpService: HttpService, apiService: APIService) {
    makeAutoObservable(this);
    this._httpService = httpService;
    this._apiService = apiService;
  }

  // actions
  private changeLoadingState(value: boolean) {
    this.loading = value;
  }

  public getAdvisor(id: string) {
    this.changeLoadingState(true);
    this._httpService
      .get(this._apiService.getAdvisor(id))
      .then((response) => response.json())
      .then(
        action("getAdvisorSuccess", (json) => {
          this.advisor = json;
          this.changeLoadingState(false);
        })
      )
      .catch((error) => {
        console.error(error);
        this.changeLoadingState(false);
      });
  }

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
      .put(this._apiService.getAdvisors(), this.advisor)
      .then(() => navigateCallback())
      .catch((error) => console.error(error));
  }

  public clearAll() {
    this.advisor = { ...EMPTY_ADVISOR };
  }
}
