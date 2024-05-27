// all http call methods
export default class HttpService {
  private baseUrl = "http://localhost:5105/api/";

  post = (url = "", data = {}) => {
    return fetch(this.baseUrl + url, {
      method: "POST",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
  };
  put = (url = "", data = {}) => {
    return fetch(this.baseUrl + url, {
      method: "PUT",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
  };
  get = (url = "") => {
    return fetch(this.baseUrl + url, {
      method: "GET",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
    });
  };
  delete = (url = "") => {
    return fetch(this.baseUrl + url, {
      method: "DELETE",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
    });
  };
}
