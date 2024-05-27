import { action, makeAutoObservable } from "mobx";
import { Advisor } from "../../../models/advisor";
import HttpService from "../../../services/http.service";
import APIService from "../../../services/api.service";

export default class AdvisorListViewModel {
  // services
  _httpService: HttpService;
  _apiService: APIService;
  //observables
  advisorList: Advisor[] = [];
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

  public getAdvisors() {
    this.changeLoadingState(true);
    this._httpService
      .get(this._apiService.getAdvisors())
      .then((response) => response.json())
      .then(
        action("getAdvisorSuccess", (json) => {
          this.advisorList = json;
          this.changeLoadingState(false);
        })
      )
      .catch((error) => {
        console.error(error);
        this.changeLoadingState(false);
      });
  }

  public removeAdvisor(id: number) {
    this._httpService
      .delete(this._apiService.deleteAdvisor(id))
      .then(
        action(
          "deleteAdvisorSuccess",
          () =>
            (this.advisorList = this.advisorList.filter(
              (advisor) => advisor.id !== id
            ))
        )
      )
      .catch((error) => console.error(error));
  }

  public clearAll() {
    this.advisorList = [];
  }
}
